
using AccountManager._3._Domain.Infra.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountManager._3._Domain.Infra
{
    public interface IRepositoryBase<Key, TEntity> where TEntity : class
    {
        TEntity Add(TEntity obj);
        TEntity Update(TEntity obj);
        TEntity Remove(TEntity obj);
        TEntity GetById(Key obj);
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> GetByFilter(IFilter filter);

    }
}
