using AccountManager._3._Domain.Entities;
using AccountManager._3._Domain.Infra;
using AccountManager._4._InfraInfra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountManager._4._Infra
{
    public class TransactionRepository : RepositoryBase<int, Transaction>, ITransactionRepository
    {
        public TransactionRepository(AccountManagerContext dataContext) : base(dataContext)
        {
        }
    }
}
