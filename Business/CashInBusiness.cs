using AutoMapper;
using Business.DTO;
using Business.Exceptions;
using Business.Interface;
using DataAccess.Models;
using DataAccess.Repository;
using Platform.Interface;
using Platform.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business
{
    public class CashInBusiness : ICashInBusiness
    {
        private readonly ImTellerRepository<CashIn> _cashInRepository;
        private readonly IMapper _mapper;
        private readonly IDisbursement _disbursement;

        public CashInBusiness(ImTellerRepository<CashIn> cashInRepository, IMapper mapper, IDisbursement disbursement)
        {
            _cashInRepository = cashInRepository;
            _mapper = mapper;
            _disbursement = disbursement;
        }

        public async Task<OperationalResult<CashInDTO>> AddCashIn(CashInDTO cashInDTO)
        {
            try
            {
                var result = new OperationalResult<CashInDTO>();

                var cashInRequestInput = new CashInPayload
                {
                    Amount = cashInDTO.Amount,
                    Currency = cashInDTO.Currency,
                    ExternalId = cashInDTO.ExternalId,
                    Payer = new Platform.Model.Payer
                    {
                        PartyId = cashInDTO.Payer.PartyId,
                        PartyIdType = cashInDTO.Payer.PartyIdType
                    },
                    PayeeNote = cashInDTO.PayeeNote,
                    PayerMessage = cashInDTO.PayerMessage
                };
                //TODO: 1. Get customer data from MTN API
                //      2. If data retrieval succeeds
                //          2.1. Add cashin to database with status Pending
                //          2.2. Post Cashin to MTN API
                //          2.2. Update cashin status in the database to Success
                //          2.3. Log the transaction details and or print out a receipt.
                //      3. If data retrieval fails
                //          3.1. log the exception
                //          3.2. throw a user friendly error message for user
                var cashIn = GetCashInDetialsToCashIn(cashInDTO);// _mapper.Map<CashIn>(cashInDTO);

                var added = _cashInRepository.Add(cashIn);

                if (added)
                {
                    await _cashInRepository.SaveChangesAsync();
                    var success = await _disbursement.Disburse(cashInRequestInput);
                    if (success)
                    {
                        _cashInRepository.Attached(cashIn);
                        cashIn.Status = "Success";
                        await _cashInRepository.SaveChangesAsync();
                    }
                    else
                    {
                        result.Status = false;
                    }
                }
                else
                    result.Status = false;

                return result;
            }
            catch (Exception ex)
            {
                throw new ForbiddenException(ex);
            }
        }

        public static CashIn GetCashInDetialsToCashIn(CashInDTO cashInDetail)
        {
            CashIn newCashIn;
            if (cashInDetail != null && cashInDetail.Amount > 0 && !String.IsNullOrWhiteSpace(cashInDetail.Payer.PartyId))
            {
                newCashIn = new CashIn
                {
                    //The guid identifier id to uniquely identify the record
                    CashInUId = Guid.NewGuid(),
                    //The entity type id
                    EntitypeID = (int)Common.Constant.EntityType.CashIn,
                    //The default transaction type name
                    TransactionType = "CASHIN",
                    //The name of cash sender
                    DepositorName = cashInDetail.DepositorName,
                    //The phone number of cash sender
                    DepositorContactNo = cashInDetail.DepositorContactNo,
                    //The registered sim name of momo cashin payee number
                    AccountName = cashInDetail.PayerName,
                    // The registered sim  number of momo cashin payee
                    AccountNumber = cashInDetail.Payer.PartyId,
                    // The cashin amount
                    Amount = cashInDetail.Amount,
                    //True if sender pays charges
                    IsSendingChargePaidBySender = true,
                    //The amount of charges for sending cashin
                    SendingCost = cashInDetail.Amount * (decimal)0.01M, //TODO:Change 0.01 to config variable
                                                                        //The date of transaction. This is auto set with format yyyy/MM/dd
                    TransactionDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:sss"),
                    lastStatus = "New",
                    Status = "Pending",
                    History = "",
                    // The merchant number sending the e-cash for the cashin
                    // BranchAccountNumber = subscription.MerchantNumbere,
                    //The branch code of the transaction
                    BranchCode = cashInDetail.BranchCode,
                    //The name of the user capturing the record
                    CreateUserName = cashInDetail.UserName,
                    //The date and time of the captured record. Auto set with format yyyy/MM//dd H:MM SSSS
                    CreateDateTime = DateTime.Now,
                    //The user name of last modification of the record
                    ModifyUserName = null,
                    //The date and time last modification of the record
                    ModifyDateTime = null,
                    //The name of last process modifying the record
                    LastProcessName = "Capture",
                    // The note entered by payer for reference
                    PayerNote = cashInDetail.PayerMessage,
                    // The note endterd by payer for payee reference
                    PayeeNote = cashInDetail.PayeeNote,
                    //
                    ExternalId = cashInDetail.ExternalId,
                    // Indicate either is cell phone number or other number
                    PartyIdType = cashInDetail.Payer.PartyIdType
                };

                //TODO: Update migration to add new fields to DB table
            }
            else
            {
                throw new Exception("Invalid CashIn details provided.");
                //TODO: Log error into file
            }

            return newCashIn;
        }

        public async Task<OperationalResult<CashInDTO>> DeleteCashIn(int id)
        {
            try
            {
                var result = new OperationalResult<CashInDTO>()
                {
                    Status = false
                };

                var CashInResult = await GetCashIn(id);

                var CashInResultDTO = CashInResult.Data as CashInDTO;
                if (CashInResultDTO == null)
                {
                    throw new NotFoundException("Record to be deleted was not found.");
                }

                result.Status = await _cashInRepository.DeleteAsync(id);

                return result;
            }
            catch (Exception ex)
            {
                //_logger.LogError(ex, ex.Message);
                throw new ForbiddenException(ex);
            }
        }

        public async Task<OperationalResult<IList<CashInDTO>>> GetAllCashIn()
        {
            var result = new OperationalResult<IList<CashInDTO>>()
            {
                Status = false,
                Data = new List<CashInDTO>()
            };

            try
            {
                var cashIns = await _cashInRepository.GetAllAsync();

                var cashInsDTO = _mapper.Map<IList<CashInDTO>>(cashIns);
                result.Data = cashInsDTO;

                result.Status = true;

                return result;
            }
            catch (Exception ex)
            {
                throw new ForbiddenException(ex);
            }
        }

        public async Task<OperationalResult<CashInDTO>> GetCashIn(int CashInId)
        {
            try
            {
                var result = new OperationalResult<CashInDTO>()
                {
                    Status = false,
                    Data = new CashInDTO()
                };

                var cashIn = await _cashInRepository.GetAsync(CashInId);
                if (cashIn == null)
                {
                    throw new NotFoundException();
                }

                // A cashInDTO is created
                var cashInDTO = _mapper.Map<CashInDTO>(cashIn);
                result.Data = cashInDTO;
                result.Status = true;
                return result;
            }
            catch (Exception ex)
            {
                throw new ForbiddenException(ex);
            }
        }

        public async Task<OperationalResult<CashInDTO>> UpdateCashIn(CashInDTO cashInDTO)
        {
            var result = new OperationalResult<CashInDTO>()
            {
                Status = false
            };

            try
            {
                var CashInResult = await GetCashIn(cashInDTO.CashInId);

                if (!(CashInResult.Data is CashInDTO CashInResultDTO))
                {
                    throw new NotFoundException();
                }

                var cashIn = _mapper.Map<CashIn>(CashInResultDTO);
                result.Status = _cashInRepository.Update(cashIn);

                return result;
            }
            catch (Exception ex)
            {
                throw new ForbiddenException(ex);
            }
        }
    }
}