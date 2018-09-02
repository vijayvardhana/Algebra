using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;


namespace Algebra.Data.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly ApplicationDbContext _dbContext;
        
        public Repository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        void IRepository<TEntity>.Add(TEntity entity)
        {
            _dbContext.Set<TEntity>().Add(entity);
        }

        void IRepository<TEntity>.AddRange(IEnumerable<TEntity> entities)
        {
            _dbContext.Set<TEntity>().AddRange(entities);
        }

        IEnumerable<TEntity> IRepository<TEntity>.Find(Expression<Func<TEntity, bool>> predicate)
        {
            return _dbContext.Set<TEntity>().Where(predicate);
        }

        TEntity IRepository<TEntity>.Get(int id)
        {
            return _dbContext.Set<TEntity>().Find(id);
        }

        IEnumerable<TEntity> IRepository<TEntity>.GetAll()
        {
            return _dbContext.Set<TEntity>().ToList();
        }

        void IRepository<TEntity>.Remove(TEntity entity)
        {
            _dbContext.Set<TEntity>().Remove(entity);
        }

        void IRepository<TEntity>.RemoveRange(IEnumerable<TEntity> entities)
        {
            _dbContext.Set<TEntity>().RemoveRange(entities);
        }

        public virtual void Update(TEntity entity)
        {
            _dbContext.Set<TEntity>().Update(entity);
        }
    }
}
