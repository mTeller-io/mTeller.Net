using System;
using System.Threading.Tasks;
using System.Collections.Generic;


namespace DataAccess.Repository
{
    public interface ImTellerRepository<T> where T : class
    {
          Task<IList<T>> GetAll();
          Task<T> Get(int id);
          Task<T> Add(T entity);
          Task<T> Update(T entity);
          Task<T> Delete(int id);
    }
}