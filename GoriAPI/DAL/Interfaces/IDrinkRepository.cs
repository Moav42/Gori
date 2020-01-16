using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IDrinkRepository<T>
    {
        Task CreateDrinkAsync(T item);
        Task<IEnumerable<T>> ReadAllDrinksAsync();
        Task<T> ReadDrinkAsync(int id);
        Task UpdateDrinkAsync(T item);
        Task DeleteDrinkAsync(int id);

    }
}
