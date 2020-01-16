using DAL.EF;
using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class PositionCategoryRepository : IPositionCategoryRepository<PositionCategory>
    {
        private readonly Context _context;
        public PositionCategoryRepository(Context context)
        {
            _context = context;
        }

        public async Task CreatePositionCategoryAsync(PositionCategory item)
        {
            await _context.PositionCategories.AddAsync(item);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<PositionCategory>> ReadAllPositionCategoriesAsync()
        {
            var items = await Task.Run(() => _context.PositionCategories);
            return items;
        }

        public async Task<PositionCategory> ReadPositionCategoryAsync(int id)
        {
            var item = await _context.PositionCategories.FindAsync(id);
            return item;
        }

        public async Task UpdatePositionCategoryAsync(PositionCategory item)
        {
            _context.PositionCategories.Update(item);
            await _context.SaveChangesAsync();
        }

        public async Task DeletePositionCategoryAsync(int id)
        {
            var item = await _context.PositionCategories.FindAsync(id);
            if (item != null)
            {
                _context.PositionCategories.Remove(item);
                await _context.SaveChangesAsync();
            }
        }
    }
}
