using Business.DTO;
using DataAccess.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace Business.Interface
{
    public interface ICashOutBusiness
    {
        Task<OperationalResult> GetCashOut(int CashOutId);
        Task<OperationalResult> GetAllCashOut();
        OperationalResult AddCashOut(CashOut cashOut);
        OperationalResult UpdateCashOut(CashOut cashOut);
        Task<OperationalResult> DeleteCashOut(int id);

    }
}