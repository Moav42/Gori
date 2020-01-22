using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DAL.Entities;
using DAL.Interfaces;
using GoriAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GoriAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ISalesRepository<Sales> _salesRepo;
        private readonly IPositionRepository<Position> _positionRepo;
        private readonly IPositionIngredientsRepository<PositionIngredients> _ingredientsRepo;
        private readonly IDrinkRepository<Drink> _drinksRepo;

        public SalesController(ISalesRepository<Sales> repository, IMapper mapper, IPositionRepository<Position> positionRepo, IPositionIngredientsRepository<PositionIngredients> ingridientsRepo, IDrinkRepository<Drink> drinksRepo)
        {
            _salesRepo = repository;
            _mapper = mapper;
            _positionRepo = positionRepo;
            _ingredientsRepo = ingridientsRepo;
            _drinksRepo = drinksRepo;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SalesModel>>> GetAllSales()
        {
            var itemsDAL = await _salesRepo.ReadAllSalesAsync();
            var models = new List<SalesModel>();
            foreach (var item in itemsDAL)
            {
                models.Add(_mapper.Map<SalesModel>(item));
            }
            return Ok(models);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SalesModel>> GetSale(int id)
        {
            var itemsDAL = await _salesRepo.ReadSalesAsync(id);
            var model = _mapper.Map<SalesModel>(itemsDAL);

            return Ok(model);
        }

        [HttpPost]
        public async Task<ActionResult<SalesModel>> CreateSale(SalesModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await ConfigureSale(model);
            await UpdateDrinksActulalVolume(model);

            await _salesRepo.CreateSalesAsync(_mapper.Map<Sales>(model));

            return CreatedAtAction(nameof(GetSale), new { id = model.Id }, model);
        }


        private async Task ConfigureSale(SalesModel model)
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

        private async Task UpdateDrinksActulalVolume(SalesModel model)
        {
            var ingredients = await _ingredientsRepo.ReadAllPositionIngredientsAsync(model.PositionId);

            var ingredientsList = ingredients.ToList();
            var drinksList = new List<Drink>();

            foreach (var ingredient in ingredients)
            {
                drinksList.Add(await _drinksRepo.ReadDrinkAsync(ingredient.DrinkId));
            }

            if(ingredientsList.Count == drinksList.Count)
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