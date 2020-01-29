using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DAL.Entities;
using DAL.Interfaces;
using GoriAPI.Interfaces;
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
        private readonly ISalesManager _salesManager;

        public SalesController(ISalesRepository<Sales> repository, IMapper mapper, IPositionRepository<Position> positionRepo, IPositionIngredientsRepository<PositionIngredients> ingridientsRepo, IDrinkRepository<Drink> drinksRepo, ISalesManager salesManager)
        {
            _salesRepo = repository;
            _mapper = mapper;
            _positionRepo = positionRepo;
            _ingredientsRepo = ingridientsRepo;
            _drinksRepo = drinksRepo;
            _salesManager = salesManager;
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
            await _salesManager.ConfigureSale(model);
            await _salesManager.UpdateDrinksActulalVolume(model);

            await _salesRepo.CreateSalesAsync(_mapper.Map<Sales>(model));

            return CreatedAtAction(nameof(GetSale), new { id = model.Id }, model);
        }

        [HttpPut("{id}/paid")]
        public async Task<ActionResult> MakeSalePaid(int id)
        {
            var res = await _salesRepo.MakeSalePaidAsync(id);

            if(res == true)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
       
    }
}