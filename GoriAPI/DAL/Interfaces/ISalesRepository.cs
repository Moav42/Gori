using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface ISalesRepository<T>
    {
        Task CreateSalesAsync(T item);
        Task<IEnumerable<T>> ReadAllSalesAsync();
        Task<T> ReadSalesAsync(int id);
        Task<bool> MakeSalePaidAsync(int id);
    }
}
