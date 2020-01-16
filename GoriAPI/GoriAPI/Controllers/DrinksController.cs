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
using Microsoft.EntityFrameworkCore;

namespace GoriAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DrinksController : ControllerBase
    {
        private readonly IDrinkRepository<Drink> _repo;
        private readonly IMapper _mapper;

        public DrinksController(IDrinkRepository<Drink> repository, IMapper mapper)
        {
            _repo = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DrinkModel>>> GetAllDrinks()
        {
            var itemsDAL = await _repo.ReadAllDrinksAsync();
            var models = new List<DrinkModel>();
            foreach (var item in itemsDAL)
            {
                models.Add(_mapper.Map<DrinkModel>(item));
            }
            return Ok(models);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DrinkModel>> GetDrink(int id)
        {
            var itemsDAL = await _repo.ReadDrinkAsync(id);
            var model = _mapper.Map<DrinkModel>(itemsDAL);

            return Ok(model);
        }

        [HttpPost]
        public async Task<ActionResult<DrinkModel>> CreateDrink(DrinkModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _repo.CreateDrinkAsync(_mapper.Map<Drink>(model));

            return CreatedAtAction(nameof(GetDrink), new { id = model.Id }, model);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<DrinkModel>> UpdateDrink(int id, DrinkModel model)
        {

            if (ModelState.IsValid)
            {
                if (id != model.Id)
                {
                    return BadRequest("Model id wrong");
                }

                try
                {
                    await _repo.UpdateDrinkAsync(_mapper.Map<Drink>(model));
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (await _repo.ReadDrinkAsync(id) == null)
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return Ok(model);
            }
            return BadRequest(ModelState);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteDrink(int id)
        {
            var model = await _repo.ReadDrinkAsync(id);
            if (model == null)
            {
                return NotFound();
            }

            await _repo.DeleteDrinkAsync(id);

            return NoContent();
        }
    }
}