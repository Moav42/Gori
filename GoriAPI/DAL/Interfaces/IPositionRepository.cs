using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IPositionRepository<T>
    {
        Task CreatePositionAsync(T item);
        Task<IEnumerable<T>> ReadAllPositionsAsync();
        Task<T> ReadPositionAsync(int id);
        Task UpdatePositionAsync(T item);
        Task DeletePositionAsync(int id);
    }
}
