using AccountManager._3._Domain.Infra;
using AccountManager._4._InfraInfra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountManager._4._Infra
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AccountManagerContext _dataContext;

        public UnitOfWork(AccountManagerContext dataContext)
        {
            _dataContext = dataContext;
        }

        public int SaveChanges()
        {
            return _dataContext.SaveChanges();
        }
    }
}
