using DAL.EF;
using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class CashboxRepository : ICashboxRepository<Cashbox>
    {
        private readonly Context _context;
        public CashboxRepository(Context context)
        {
            _context = context;
        }

        public async Task<Cashbox> GetCashbox()
        {
            var cashbox = await _context.Cashbox.FindAsync(1);
            return cashbox;
        }

        public async Task UpdateCashbox(Cashbox item)
        {
            _context.Cashbox.Update(item);
            await _context.SaveChangesAsync();
        }
    }
}
