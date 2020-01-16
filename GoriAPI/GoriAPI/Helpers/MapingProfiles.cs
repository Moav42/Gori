using AutoMapper;
using DAL.Entities;
using GoriAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoriAPI.Helpers
{
    public class MapingProfiles : Profile
    {
        public MapingProfiles()
        {
            CreateMap<Cashbox, CashboxModel>();
            CreateMap<CashboxModel, Cashbox>();

            CreateMap<DrinkModel, Drink>();
            CreateMap<Drink, DrinkModel>();

            CreateMap<DrinkCategoryModel, DrinkCategory>();
            CreateMap<DrinkCategory, DrinkCategoryModel>();

            CreateMap<ExpenseModel, Expense>();
            CreateMap<Expense, ExpenseModel>();

            CreateMap<IncomeModel, Income>();
            CreateMap<Income, IncomeModel>();

            CreateMap<PositionModel, Position>();
            CreateMap<Position, PositionModel>();

            CreateMap<PositionCategoryModel, PositionCategory>();
            CreateMap<PositionCategory, PositionCategoryModel>();

            CreateMap<PositionIngredientsModel, PositionIngredients>();
            CreateMap<PositionIngredients, PositionIngredientsModel>();

            CreateMap<SalesModel, Sales>();
            CreateMap<Sales, SalesModel>();

        }
    }
}
