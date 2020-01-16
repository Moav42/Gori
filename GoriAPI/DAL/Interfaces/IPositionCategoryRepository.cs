using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IPositionCategoryRepository<T>
    {
        Task CreatePositionCategoryAsync(T item);
        Task<IEnumerable<T>> ReadAllPositionCategoriesAsync();
        Task<T> ReadPositionCategoryAsync(int id);
        Task UpdatePositionCategoryAsync(T item);
        Task DeletePositionCategoryAsync(int id);
    }
}
