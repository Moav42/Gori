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
    public class DrinkCategoriesController : ControllerBase
    {
        private readonly IDrinkCategoryRepository<DrinkCategory> _repo;
        private readonly IMapper _mapper;

        public DrinkCategoriesController(IDrinkCategoryRepository<DrinkCategory> repository, IMapper mapper)
        {
            _repo = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DrinkCategoryModel>>> GetAllDrinkCategories()
        {
            var itemsDAL = await _repo.ReadAllDrinkCategoriesAsync();
            var models = new List<DrinkCategoryModel>();
            foreach (var item in itemsDAL)
            {
                models.Add(_mapper.Map<DrinkCategoryModel>(item));
            }
            return Ok(models);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DrinkCategoryModel>> GetDrinkCategory(int id)
        {
            var itemsDAL = await _repo.ReadDrinkCategoyAsync(id);
            var model = _mapper.Map<DrinkCategoryModel>(itemsDAL);

            return Ok(model);
        }

        [HttpPost]
        public async Task<ActionResult<DrinkCategoryModel>> CreateDrinkCategory(DrinkCategoryModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _repo.CreateDrinkCategoryAsync(_mapper.Map<DrinkCategory>(model));

            return CreatedAtAction(nameof(GetDrinkCategory), new { id = model.Id }, model);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<DrinkCategoryModel>> UpdateDrinkCategory(int id, DrinkCategoryModel model)
        {

            if (ModelState.IsValid)
            {
                if (id != model.Id)
                {
                    return BadRequest("Model id wrong");
                }

                try
                {
                    await _repo.UpdateDrinkCategoryAsync(_mapper.Map<DrinkCategory>(model));
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (await _repo.ReadDrinkCategoyAsync(id) == null)
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
        public async Task<ActionResult> DeleteDrinkCategory(int id)
        {
            var model = await _repo.ReadDrinkCategoyAsync(id);
            if (model == null)
            {
                return NotFound();
            }

            await _repo.DeleteDrinkCategoryAsync(id);

            return NoContent();
        }
    }
}