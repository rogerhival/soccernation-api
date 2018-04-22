﻿using Microsoft.AspNetCore.Mvc;
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

            return CreatedAtAction("Find", record);
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
    }
}