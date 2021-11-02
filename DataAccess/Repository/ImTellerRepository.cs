using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;

namespace DataAccess.Repository
{
    public interface ImTellerRepository<T> where T: class
    {
          Task<IList<T>> GetAllAsync();
          Task<T> GetAsync(int id);
          bool Add(T entity);
          bool Update(T entity);
          Task<bool> DeleteAsync(Object id);

          Task<IEnumerable<T>> GetAsync(
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeProperties = "");

          Task<bool> SaveChangesAsync();
    }
}