using DAL.EF;
using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class SalesRepository : ISalesRepository<Sales>
    {
        private readonly Context _context;
        public SalesRepository(Context context)
        {
            _context = context;
        }

        public async Task CreateSalesAsync(Sales item)
        {
            await _context.Sales.AddAsync(item);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Sales>> ReadAllSalesAsync()
        {
            var items = await Task.Run(() => _context.Sales);
            return items;
        }

        public async Task<Sales> ReadSalesAsync(int id)
        {
            var item = await _context.Sales.FindAsync(id);
            return item;
        }

        public async Task<bool> MakeSalePaidAsync(int id)
        {
            var item = await ReadSalesAsync(id);
            item.Paid = true;

            _context.Sales.Update(item);
            var result = await _context.SaveChangesAsync();

            if(result != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
