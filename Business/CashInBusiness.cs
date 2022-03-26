
using System;
using System.Threading.Tasks;
using DataAccess.Repository;
using DataAccess.Models;
using Business.Interface;
using System.Collections.Generic;
using System.Net.Http;
using Business.DTO;
using AutoMapper;
using System.Linq;

namespace Business
{
    public class CashInBusiness : ICashInBusiness
    {
        private readonly ImTellerRepository<CashIn> _cashInRepository;
        private readonly IMapper _mapper;
        private readonly IMomoAPI _momoAPI;

        public CashInBusiness(ImTellerRepository<CashIn> cashInRepository, IMapper mapper, IMomoAPI momoAPI)
        {
            _cashInRepository = cashInRepository;
            _mapper = mapper;
            _momoAPI = momoAPI;
        }

        public OperationalResult AddCashIn(CashInDTO cashInDTO)
        {
            try
            {
                var result = new OperationalResult();

                //TODO: 1. Get customer data from MTN API
                //      2. If data retrieval succeeds
                //          2.1. Add the cashin ammount to customers balance
                //          2.2. Log the transaction details and or print out a receipt.
                //      3. If data retrieval fails
                //          3.1. log the exception
                //          3.2. throw a user friendly error message for user

                var cashIn = _mapper.Map<CashIn>(cashInDTO);
                var added =  _cashInRepository.Add(cashIn);

                result.Data.Add(added);
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<OperationalResult> DeleteCashIn(int id)
        {
            try
            {
                var result = new OperationalResult();

                var CashInResult = await GetCashIn(id);
                var CashInResultDTO = CashInResult.Data.FirstOrDefault() as CashInDTO;
                if (CashInResultDTO == null)
                {
                    result.Status = true;
                    result.ErrorList.Add(new Error { ErrorCode = "404", ErrorMessage = "The record for the Cash In Id could not be found." });
                    return result;
                }

                var deleted = await _cashInRepository.DeleteAsync(id);
                result.Data.Add(deleted);

                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<OperationalResult> GetAllCashIn()
        {
            try
            {
                var result = new OperationalResult();
                var cashIns = await _cashInRepository.GetAllAsync();

                var cashInsDTO = _mapper.Map<IList<CashInDTO>>(cashIns);
                result.Data.Add(cashInsDTO);

                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<OperationalResult> GetCashIn(int CashInId)
        {
            try
            {
                var result = new OperationalResult();

                var cashIn = await _cashInRepository.GetAsync(CashInId);
                if (cashIn == null)
                {
                    result.Status = true;
                    result.ErrorList.Add(new Error { ErrorCode = "404", ErrorMessage = "No Cash In records could be found." });
                    return result;
                }

                // A cashInDTO is created
                var cashInDTO = _mapper.Map<CashInDTO>(cashIn);
                result.Data.Add(cashInDTO);
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<OperationalResult> UpdateCashIn(CashInDTO cashInDTO)
        {
            try
            {
                var result = new OperationalResult();

                var CashInResult = await GetCashIn(cashInDTO.CashInId);
                if (!(CashInResult.Data.FirstOrDefault() is CashInDTO CashInResultDTO))
                {
                    result.Status = true;
                    result.ErrorList.Add(new Error { ErrorCode = "404", ErrorMessage = "The Cash In record specified could not be found." });
                    return result;
                }

                var cashIn = _mapper.Map<CashIn>(CashInResultDTO);
                var updated = _cashInRepository.Update(cashIn);

                result.Data.Add(updated);
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}