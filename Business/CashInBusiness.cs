
using System;
using System.Threading.Tasks;
using DataAccess.Repository;
using DataAccess.Models;
using Business.Interface;
using System.Collections.Generic;
using System.Net.Http;
using Business.DTO;
using Common.Constant;
using Common.Helpers;
using Business.Validators;
namespace Business
{
    public class CashInBusiness : ICashInBusiness
    {
        private readonly ImTellerRepository<CashIn> _cashInRepository;
        private readonly ImTellerRepository<MoMoAPISubscription> _momoAPISubscriptionRepository;

        private readonly List<string> providerList = new List<string>{
           "MTN",
            "VODAFONE",
            "AIRTELTIGO"
        };

       // private static readonly HttpClient client = new HttpClient();

        public CashInBusiness(ImTellerRepository<CashIn> cashInRepository, 
        ImTellerRepository<MoMoAPISubscription> momoAPISubscriptionRepository)
        {
            _cashInRepository = cashInRepository;
            _momoAPISubscriptionRepository = momoAPISubscriptionRepository;

        }

        public bool AddCashIn(CashInDetail cashInDetail)
        {
            var validationResult = CashInDetailValidator.GetInstance.Validate(cashInDetail);

            if (validationResult.IsValid)
            {
                //TODO: 1. Get customer data from MTN API
                //      2. If data retrieval succeeds
                //          2.1. Add the cashin ammount to customers balance
                //          2.2. Log the transaction details and or print out a receipt.
                //      3. If data retrieval fails
                //          3.1. log the exception
                //          3.2. throw a user friendly error message for user
                 
                 //Get the provider i.e MTN, VODAFONE,AIRTELTIGO
                var provider  = !providerList.Contains(cashInDetail.Provider)?
                 throw new Exception("Missing Provider Name"):
                 cashInDetail.Provider;
                //Get the subscription details for collection e.g APIUSER,APIKEYS,Urls,Subscription keys
               /*  var subscription = await _momoAPISubscriptionRepository.GetAsync(
                    x=>x.NetworkName==provider && x.ProductType==nameof(ProductTypes.Collection),null,
                    "EndPoints"
                    ).FirstAsync(); */

                    
               
               var newCashIn = GetCashInDetialsToCashIn(cashInDetail);
              
                
               return  _cashInRepository.Add(newCashIn);
            }
            else
            {
                throw new ValidationException(validationResult.Errors);
            }
        }

        public CashIn GetCashInDetialsToCashIn(CashInDetail cashInDetail)
        {  
            CashIn newCashIn=null;
           if(cashInDetail!=null && cashInDetail.Amount>0 & !String.IsNullOrWhiteSpace(cashInDetail.Payer.PartyId))
             {
                  newCashIn = new CashIn {
                    //The guid identifier id to uniquely identify the record
                    CashInUId = Guid.NewGuid(),
                   //The entity type id
                    EntitypeID =(int) Common.Constant.EntityType.CashIn,
                  //The default transaction type name
                    TransactionType  = "CASHIN",
                  //The name of cash sender
                    DepositorName = cashInDetail.PayerName,
                  //The phone number of cash sender
                    DepositorContactNo = cashInDetail.DepositorContactNo,
                   //The registered sim name of momo cashin payee number
                    AccountName = cashInDetail.PayerName,
                   // The registered sim  number of momo cashin payee
                   AccountNumber =cashInDetail.Payer.PartyId, 
                   // The cashin amount
                   Amount = cashInDetail.Amount,
                   //True if sender pays charges
                   IsSendingChargePaidBySender = true,
                  //The amount of charges for sending cashin
                   SendingCost = cashInDetail.Amount * (decimal)0.01M, //TODO:Change 0.01 to config variable
                  //The date of transaction. This is auto set with format yyyy/MM/dd
                   TransactionDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:sss"),
                   lastStatus = "New",
                    Status = "PostReady",
                    History ="",
                   // The merchant number sending the e-cash for the cashin
                   // BranchAccountNumber = subscription.MerchantNumbere,
                   //The branch code of the transaction
                    BranchCode = cashInDetail.BranchCode,
                    //The name of the user capturing the record
                    CreateUserName =cashInDetail.UserName,
                    //The date and time of the captured record. Auto set with format yyyy/MM//dd H:MM SSSS
                    CreateDateTime = DateTime.Now,
                    //The user name of last modification of the record
                    ModifyUserName = null,
                    //The date and time last modification of the record
                    ModifyDateTime =null,
                    //The name of last process modifying the record
                    LastProcessName= "Capture",
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

               }else{
                   throw new Exception("Invalid CashIn details provided.");
                   //TODO: Log error into file
               }

               return newCashIn;
        }

        public async Task<bool> DeleteCashIn(int id)
        {
            return  await _cashInRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<CashIn>> GetAllCashIn()
        {
            return await _cashInRepository.GetAllAsync();
        }

        public async Task<CashIn> GetCashIn(int CashInId)
        {
            return await _cashInRepository.GetAsync(CashInId);
        }
       
       //For security reason no update of CashIn is allowed. 
        public async Task<bool>  ArchiveCashIn(int cashInId)
        {
           var validator = CashInDetailValidator.GetInstance;

            if (validator.GreaterThanZero(cashInId) )
           {
                var archCashIn = await _cashInRepository.GetAsync(cashInId);

                archCashIn.Status="Archived";
                //archCashIn.Mo

                return _cashInRepository.Update(archCashIn);
            }
            else
            {
                //throw new ValidationException(validationResult.Errors);
                throw new Exception ("Invalid CashIn Id provided. CashIn must be greater than zero");
            }
        }

    }
}