using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GoriAPI.Models
{
    public class SalesModel
    {
        public int Id { get; set; }

        [Required]
        public int PositionId { get; set; }

        [Required]
        public int Quantity { get; set; }

        public int Customer { get; set; }
        public decimal TotalPrice { get; set; }
        public bool Paid { get; set; }
        public DateTime TimeOfSale { get; set; }
    }
}
