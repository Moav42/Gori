using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoriAPI.Models
{
    public class CashboxModel
    {
        public int Id { get; set; }
        public decimal Cash { get; set; }
        public decimal Card { get; set; }
        public decimal Total { get; set; }
    }
}
