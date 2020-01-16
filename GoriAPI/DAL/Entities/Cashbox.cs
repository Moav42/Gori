using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DAL.Entities
{
    public class Cashbox
    {
        [Key]
        public int Id { get; set; }
        public decimal Cash { get; set; }
        public decimal Card { get; set; }
        public decimal Total { get; set; }
    }
}
