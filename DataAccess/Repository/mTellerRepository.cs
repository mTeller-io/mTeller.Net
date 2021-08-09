using DataAccess.Models;

using DataAccess.DataContext;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repository
{
    public class mTellerRepository<T>  :ImTellerRepository<T>  where T : class {


        private readonly mTellerDBContext _mTellerContext;

        public mTellerRepository (mTellerDBContext mTellerContext)
        {
          _mTellerContext = mTellerContext  ;
        }
        
        public async Task<TEntity> Add(TEntity entity)
        {
            _mTellerContext.Set<TEntity>().Add(entity);
            await _mTellerContext.SaveChangesAsync();
            return entity;
        }

        public async Task<TEntity> Delete(int id)
        {
            var entity = await _mTellerContext.Set<TEntity>().FindAsync(id);

            if (entity == null)
            {
                return entity;
            }

            _mTellerContext.Set<T>().Remove(entity);
            await _mTellerContext.SaveChangesAsync();


            return entity;
        }


        public async Task<T> Get<T>(int id) 
        {
            return await _mTellerContext.Set<T>().FindAsync(id);
        }

        public async Task<List<T>> GetAll<T>() 
        {
            return await _mTellerContext.Set<T>().ToListAsync();
        }

    }
}