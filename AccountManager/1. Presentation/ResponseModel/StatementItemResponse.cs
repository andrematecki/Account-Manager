using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountManager._1._Presentation.ResponseModel
{
    public class StatementItemResponse
    {
        public DateTime TransactionDate { get; set; }
        public decimal Value { get; set; }
    }
}
