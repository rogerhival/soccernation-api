using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Soccernation.Models;

namespace Soccernation.Controllers
{
    [Produces("application/json")]
    public class CourtsController : BaseController<Court>
    {
        readonly IApplicationRepository<Court> _repo;
        readonly SoccernationContext _context;

        public CourtsController(IApplicationRepository<Court> repository, SoccernationContext context) : base(repository, context)
        {
            _repo = repository;
            _context = context;
        }

        public override IEnumerable<Court> Get()
        {
            return _context.Courts.ToList();
        }

        public override Court GetById(Guid id)
        {
            return _context.Courts.FirstOrDefault(c => c.Id == id);
        }
    }
}