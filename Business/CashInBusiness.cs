using DataAccess.Repository;
using DataAccess.Models;
namespace .
{
    public class CashInBusiness : ICashInBusiness
    {
        private readonly ImTellerRepository<CashIn> _cashInRepository;

        public CashInBusiness(ImTellerRepository<CashIn> cashInRepository)
        {
            _cashInRepository = cashInRepository;

        }


        public CashIn GetCashIn (int CashInId){

            _cashInRepository.Get(CashInId)
        }
        
    }
}