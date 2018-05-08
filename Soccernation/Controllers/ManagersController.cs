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
    public class ManagersController : BaseController<Manager>
    {
        IApplicationRepository<Manager> _repo;
        SoccernationContext _context;

        public ManagersController(IApplicationRepository<Manager> repository, SoccernationContext context) : base(repository, context)
        {
            _repo = repository;
            _context = context;
        }

        public override IEnumerable<Manager> Get()
        {
            return _context.Managers.ToList();
        }

        public override Manager GetById(Guid id)
        {
            return _context.Managers.FirstOrDefault(m => m.Id == id);
        }
    }
}