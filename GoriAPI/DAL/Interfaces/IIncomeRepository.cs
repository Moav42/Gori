using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IIncomeRepository<T>
    {
        Task<IEnumerable<T>> ReadAllIncomes();
        Task CreateIncome(T model);
        
    }
}
