using AccountManager._3._Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountManager._1._Presentation.ResponseModel
{
    public class StatementResponse
    {

        public int AccountNumber { get; set; }
        public ICollection<StatementItemResponse> Transactions { get; set; }
        public decimal Balance {
            get
            {
                return Transactions.Sum(x => x.Value);
            }
        }


        public StatementResponse(int accountNumber, ICollection<Transaction> transactions)
        {
            AccountNumber = accountNumber;
            if (transactions == null)
                Transactions = new HashSet<StatementItemResponse>();
            else
                Transactions = transactions.Select(x => new StatementItemResponse { TransactionDate = x.TransactionDate, Value = x.Value }).OrderBy(x => x.TransactionDate).ToList();
        }


    }
    

}
