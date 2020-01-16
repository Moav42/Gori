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
    public class PositionCategoriesController : ControllerBase
    {
        private readonly IPositionCategoryRepository<PositionCategory> _repo;
        private readonly IMapper _mapper;

        public PositionCategoriesController(IPositionCategoryRepository<PositionCategory> repository, IMapper mapper)
        {
            _repo = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PositionCategoryModel>>> GetAllPositionCategories()
        {
            var itemsDAL = await _repo.ReadAllPositionCategoriesAsync();
            var models = new List<PositionCategoryModel>();
            foreach (var item in itemsDAL)
            {
                models.Add(_mapper.Map<PositionCategoryModel>(item));
            }
            return Ok(models);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PositionCategoryModel>> GetPositionCategory(int id)
        {
            var itemsDAL = await _repo.ReadPositionCategoryAsync(id);
            var model = _mapper.Map<PositionCategoryModel>(itemsDAL);

            return Ok(model);
        }

        [HttpPost]
        public async Task<ActionResult<PositionCategoryModel>> CreatePositionCategory(PositionCategoryModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _repo.CreatePositionCategoryAsync(_mapper.Map<PositionCategory>(model));

            return CreatedAtAction(nameof(GetPositionCategory), new { id = model.Id }, model);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<PositionCategoryModel>> UpdatePositionCategory(int id, PositionCategoryModel model)
        {

            if (ModelState.IsValid)
            {
                if (id != model.Id)
                {
                    return BadRequest("Model id wrong");
                }

                try
                {
                    await _repo.UpdatePositionCategoryAsync(_mapper.Map<PositionCategory>(model));
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (await _repo.ReadPositionCategoryAsync(id) == null)
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
        public async Task<ActionResult> DeletePositionCategory(int id)
        {
            var model = await _repo.ReadPositionCategoryAsync(id);
            if (model == null)
            {
                return NotFound();
            }

            await _repo.DeletePositionCategoryAsync(id);

            return NoContent();
        }
    }
}