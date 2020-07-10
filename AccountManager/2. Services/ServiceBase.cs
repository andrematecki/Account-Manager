
using AccountManager._3._Domain.Infra;
using AccountManager._3._Domain.Infra.Filters;
using AccountManager._3._Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountManager._2._Services
{
    public class ServiceBase<Key, TEntity> : IServiceBase<Key, TEntity> where TEntity : class
    {
        protected IRepositoryBase<Key, TEntity> _repo;
        
        public ServiceBase(IRepositoryBase<Key, TEntity> repo)
        {
            _repo = repo;
        }

        public virtual TEntity Add(TEntity obj)
        {
            var result = _repo.Add(obj);
            return result;
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return _repo.GetAll();
        }

        public virtual IEnumerable<TEntity> GetByFilter(IFilter filter)
        {
            return _repo.GetByFilter(filter);
        }

        public virtual TEntity GetById(Key obj)
        {
            return _repo.GetById(obj);
        }

        public virtual TEntity Remove(TEntity obj)
        {
            return _repo.Remove(obj);
        }

        public virtual TEntity Update(TEntity obj)
        {
            return _repo.Update(obj);
        }
    }
}
