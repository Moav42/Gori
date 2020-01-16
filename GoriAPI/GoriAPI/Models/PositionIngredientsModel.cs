using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GoriAPI.Models
{
    public class PositionIngredientsModel
    {
        [Required]
        public int PositionId { get; set; }
        [Required]
        public int DrinkId { get; set; }
        [Required]
        public decimal Volume { get; set; }
    }
}
