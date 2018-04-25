using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Soccernation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Soccernation.Controllers
{
    [Route("api/[controller]")]
    public abstract class BaseController<T> : Controller where T : class, IEntity
    {
        readonly IApplicationRepository<T> _repository;
        public SoccernationContext Context;

        public BaseController(IApplicationRepository<T> repository, SoccernationContext context)
        {
            Context = context;
            _repository = repository;
            //Make sure any class that calls the controller, the database is created
            Context.Database.EnsureCreated();
        }

        [HttpGet]
        public IActionResult Query()
        {
            return Ok(_repository.Get());
        }

        [HttpGet("{id}")]
        public IActionResult Find(Guid id)
        {
            var record = _repository.Get(id);
            if (record == null)
                return NotFound();

            return new ObjectResult(record);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] T record)
        {
            _repository.Create(record);
            if (await _repository.SaveAsync() == 0)
                return BadRequest();

            return Ok(record);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] T record)
        {
            if (id != record.Id)
                return BadRequest();

            _repository.Update(record);
            if (await _repository.SaveAsync() == 0)
                return BadRequest();

            return new ObjectResult(record);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            _repository.Delete(id);
            if (await _repository.SaveAsync() == 0)
                return BadRequest();

            return NoContent();
        }

        [HttpPost("addRange")]
        public async Task<IActionResult> AddRange([FromBody] List<T> records)
        {
            foreach (var record in records)
            {
                _repository.Create(record);
                if (await _repository.SaveAsync() == 0)
                    return BadRequest();
            }
            return NoContent();
        }
    }
}
