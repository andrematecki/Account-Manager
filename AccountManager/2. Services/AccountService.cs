using AccountManager._3._Domain.Entities;
using AccountManager._3._Domain.Exceptions;
using AccountManager._3._Domain.Infra;
using AccountManager._3._Domain.Infra.Filters;
using AccountManager._3._Domain.Services;
using AccountManager._4._Infra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountManager._2._Services
{
    public class AccountService : ServiceBase<int, Account>, IAccountService
    {
        private readonly IPersonRepository _personRepository;
        private readonly ITransactionRepository _transactionRepository;
        private readonly IUnitOfWork _uow;

        public AccountService(IAccountRepository accountRepository, IPersonRepository personRepository, ITransactionRepository transactionRepository, IUnitOfWork uow) : base(accountRepository)
        {
            _personRepository = personRepository;
            _transactionRepository = transactionRepository;
            _uow = uow;
        }

        public override Account Add(Account obj)
        {
            if (obj.WithdrawLimit <= 0 || obj.Person == null || string.IsNullOrEmpty(obj.Person.Name))
                throw new InvalidParametersException();
            
            var person = _personRepository.GetByFilter(new PersonFilter {  Name = obj.Person.Name }).FirstOrDefault();

            if (person != null)
                obj.Person = person;
            
            obj.Active = true;
            obj.CreationDate = DateTime.Now;
            
            obj = base.Add(obj);
            _uow.SaveChanges();

            return obj;
        }

        public Account Deposit(int accountNumber, decimal value)
        {
            ValidTransaction(accountNumber, value);
            var account = this.GetById(accountNumber);
            account.Deposit(value);
            return UpdateAccount(account);
        }

        public Account Withdraw(int accountNumber, decimal value)
        {
            ValidTransaction(accountNumber, value);
            var account = this.GetById(accountNumber);
            account.Withdraw(value);
            return UpdateAccount(account);
        }
        
        private Account UpdateAccount(Account account)
        {
            account = Update(account);
            _uow.SaveChanges();
            return account;
        }

        public override Account GetById(int accountId)
        {
            var account = base.GetById(accountId);
            if (account == null)
                throw new AccountNotFoundException();

            return account;
        }

        private void ValidTransaction(int accountNumber, decimal value)
        {
            if (accountNumber <= 0 || value <= 0)
                throw new ParametersLessThanZeroException();
        }

        public Account BlockAccount(int accountNumber)
        {
            var account = this.GetById(accountNumber);
            account.Block();
            return UpdateAccount(account);
        }

        public ICollection<Transaction> Statement(int accountNumber, DateTime? initialDate, DateTime? endDate)
        {
            var account = this.GetById(accountNumber);
            return account.Statement(initialDate, endDate);
        }
    }
}
