using DataAccess;
using DataAccess.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business
{
    public class CashInBusiness : ICashInBusiness
    {
        private readonly ImTellerRepository<CashIn> _cashInRepository;

        public CashInBusiness(ImTellerRepository<CashIn> cashInRepository)
        {
            _cashInRepository = cashInRepository;

        }

        public async Task AddCashIn(CashIn cashIn)
        {
            var validationResult = CashInValidator.GetInstance.Validate(cashIn);

            if (validationResult.IsValid)
            {
                await _cashInRepository.Add(cashIn);
            }
            else
            {
                throw new ValidationException(validationResult.Errors);
            }
        }

        public async Task<CashIn> DeleteCashIn(int id)
        {
            return await _cashInRepository.Delete(id);
        }

        public async Task<List<CashIn>> GetAllCashIn()
        {
            return await _cashInRepository.GetAll();
        }

        public async Task<CashIn> GetCashIn(int CashInId)
        {
            return await _cashInRepository.Get(CashInId);
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