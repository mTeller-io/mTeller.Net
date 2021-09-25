using System;
using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using DataAccess.DataContext;


namespace DataAccess.Repository
{
    public class mTellerRepository<T> :ImTellerRepository<T>  where T : class
    {

        private readonly mTellerDBContext _mTellerContext;

        public mTellerRepository (mTellerDBContext mTellerContext)
        {
          _mTellerContext = mTellerContext  ;
        }
        
        public async Task<T> Add(T entity)
        {
            _mTellerContext.Set<T>().Add(entity);
            await _mTellerContext.SaveChangesAsync();
            return entity;
        }

        public async Task<T> Delete(int id)
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

        public async Task<T> Get(int id)
        {
            return await _mTellerContext.Set<T>().FindAsync(id);
        }

        public async Task<IList<T>> GetAll()
        {
            return await _mTellerContext.Set<T>().ToListAsync();
        }

        public async Task<T> Update(T entity)
        {
            _mTellerContext.Entry(entity).State = EntityState.Modified;
            await _mTellerContext.SaveChangesAsync();
            return entity;
        }

       

    }
}