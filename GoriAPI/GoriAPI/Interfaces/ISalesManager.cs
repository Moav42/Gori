using GoriAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoriAPI.Interfaces
{
    public interface ISalesManager
    {
        Task ConfigureSale(SalesModel model);
        Task UpdateDrinksActulalVolume(SalesModel model);

    }
}
