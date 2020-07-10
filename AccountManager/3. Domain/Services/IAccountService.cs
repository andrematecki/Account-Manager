using AccountManager._3._Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountManager._3._Domain.Services
{
    public interface IAccountService : IServiceBase<int, Account>
    {
        Account Withdraw(int accountNumber, decimal value);
        Account Deposit(int accountNumber, decimal value);
        Account BlockAccount(int accountNumber);
        ICollection<Transaction> Statement(int accountNumber, DateTime? initialDate, DateTime? endDate);
    }
}
