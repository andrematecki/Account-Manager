using AccountManager._3._Domain.Entities;
using AccountManager._3._Domain.Infra;
using AccountManager._3._Domain.Infra.Filters;
using AccountManager._4._InfraInfra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountManager._4._Infra
{
    public class PersonRepository : RepositoryBase<int, Person>, IPersonRepository
    {
        public PersonRepository(AccountManagerContext dataContext) : base(dataContext)
        {
        }

        public override IEnumerable<Person> GetByFilter(IFilter filter)
        {
            PersonFilter f = filter as PersonFilter;

            return GetByFilter(x => string.IsNullOrEmpty(f.Name) || x.Name.Equals(f.Name));
        }
    }
}
