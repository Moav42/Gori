using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GoriAPI.Models
{
    public class DrinkModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public decimal PriceLiter { get; set; }
        public decimal ActualVolume { get; set; }
        public int DrinkCategoryId { get; set; }
    }
}
