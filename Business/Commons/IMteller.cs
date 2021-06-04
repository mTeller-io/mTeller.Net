using DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public interface IMteller
    {
        IRepository<T> Repository<T>() where T : class;
        Task SaveChangesAsync();
    }

    internal class Mteller : IMteller
    {
        private readonly DbContext _dbContext;
        private Hashtable _repositories;
        public Mteller(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IRepository<T> Repository<T>() where T : class
        {
            if (_repositories == null)
                _repositories = new Hashtable();

            var type = typeof(T).Name;

            if (!_repositories.ContainsKey(type))
            {
                var repositoryType = typeof(Repository<>);

                var repositoryInstance =
                    Activator.CreateInstance(repositoryType.MakeGenericType(typeof(T)), _dbContext);

                _repositories.Add(type, repositoryInstance);
            }

            return (IRepository<T>)_repositories[type];
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }

    public interface IRepository<TEntity> where TEntity : class
    {
        Task<EntityEntry> InsertEntityAsync(TEntity entity);
        EntityEntry DeleteEntity(TEntity entity);
        EntityEntry UpdateEntity(TEntity entity);
        Task LoadEntityAsync(TEntity entity);
    }

    internal class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly DbContext _dbContext;
        public Repository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<EntityEntry> InsertEntityAsync(TEntity entity)
        {
            return await _dbContext.Set<TEntity>().AddAsync(entity);
        }

        public EntityEntry DeleteEntity(TEntity entity)
        {
            return _dbContext.Set<TEntity>().Remove(entity);
        }
        public EntityEntry UpdateEntity(TEntity entity)
        {
            return _dbContext.Set<TEntity>().Update(entity);
        }
        public async Task LoadEntityAsync(TEntity entity)
        {
            await _dbContext.Set<TEntity>().LoadAsync();
        }
    }
}
