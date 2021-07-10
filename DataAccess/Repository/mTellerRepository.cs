using DataAccess.Models;
using DataAccess.DataContext;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repository
{
    public class mTellerRepository  : ImTellerRepository {

        private readonly mTellerDBContext _mTellerContext;

        public mTellerRepository (mTellerDBContext mTellerContext)
        {
          _mTellerContext = mTellerContext  ;
        }
        
        public async Task<T> Add<T>(T entity) where T : class
        {
            _mTellerContext.Set<T>().Add(entity);
            await _mTellerContext.SaveChangesAsync();
            return entity;
        }

        public async Task<T> Update<T>(T entity)
        {
            _mTellerContext.Entry(entity).State = EntityState.Modified;
            await _mTellerContext.SaveChangesAsync();
            return entity;
        }

        public async Task<T> Delete<T>(int id) where T : class
        {
            var entity = await _mTellerContext.Set<T>().FindAsync(id);
            if (entity == null)
            {
                return entity;
            }

            _mTellerContext.Set<T>().Remove(entity);
            await _mTellerContext.SaveChangesAsync();

            return entity;
        }

        public async Task<T> Get<T>(int id) where T : class
        {
            return await _mTellerContext.Set<T>().FindAsync(id);
        }

        public async Task<List<T>> GetAll<T>() where T : class
        {
            return await _mTellerContext.Set<T>().ToListAsync();
        }
    }
}