using DataAccess.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace Business.Interface
{
    public interface ICashInBusiness
    {
        Task<CashIn> GetCashIn(int CashInId);
        Task<IEnumerable<CashIn>> GetAllCashIn();
        bool AddCashIn(CashIn cashIn);
        bool UpdateCashIn(CashIn cashIn);
        Task<bool> DeleteCashIn(int id);

    }
}