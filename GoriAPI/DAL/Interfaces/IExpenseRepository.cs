using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IExpenseRepository<T>
    {
        Task<IEnumerable<T>> ReadAllExpenses();
        Task CreateExpense(T model);
    }
}
