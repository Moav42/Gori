using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GoriAPI.Models
{
    public class PositionModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal RawPrice { get; set; }
        public decimal RetailPrice { get; set; }
        public decimal PositionVolume { get; set; }
        public int PositionCategoryId { get; set; }
    }
}
