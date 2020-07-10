using AccountManager._3._Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountManager._1._Presentation.ResponseModel
{
    public class AccountCreationResponse
    {
        public int AccountNumber { get; set; }
        public int OwnerNumber { get; set; }
        public string Owner { get; set; }
        public decimal WithdrawLimit { get; set; }
        public bool Active { get; set; }
        public string Type { get; set; }
        public string CreationDate { get; set; }

        public AccountCreationResponse(Account account)
        {
            if (account != null)
            {
                AccountNumber = account.Id;
                OwnerNumber = account.Person == null ? 0 : account.Person.Id;
                Owner = account.Person == null ? "" : account.Person.Name;
                WithdrawLimit = account.WithdrawLimit;
                Active = account.Active;
                Type = account.Type.ToString();
                CreationDate = account.CreationDate.ToShortDateString();
            }
        }
    }
}
