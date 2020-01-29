using DAL.EF;
using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class IncomeRepository : IIncomeRepository<Income>
    {
        private readonly Context _context;
        public IncomeRepository(Context context)
        {
            _context = context;
        }
        public async Task CreateIncome(Income item)
        {
            item.Date = DateTime.Now;

            await _context.Incomes.AddAsync(item);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Income>> ReadAllIncomes()
        {
            var items = await Task.Run(() => _context.Incomes);
            return items;
        }
    }
}
