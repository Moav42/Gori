using DAL.EF;
using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class PositionIngredientsRepository : IPositionIngredientsRepository<PositionIngredients>
    {
        private readonly Context _context;
        public PositionIngredientsRepository(Context context)
        {
            _context = context;
        }

        public async Task CreatePositionIngredientsAsync(PositionIngredients item)
        {
            await _context.PositionIngredients.AddAsync(item);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<PositionIngredients>> ReadAllPositionIngredientsAsync(int positionId)
        {
            var items = await Task.Run(() => _context.PositionIngredients.Where(p => p.PositionId == positionId));
            return items;
        }

        public async Task UpdatePositionIngredientsAsync(PositionIngredients item)
        {
            _context.PositionIngredients.Update(item);
            await _context.SaveChangesAsync();
        }

        public async Task DeletePositionIngredientsAsync(int positionId, int drinkId)
        {
            var item = await Task.Run(() => _context.PositionIngredients.Where(p => p.PositionId == positionId && p.DrinkId == drinkId).SingleOrDefault());
            if (item != null)
            {
                _context.PositionIngredients.Remove(item);
                await _context.SaveChangesAsync();
            }
        }
    }
}
