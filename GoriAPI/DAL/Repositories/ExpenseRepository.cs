using DAL.EF;
using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class ExpenseRepository : IExpenseRepository<Expense>
    {
        private readonly Context _context;
        public ExpenseRepository(Context context)
        {
            _context = context;
        }
        public async Task CreateExpense(Expense item)
        {
            item.Date = DateTime.Now;

            await _context.Expenses.AddAsync(item);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Expense>> ReadAllExpenses()
        {
            var items = await Task.Run(() => _context.Expenses);
            return items;
        }
    }
}
