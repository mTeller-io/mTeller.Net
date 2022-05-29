using Business.DTO;
using DataAccess.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Interface
{
    public interface ICashInBusiness
    {

        Task<OperationalResult<CashInDTO>> GetCashIn(int CashInId);
        Task<OperationalResult<IList<CashInDTO>>> GetAllCashIn();
        OperationalResult<CashInDTO> AddCashIn(CashInDTO cashInDTO);
        Task<OperationalResult<CashInDTO>> UpdateCashIn(CashInDTO cashInDTO);
        Task<OperationalResult<CashInDTO>> DeleteCashIn(int id);


    }
}