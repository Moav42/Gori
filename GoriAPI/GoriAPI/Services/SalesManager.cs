using AutoMapper;
using DAL.Entities;
using DAL.Interfaces;
using GoriAPI.Interfaces;
using GoriAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoriAPI.Services
{
    public class SalesManager : ISalesManager
    {
        private readonly IMapper _mapper;
        private readonly ISalesRepository<Sales> _salesRepo;
        private readonly IPositionRepository<Position> _positionRepo;
        private readonly IPositionIngredientsRepository<PositionIngredients> _ingredientsRepo;
        private readonly IDrinkRepository<Drink> _drinksRepo;

        public SalesManager(ISalesRepository<Sales> repository, IMapper mapper, IPositionRepository<Position> positionRepo, IPositionIngredientsRepository<PositionIngredients> ingridientsRepo, IDrinkRepository<Drink> drinksRepo)
        {
            _salesRepo = repository;
            _mapper = mapper;
            _positionRepo = positionRepo;
            _ingredientsRepo = ingridientsRepo;
            _drinksRepo = drinksRepo;
        }

        public async Task ConfigureSale(SalesModel model)
        {
            var currentPosition = await _positionRepo.ReadPositionAsync(model.PositionId);

            if (model.IsByRawPrice)
            {
                model.TotalPrice = currentPosition.RawPrice * model.Quantity;
            }
            else
            {
                model.TotalPrice = currentPosition.RetailPrice * model.Quantity;
            }
            model.TimeOfSale = DateTime.Now;
        }

        public async Task UpdateDrinksActulalVolume(SalesModel model)
        {
            var ingredients = await _ingredientsRepo.ReadAllPositionIngredientsAsync(model.PositionId);

            var ingredientsList = ingredients.ToList();
            var drinksList = new List<Drink>();

            foreach (var ingredient in ingredients)
            {
                drinksList.Add(await _drinksRepo.ReadDrinkAsync(ingredient.DrinkId));
            }

            if (ingredientsList.Count == drinksList.Count)
            {
                for (int i = 0; i < drinksList.Count; i++)
                {
                    drinksList[i].ActualVolume -= (ingredientsList[i].Volume / 1000) * model.Quantity;
                }
            }

            foreach (var drink in drinksList)
            {
                await _drinksRepo.UpdateDrinkAsync(drink);
            }
        }

    }
}
