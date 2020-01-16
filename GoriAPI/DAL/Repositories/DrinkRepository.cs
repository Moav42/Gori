using DAL.EF;
using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class DrinkRepository : IDrinkRepository<Drink>
    {
        private readonly Context _context;
        public DrinkRepository(Context context)
        {
            _context = context;
        }

        public async Task CreateDrinkAsync(Drink item)
        {
            await _context.Drinks.AddAsync(item);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Drink>> ReadAllDrinksAsync()
        {
            var items = await Task.Run(() => _context.Drinks);
            return items;
        }

        public async Task<Drink> ReadDrinkAsync(int id)
        {
            var item = await _context.Drinks.FindAsync(id);
            return item;
        }

        public async Task UpdateDrinkAsync(Drink item)
        {
            _context.Drinks.Update(item);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteDrinkAsync(int id)
        {
            var item = await _context.Drinks.FindAsync(id);
            if (item != null)
            {
                _context.Drinks.Remove(item);
                await _context.SaveChangesAsync();
            }
        }
    }
}
