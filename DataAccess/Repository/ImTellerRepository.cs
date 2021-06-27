using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public interface ImTellerRepository<T> where T : class
    {
          Task<List<T>> GetAll();
          Task<T> Get(int id);
          Task<T> Add(T entity);
          Task<T> Update(T entity);
          Task<T> Delete(int id);
    }
}