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
    public class RefereesController : BaseController<Referee>
    {
        IApplicationRepository<Referee> _repo;
        SoccernationContext _context;

        public RefereesController(IApplicationRepository<Referee> repository, SoccernationContext context) : base(repository, context)
        {
            _repo = repository;
            _context = context;
        }

        public override IEnumerable<Referee> Get()
        {
            return _context.Referees.ToList();                
                
        }

        public override Referee GetById(Guid id)
        {
            return _context.Referees.FirstOrDefault(r => r.Id == id);
        }
    }
}