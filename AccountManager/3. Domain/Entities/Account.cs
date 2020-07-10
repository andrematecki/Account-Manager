using AccountManager._3._Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountManager._3._Domain.Entities
{
    public class Account
    {
        public int Id { get; set; }
        public virtual Person Person { get; set; }
        public decimal WithdrawLimit { get; set; }
        public bool Active { get; set; }
        public AccountType Type { get; set; }
        public DateTime CreationDate { get; set; }
        public virtual ICollection<Transaction> Transactions { get; set; }


        public Account()
        {
            Transactions = new HashSet<Transaction>();
        }


        public decimal Balance
        {
            get
            {
                if (!Active)
                    throw new AccountBlockedException();

                return Transactions.Sum(x => x.Value);
            }
        }

        public void Deposit(decimal value)
        {
            if (!Active)
                throw new AccountBlockedException();

            Transactions.Add(new Transaction { TransactionDate = DateTime.Now, Value = value });
        }

        public void Withdraw(decimal value)
        {
            if (! Active)
                throw new AccountBlockedException();

            if (value > WithdrawLimit)
                throw new WithdrawLimitExceededException();

            if (value > Balance)
                throw new BalanceInsufficientException();

            Transactions.Add(new Transaction { TransactionDate = DateTime.Now, Value = value * -1 });

        }

        public void Block()
        {
            if(! Active)
                throw new AccountBlockedException();

            Active = false;
        }

        public ICollection<Transaction> Statement(DateTime? initialDate, DateTime? endDate)
        {
            
            if (! Active)
                throw new AccountBlockedException();
                
            return Transactions.Where(x => (initialDate == null || x.TransactionDate >= ((DateTime)initialDate).Date) && (endDate == null || x.TransactionDate <= ((DateTime)endDate).Date.AddDays(1))).ToList();
        }
    }
}
