using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DAL.Entities
{
    public class PositionIngredients
    {
        [Required]
        public int PositionId { get; set; }
        [Required]
        public int DrinkId { get; set; }
        [Required]
        public decimal Volume { get; set; }
        public Position Position { get; set; }
        public Drink Drink { get; set; }
    }
}
