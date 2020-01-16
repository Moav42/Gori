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
    public class PositionsController : ControllerBase
    {
        private readonly IPositionRepository<Position> _repo;
        private readonly IMapper _mapper;

        public PositionsController(IPositionRepository<Position> repository, IMapper mapper)
        {
            _repo = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Position>>> GetAllPositions()
        {
            var itemsDAL = await _repo.ReadAllPositionsAsync();
            var models = new List<PositionModel>();
            foreach (var item in itemsDAL)
            {
                models.Add(_mapper.Map<PositionModel>(item));
            }
            return Ok(models);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PositionModel>> GetPosition(int id)
        {
            var itemsDAL = await _repo.ReadPositionAsync(id);
            var model = _mapper.Map<PositionModel>(itemsDAL);

            return Ok(model);
        }

        [HttpPost]
        public async Task<ActionResult<PositionModel>> CreatePosition(PositionModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _repo.CreatePositionAsync(_mapper.Map<Position>(model));

            return CreatedAtAction(nameof(GetPosition), new { id = model.Id }, model);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<PositionModel>> UpdatePosition(int id, PositionModel model)
        {

            if (ModelState.IsValid)
            {
                if (id != model.Id)
                {
                    return BadRequest("Model id wrong");
                }

                try
                {
                    await _repo.UpdatePositionAsync(_mapper.Map<Position>(model));
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (await _repo.ReadPositionAsync(id) == null)
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
        public async Task<ActionResult> DeletePosition(int id)
        {
            var model = await _repo.ReadPositionAsync(id);
            if (model == null)
            {
                return NotFound();
            }

            await _repo.DeletePositionAsync(id);

            return NoContent();
        }
    }
}