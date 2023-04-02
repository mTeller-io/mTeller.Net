using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public interface ImTellerRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync(int pageNo = 0, int pageSize = 25);

        Task<T> GetAsync(int id);

        bool Add(T entity);

        bool Update(T entity);

        bool Attached(T entity);

        Task<bool> DeleteAsync(Object id);

        Task<IEnumerable<T>> GetAsync(
          Expression<Func<T, bool>> filter = null,
          Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
          string includeProperties = "", int pageNo = 0, int pageSize = 25);

        Task<bool> SaveChangesAsync();
    }
}