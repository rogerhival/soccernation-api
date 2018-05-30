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

        public abstract IEnumerable<T> Get();

        public abstract T GetById(Guid id);

        [HttpGet]
        public IActionResult Query()
        {
            return Ok(Get());
        }

        [HttpGet("{id}")]
        public IActionResult Find(Guid id)
        {
            var record = GetById(id);
            if (record == null)
                return NotFound();

            return new ObjectResult(record);
        }

        [HttpPost]
        public virtual async Task<IActionResult> Create([FromBody] T record)
        {
            _repository.Create(record);
            if (await _repository.SaveAsync() == 0)
                return BadRequest();

            return Ok(record);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] T record)
        {
            try
            {
                if (id != record.Id)
                    return BadRequest();

                _repository.Update(record);
                if (await _repository.SaveAsync() == 0)
                    return BadRequest();

                return new ObjectResult(record);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
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
