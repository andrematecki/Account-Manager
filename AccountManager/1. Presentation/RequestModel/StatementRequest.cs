using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AccountManager._1._Presentation.RequestModel
{
    public class StatementRequest
    {
        [Required]
        public int AccountNumber { get; set; }
        /// <summary>
        /// To consult a full statement must be null
        /// </summary>
        /// <example>2020-07-01</example>
        public DateTime? InitialDate { get; set; }
        /// <summary>
        /// To consult a full statement must be null
        /// </summary>
        /// <example>2020-07-20</example>
        public DateTime? EndDate { get; set; }
    }
}
