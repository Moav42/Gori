
using DAL.Entities;
using DAL.Repositories;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GoriAPI.Interfaces;
using GoriAPI.Services;

namespace GoriAPI.Extensions
{
    public static class DiExtensions
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<ICashboxRepository<Cashbox>, CashboxRepository>();
            services.AddScoped<IDrinkCategoryRepository<DrinkCategory>, DrinkCategoryRepository>();
            services.AddScoped<IDrinkRepository<Drink>, DrinkRepository>();
            services.AddScoped<IExpenseRepository<Expense>, ExpenseRepository>();
            services.AddScoped<IIncomeRepository<Income>, IncomeRepository>();
            services.AddScoped<IPositionCategoryRepository<PositionCategory>, PositionCategoryRepository>();
            services.AddScoped<IPositionIngredientsRepository<PositionIngredients>, PositionIngredientsRepository>();
            services.AddScoped<IPositionRepository<Position>, PositionRepository>();
            services.AddScoped<ISalesRepository<Sales>, SalesRepository>();

            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<ISalesManager, SalesManager>();

            return services;
        }

    }
}
