using DataAccess;
using DataAccess.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business
{
    public class CashOutBusiness : ICashOutBusiness
    {
        private readonly ImTellerRepository<CashOut> _cashOutRepository;

        public CashOutBusiness(ImTellerRepository<CashOut> cashOutRepository)
        {
            _cashOutRepository = cashOutRepository;
        }


        public async Task<CashOut> GetCashOut(int CashOutId)
        {
            return await _cashOutRepository.Get(CashOutId);
        }

        public async Task<List<CashOut>> GetAllCashOut()
        {
            return await _cashOutRepository.GetAll();
        }

        public async Task AddCashOut(CashOut cashOut)
        {
            var validationResult = CashOutValidator.GetInstance.Validate(cashOut);

            if (validationResult.IsValid)
            {
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