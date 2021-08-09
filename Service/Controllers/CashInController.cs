
using Business.CashInBusiness;

namespace Service.Controllers
{
    public class CashInController : ControllerBase
    {
        private ICashInBusiness _cashInBusiness  ;
        
        public CashInController ( ICashInBusiness cashInBusiness)
        {
            _cashInBusiness  = cashInBusiness;

        }

        public CashIn  GetCashin (int CashId){
            _cashInBusiness.GetCash(id)
        }
    }
}