using DAL.EF;
using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class DrinkCategoryRepository : IDrinkCategoryRepository<DrinkCategory>
    {
        private readonly Context _context;
        public DrinkCategoryRepository(Context context)
        {
            _context = context;
        }

        public async Task CreateDrinkCategoryAsync(DrinkCategory item)
        {
            await _context.DrinkCategories.AddAsync(item);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<DrinkCategory>> ReadAllDrinkCategoriesAsync()
        {
            var items = await Task.Run(() => _context.DrinkCategories);
            return items;
        }

        public async Task<DrinkCategory> ReadDrinkCategoyAsync(int id)
        {
            var item = await _context.DrinkCategories.FindAsync(id);
            return item;
        }

        public async Task UpdateDrinkCategoryAsync(DrinkCategory item)
        {
            _context.DrinkCategories.Update(item);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteDrinkCategoryAsync(int id)
        {
            var item = await _context.DrinkCategories.FindAsync(id);
            if (item != null)
            {
                _context.DrinkCategories.Remove(item);
                await _context.SaveChangesAsync();
            }
        }  
    }
}
