using Business.DTO;
using DataAccess.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Interface
{
    public interface ICashOutBusiness
    {
        Task<OperationalResult<CashOut>> GetCashOut(int CashOutId);

        Task<OperationalResult<IList<CashOut>>> GetAllCashOut();

        OperationalResult<CashOut> AddCashOut(CashOut cashOut);

        OperationalResult<CashOut> UpdateCashOut(CashOut cashOut);

        Task<OperationalResult<CashOut>> DeleteCashOut(int id);
    }
}