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
    public class PositionIngredientsController : ControllerBase
    {
        private readonly IPositionIngredientsRepository<PositionIngredients> _repo;
        private readonly IMapper _mapper;

        public PositionIngredientsController(IPositionIngredientsRepository<PositionIngredients> repository, IMapper mapper)
        {
            _repo = repository;
            _mapper = mapper;
        }

        [HttpGet("{positionId}")]
        public async Task<ActionResult<IEnumerable<PositionIngredients>>> GetAllPositionIngredients(int positionId)
        {
            var itemsDAL = await _repo.ReadAllPositionIngredientsAsync(positionId);
            var models = new List<PositionIngredientsModel>();
            foreach (var item in itemsDAL)
            {
                models.Add(_mapper.Map<PositionIngredientsModel>(item));
            }
            return Ok(models);
        }  

        [HttpPost("create")]
        public async Task<ActionResult<PositionIngredientsModel>> CreateDrink(PositionIngredientsModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _repo.CreatePositionIngredientsAsync(_mapper.Map<PositionIngredients>(model));

            return Ok(model);
        }

        [HttpPost("update")]
        public async Task<ActionResult<PositionIngredientsModel>> UpdateDrink(PositionIngredientsModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _repo.UpdatePositionIngredientsAsync(_mapper.Map<PositionIngredients>(model));
                }
                catch (DbUpdateConcurrencyException)
                {
                    return NotFound();
                }
                return Ok(model);
            }
            return BadRequest(ModelState);
        }

        [HttpPost("delete")]
        public async Task<ActionResult> DeleteDrink(PositionIngredientsModel model)
        {

            await _repo.DeletePositionIngredientsAsync(model.PositionId, model.DrinkId);

            return NoContent();
        }
    }
}