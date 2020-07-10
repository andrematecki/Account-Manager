using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AccountManager._1._Presentation.RequestModel
{
    public class TransactionOperationsRequest
    {
        [Range(1, int.MaxValue)]
        public int AccountNumber { get; set; }
        [Range(1, double.MaxValue)]
        public decimal Value { get; set; }
    }
    
}
