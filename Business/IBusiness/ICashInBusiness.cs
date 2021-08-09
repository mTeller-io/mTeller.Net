
using DataAccess;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business
{
    public interface ICashInBusiness
    {
        Task<CashIn> GetCashIn(int CashInId);
        Task<List<CashIn>> GetAllCashIn();
        Task AddCashIn(CashIn cashIn);
        Task<CashIn> UpdateCashIn(CashIn cashIn);
        Task<CashIn> DeleteCashIn(int id);

    }
}