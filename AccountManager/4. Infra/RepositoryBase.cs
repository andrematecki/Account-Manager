
using AccountManager._3._Domain.Infra;
using AccountManager._3._Domain.Infra.Filters;
using AccountManager._4._InfraInfra;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AccountManager._4._Infra
{

    public class RepositoryBase<Key, TEntity> : IRepositoryBase<Key, TEntity> where TEntity : class
    {
        protected readonly AccountManagerContext _dataContext;
        protected readonly DbSet<TEntity> _dbset;

        public RepositoryBase(AccountManagerContext dataContext)
        {
            _dataContext = dataContext;
            _dbset = dataContext.Set<TEntity>();
        }

        public virtual TEntity Add(TEntity obj)
        {            
            return _dbset.Add(obj).Entity;
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return _dbset.AsEnumerable<TEntity>().ToList();
        }

        protected virtual IEnumerable<TEntity> GetByFilter(Expression<Func<TEntity, bool>> lambda)
        {
            return _dbset.Where(lambda).AsEnumerable<TEntity>().ToList();
        }

        public virtual TEntity GetById(Key obj)
        {
            return _dbset.Find(obj);
        }

        public virtual TEntity Remove(TEntity obj)
        {
            return _dbset.Remove(obj).Entity;
        }


        public virtual TEntity Update(TEntity obj)
        {
            _dataContext.Entry(obj).State = EntityState.Modified;
            return obj;

        }

        public virtual IEnumerable<TEntity> GetByFilter(IFilter filter)
        {
            throw new NotImplementedException();
        }

        protected virtual int Save()
        {
            return _dataContext.SaveChanges();
        }
    }
}