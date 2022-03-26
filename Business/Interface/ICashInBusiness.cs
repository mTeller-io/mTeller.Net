using Business.DTO;
using DataAccess.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace Business.Interface
{
    public interface ICashInBusiness
    {
        Task<OperationalResult> GetCashIn(int CashInId);
        Task<OperationalResult> GetAllCashIn();
        OperationalResult AddCashIn(CashInDTO cashInDTO);
        Task<OperationalResult> UpdateCashIn(CashInDTO cashInDTO);
        Task<OperationalResult> DeleteCashIn(int id);

    }
}