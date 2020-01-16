using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.EF
{
    public class Context : DbContext
    {
        public DbSet<Drink> Drinks { get; set; }
        public DbSet<DrinkCategory> DrinkCategories { get; set; }
        public DbSet<PositionCategory> PositionCategories { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<PositionIngredients> PositionIngredients { get; set; }
        public DbSet<Sales> Sales { get; set; }
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<Income> Incomes { get; set; }
        public DbSet<Cashbox> Cashbox { get; set; }

        public Context()
        {

        }
        public Context(DbContextOptions<Context> options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<PositionIngredients>().HasKey(c => new { c.DrinkId, c.PositionId });

            base.OnModelCreating(builder);
        }
    }
}
