using DataAccess.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace Business.Interface
{
    public interface ICashInBusiness
    {
        Task<CashIn> GetCashIn(int CashInId);
        Task<IList<CashIn>> GetAllCashIn();
        Task AddCashIn(CashIn cashIn);
        Task<CashIn> UpdateCashIn(CashIn cashIn);
        Task<CashIn> DeleteCashIn(int id);

    }
}