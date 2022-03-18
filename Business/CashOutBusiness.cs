
using DataAccess;
using DataAccess.Models;
using DataAccess.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net.Http;
using Business.Interface;
using Business.DTO;
using System.Linq;

namespace Business
{
    public class CashOutBusiness : ICashOutBusiness
    {
        private readonly ImTellerRepository<CashOut> _cashOutRepository;
        private static readonly HttpClient client = new HttpClient();

        public CashOutBusiness(ImTellerRepository<CashOut> cashOutRepository)
        {
            _cashOutRepository = cashOutRepository;
        }


        public async Task<OperationalResult<CashOut>> GetCashOut(int CashOutId)
        {
          var result = new OperationalResult<CashOut>
           {
               Status= false
           };

            var cashOut= await _cashOutRepository.GetAsync(CashOutId);
        
           result.Status = cashOut!=null && cashOut.CashOutId>0;

           if(result.Status)
             result.Data.Add(cashOut);
            else
            {
                result.Message="No cashout transaction  found";
            }

            return result;

        }

        public async Task<OperationalResult<CashOut>> GetAllCashOut()
        {
             var result = new OperationalResult<CashOut>
           {
               Status= false
           };
            
            var list= await _cashOutRepository.GetAllAsync();

            if(list.Any())
            {
                result.Status=true;
                result.Data.AddRange(list);

            }else{
                result.Status=false;
                result.Message="Transaction not found";
            }

            return result;
               
        }

        public  OperationalResult<CashOut> AddCashOut(CashOut cashOut)
        {
             var result = new OperationalResult<CashOut>
           {
               Status= false
           };

            var validationResult = CashOutValidator.GetInstance.Validate(cashOut);

            if (validationResult.IsValid)
            {
                //TODO: 1. Get customer data from MTN API
                //      2. If data retrieval succeeds
                //          2.1. Check if customers account balance is enough (Including 1% charge)
               // _ = await client.GetAsync("https://sandbox.momodeveloper.mtn.com/collection/v1_0/account/balance");
                //          2.2. Initiate authorization process for customer to approve (MTN)
                //          2.3. If approval succeeds, subtract cashout amount from customers balance and send.
                //          2.4. Log the transaction details and or print out a receipt.
                //      3. If data retrieval fails
                //          3.1. log the exception
                //          3.2. throw a user friendly error message for user
                result.Status= _cashOutRepository.Add(cashOut);

                if(!result.Status)
                   result.Message ="Error adding new cashout transaction";

                return result;

                
            }
            else
            {
                throw new ValidationException(validationResult.Errors);
            }
        }

        public OperationalResult<CashOut> UpdateCashOut(CashOut cashOut)
        {
          var result = new OperationalResult<CashOut>
           {
               Status= false
           };

            var validationResult = CashOutValidator.GetInstance.Validate(cashOut);

            if (validationResult.IsValid)
            {
               result.Status =_cashOutRepository.Update(cashOut);
            }
            else
            {
                throw new ValidationException(validationResult.Errors);
            }

            return result;
        }

        public async Task<OperationalResult<CashOut>> DeleteCashOut(int id)
        {
             var result = new OperationalResult<CashOut>
           {
               Status= false
           };


            result.Status= await _cashOutRepository.DeleteAsync(id);

            if(!result.Status)
               result.Message="Sorry. Transaction could not be deleted";
            
            return result;
        }

    }
}