using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountManager._3._Domain.Infra.Filters
{
    public class PersonFilter : IFilter
    {
        public string Name { get; set; }
    }
}
