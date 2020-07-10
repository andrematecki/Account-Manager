using AccountManager._3._Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountManager._1._Presentation.ResponseModel
{
    public class AccountOperationsResponse
    {
        public int AccountNumber { get; set; }
        public decimal Balance { get; set; }

        public AccountOperationsResponse(Account account)
        {
            if (account != null)
            {
                AccountNumber = account.Id;
                Balance = account.Balance;
            }
        }
    }
}
