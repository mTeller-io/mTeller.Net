using DataAccess;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business
{
    public interface ICashOutBusiness
    {
        Task<CashOut> GetCashOut(int CashOutId);
        Task<List<CashOut>> GetAllCashOut();
        Task AddCashOut(CashOut cashOut);
        Task<CashOut> UpdateCashOut(CashOut cashOut);
        Task<CashOut> DeleteCashOut(int id);
    }
}