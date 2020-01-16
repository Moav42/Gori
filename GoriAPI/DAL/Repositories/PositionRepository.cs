using DAL.EF;
using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class PositionRepository : IPositionRepository<Position>
    {
        private readonly Context _context;
        public PositionRepository(Context context)
        {
            _context = context;
        }

        public async Task CreatePositionAsync(Position item)
        {
            await _context.Positions.AddAsync(item);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Position>> ReadAllPositionsAsync()
        {
            var items = await Task.Run(() => _context.Positions);
            return items;
        }

        public async Task<Position> ReadPositionAsync(int id)
        {
            var item = await _context.Positions.FindAsync(id);
            return item;
        }

        public async Task UpdatePositionAsync(Position item)
        {
            _context.Positions.Update(item);
            await _context.SaveChangesAsync();
        }

        public async Task DeletePositionAsync(int id)
        {
            var item = await _context.Positions.FindAsync(id);
            if (item != null)
            {
                _context.Positions.Remove(item);
                await _context.SaveChangesAsync();
            }
        }
    }
}
