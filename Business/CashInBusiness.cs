
using DataAccess;
using DataAccess.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net.Http;

namespace Business
{
    public class CashInBusiness : ICashInBusiness
    {
        private readonly ImTellerRepository _cashInRepository;
        private static readonly HttpClient client = new HttpClient();

        public CashInBusiness(ImTellerRepository cashInRepository)
        {
            _cashInRepository = cashInRepository;
        }

        public async Task AddCashIn(CashIn cashIn)
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
                await _cashInRepository.Add(cashIn);
            }
            else
            {
                throw new ValidationException(validationResult.Errors);
            }
        }

        public async Task<CashIn> DeleteCashIn(int id)
        {
            return await _cashInRepository.Delete<CashIn>(id);
        }

        public async Task<List<CashIn>> GetAllCashIn()
        {
            return await _cashInRepository.GetAll<CashIn>();
        }

        public async Task<CashIn> GetCashIn(int CashInId)
        {
            return await _cashInRepository.Get<CashIn>(CashInId);
        }

        public async Task<CashIn> UpdateCashIn(CashIn cashIn)
        {
            var validationResult = CashInValidator.GetInstance.Validate(cashIn);

            if (validationResult.IsValid)
            {
                return await _cashInRepository.Update(cashIn);
            }
            else
            {
                throw new ValidationException(validationResult.Errors);
            }
        }

    }
}