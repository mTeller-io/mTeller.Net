using DataAccess.DataContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class mTellerRepository<T> : ImTellerRepository<T> where T : class
    {
        private readonly mTellerDBContext _mTellerContext;
        internal DbSet<T> _dbSet;

        public mTellerRepository(mTellerDBContext mTellerContext)
        {
            _mTellerContext = mTellerContext;
            this._dbSet = _mTellerContext.Set<T>();
        }

        public bool Add(T entityToAdd)
        {
            if (entityToAdd == null)
            {
                return false;
            }
            _dbSet.Add(entityToAdd);
            // await _mTellerContext.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteAsync(object id)
        {
            var entityToDelete = await _dbSet.FindAsync(id);
            if (entityToDelete == null)
            {
                return false;
            }
            var result = Delete(entityToDelete);

            return result;
        }

        public bool Delete(T entityToDelete)
        {
            if (entityToDelete == null)
            {
                return false;
            }

            if (_mTellerContext.Entry(entityToDelete).State == EntityState.Detached)
            {
                _dbSet.Attach(entityToDelete);
            }
            _dbSet.Remove(entityToDelete);

            return true;
        }

        public async Task<T> GetAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<IEnumerable<T>> GetAllAsync(int pageNo = 0, int pageSize = 25)
        {
            System.Linq.IQueryable<T> query = _dbSet;
            //var skipCount = pageNo * pageSize;
            // query = query.Skip(skipCount).Take(pageSize);

            return await query.ToListAsync();
        }

        public async Task<IEnumerable<T>> GetAsync(
           Expression<Func<T, bool>> filter = null,
           Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
           string includeProperties = "", int pageNo = 0, int pageSize = 25)
        {
            System.Linq.IQueryable<T> query = _dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                return await orderBy((IQueryable<T>)query).ToListAsync();
            }
            else
            {
                return await query.ToListAsync();
            }
        }

        public bool Update(T entity)
        {
            if (entity == null)
            {
                return false;
            }
            _mTellerContext.Entry(entity).State = EntityState.Modified;

            return true;
        }

        public bool Attached(T entity)
        {
            if (entity == null)
            {
                return false;
            }

            _dbSet.Attach(entity);

            return true;
        }

        public async Task<bool> SaveChangesAsync()
        {
            await _mTellerContext.SaveChangesAsync();

            return true;
        }
    }
}