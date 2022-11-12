using Business.DTO;
using DataAccess.Models;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Business.Interface
{
    public interface ICashOutBusiness
    {
        Task<OperationalResult<CashOut>> GetCashOut(int CashOutId);

        Task<OperationalResult<IList<CashOut>>> GetAllCashOut();

        Task<OperationalResult<CashOut>> AddCashOut(CashOut cashOut);

        OperationalResult<CashOut> UpdateCashOut(CashOut cashOut);

        Task<OperationalResult<CashOut>> DeleteCashOut(int id);
    }
}