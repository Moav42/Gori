using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IPositionIngredientsRepository<T>
    {
        Task CreatePositionIngredientsAsync(T item);
        Task<IEnumerable<T>> ReadAllPositionIngredientsAsync(int posotionId);
        Task UpdatePositionIngredientsAsync(T item);
        Task DeletePositionIngredientsAsync(int positionId, int drinkId);
    }
}
