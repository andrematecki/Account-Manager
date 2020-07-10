using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using AccountManager._3._Domain.Entities;

namespace AccountManager._1._Presentation.RequestModel
{
    public class AccountCreationRequest
    {
        [Required]
        public string Owner { get; set; }
        [Required]
        [Range(1, double.MaxValue)]
        public decimal WithdrawLimit { get; set; }
        [Required]
        [RegularExpression("CHECKING|SAVINGS", ErrorMessage = "The type must be either 'CHECKING' or 'SAVINGS' only.")]
        public string Type { get; set; }

        public Account ToDomain()
        {
            return new Account
            {
                Person = new Person
                {
                    Name = Owner
                },
                WithdrawLimit = WithdrawLimit,
                Type = Enum.Parse<AccountType>(Type)
            };
            
        }
    }
}
