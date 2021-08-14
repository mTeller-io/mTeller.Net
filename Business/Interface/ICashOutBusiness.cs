using DataAccess.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace Business.Interface
{
    public interface ICashOutBusiness
    {
        Task<CashOut> GetCashOut(int CashOutId);
        Task<IList<CashOut>> GetAllCashOut();
        Task AddCashOut(CashOut cashOut);
        Task<CashOut> UpdateCashOut(CashOut cashOut);
        Task<CashOut> DeleteCashOut(int id);

    }
}