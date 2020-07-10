using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountManager._3._Domain.Entities
{
    public class Transaction
    {
        public int Id { get; set; }
        public decimal Value { get; set; }
        public DateTime TransactionDate { get; set; }
        

    }
}
