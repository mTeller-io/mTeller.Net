
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public interface ImTellerRepository
    {
        Task<List<T>> GetAll<T>() where T : class;
        Task<T> Get<T>(int id) where T : class;
        Task<T> Add<T>(T entity) where T : class;
        Task<T> Update<T>(T entity);
        Task<T> Delete<T>(int id) where T : class;

    }
}