using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface ICashboxRepository<T>
    {
        Task<T> GetCashbox();
        Task UpdateCashbox(T model);
    }
}
