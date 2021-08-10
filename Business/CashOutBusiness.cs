
using DataAccess;
using DataAccess.Models;
using DataAccess.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net.Http;
using Business.Interface;

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


        public async Task<CashOut> GetCashOut(int CashOutId)
        {
            return await _cashOutRepository.Get(CashOutId);
        }

        public async Task<IList<CashOut>> GetAllCashOut()
        {
            return await _cashOutRepository.GetAll();
        }

        public async Task AddCashOut(CashOut cashOut)
        {
            var validationResult = CashOutValidator.GetInstance.Validate(cashOut);

            if (validationResult.IsValid)
            {
                //TODO: 1. Get customer data from MTN API
                //      2. If data retrieval succeeds
                //          2.1. Check if customers account balance is enough (Including 1% charge)
                _ = await client.GetAsync("https://sandbox.momodeveloper.mtn.com/collection/v1_0/account/balance");
                //          2.2. Initiate authorization process for customer to approve (MTN)
                //          2.3. If approval succeeds, subtract cashout amount from customers balance and send.
                //          2.4. Log the transaction details and or print out a receipt.
                //      3. If data retrieval fails
                //          3.1. log the exception
                //          3.2. throw a user friendly error message for user
                await _cashOutRepository.Add(cashOut);
            }
            else
            {
                throw new ValidationException(validationResult.Errors);
            }
        }

        public async Task<CashOut> UpdateCashOut(CashOut cashOut)
        {
            var validationResult = CashOutValidator.GetInstance.Validate(cashOut);

            if (validationResult.IsValid)
            {
                return await _cashOutRepository.Update(cashOut);
            }
            else
            {
                throw new ValidationException(validationResult.Errors);
            }
        }

        public async Task<CashOut> DeleteCashOut(int id)
        {
            return await _cashOutRepository.Delete(id);
        }

    }
}