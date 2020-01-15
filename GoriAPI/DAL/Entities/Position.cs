using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DAL.Entities
{
    public class Position
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal RawPrice { get; set; }
        public decimal RetailPrice { get; set; }
        public decimal PositionVolume { get; set; }
        public PositionCategory PositionCategory { get; set; }
        public List<PositionIngredients> PositionIngredients { get; set; }
        public List<Sales> Sales { get; set; }
    }
}
