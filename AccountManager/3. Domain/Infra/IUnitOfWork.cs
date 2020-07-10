using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountManager._3._Domain.Infra
{
    public interface IUnitOfWork
    {
        int SaveChanges();
    }
}
