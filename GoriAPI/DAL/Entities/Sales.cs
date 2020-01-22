using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DAL.Entities
{
    public class Sales
    {
        [Key]
        public long Id { get; set; }

        [Required]
        public int PositionId { get; set; }

        [Required]
        public int Quantity { get; set; }

        public int Customer { get; set; }
        public decimal TotalPrice { get; set; }
        public bool Paid { get; set; }      
        public DateTime TimeOfSale { get; set; }
        public Position Position { get; set; }
    }
}
