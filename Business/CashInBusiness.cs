
using System;
using System.Threading.Tasks;
using DataAccess.Repository;
using DataAccess.Models;
using Business.Interface;
using System.Collections.Generic;
using System.Net.Http;
namespace Business
{
    public class CashInBusiness : ICashInBusiness
    {
        private readonly ImTellerRepository<CashIn> _cashInRepository;
        private static readonly HttpClient client = new HttpClient();

        public CashInBusiness(ImTellerRepository<CashIn> cashInRepository)
        {
            _cashInRepository = cashInRepository;
        }

        public  bool AddCashIn(CashIn cashIn)
        {
            var validationResult = CashInValidator.GetInstance.Validate(cashIn);

            if (validationResult.IsValid)
            {
                //TODO: 1. Get customer data from MTN API
                //      2. If data retrieval succeeds
                //          2.1. Add the cashin ammount to customers balance
                //          2.2. Log the transaction details and or print out a receipt.
                //      3. If data retrieval fails
                //          3.1. log the exception
                //          3.2. throw a user friendly error message for user
               return  _cashInRepository.Add(cashIn);
            }
            else
            {
                throw new ValidationException(validationResult.Errors);
            }
        }

        public async Task<bool> DeleteCashIn(int id)
        {
            return  await _cashInRepository.DeleteAsync(id);
        }

        public async Task<IList<CashIn>> GetAllCashIn()
        {
            return await _cashInRepository.GetAllAsync();
        }

        public async Task<CashIn> GetCashIn(int CashInId)
        {
            return await _cashInRepository.GetAsync(CashInId);
        }

        public bool UpdateCashIn(CashIn cashIn)
        {
            var validationResult = CashInValidator.GetInstance.Validate(cashIn);

            if (validationResult.IsValid)
            {
                return _cashInRepository.Update(cashIn);
            }
            else
            {
                throw new ValidationException(validationResult.Errors);
            }
        }

    }
}