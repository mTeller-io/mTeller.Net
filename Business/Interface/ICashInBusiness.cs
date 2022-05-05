using DataAccess.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Business.DTO;
namespace Business.Interface
{
    public interface ICashInBusiness
    {
        Task<CashIn> GetCashIn(int CashInId);
        Task<IEnumerable<CashIn>> GetAllCashIn();
        bool AddCashIn(CashInDetail cashInDetail);
        Task<bool> ArchiveCashIn(int cashInId); // For security reason, should not allow CashIn update. To update delete and recapture
       // Task<bool> DeleteCashIn(int id);// For security reason, should not allow CashIn update. To update delete and recapture

    }
}