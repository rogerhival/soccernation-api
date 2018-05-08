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
    public class CompaniesController : BaseController<Company>
    {
        readonly IApplicationRepository<Company> _repo;
        readonly SoccernationContext _context;

        public CompaniesController(IApplicationRepository<Company> repository, SoccernationContext context) : base(repository, context)
        {
            _repo = repository;
            _context = context;
        }

        public override IEnumerable<Company> Get()
        {
            return _context.Companies
                .Include(c => c.Competitions)
                .ToList();
        }

        public override Company GetById(Guid id)
        {
            return _context.Companies
                .Include(c => c.Competitions)
                .FirstOrDefault(c => c.Id == id);
        }
    }
}