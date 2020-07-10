using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountManager._3._Domain.Entities
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CPF { get; set; }
        public DateTime BirthdayDate { get; set; }
        public virtual ICollection<Account> Accounts { get; set; }

        public Person()
        {
            Accounts = new HashSet<Account>();
        }

    }
}
