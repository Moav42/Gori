using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IDrinkCategoryRepository<T>
    {
        Task CreateDrinkCategoryAsync(T item);
        Task<IEnumerable<T>> ReadAllDrinkCategoriesAsync();
        Task<T> ReadDrinkCategoyAsync(int id);
        Task UpdateDrinkCategoryAsync(T item);
        Task DeleteDrinkCategoryAsync(int id);

    }
}
