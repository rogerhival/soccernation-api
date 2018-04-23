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
    public class FixturesController : BaseController<Fixture>
    {
        public FixturesController(IApplicationRepository<Fixture> repository, SoccernationContext context) : base(repository, context)
        {
            //Context.AddRange(Dummies.Fixtures);
            //Context.SaveChanges();
        }

        [HttpGet]
        [Route("team/{id}/competition/{competitionId}")]
        public IActionResult GetTeamInFixture(Guid id, Guid competitionId)
        {
            var fixtures = Context.Competitions
                            .Include(a => a.Teams)
                            .Include(a => a.Fixtures)
                            .FirstOrDefault(b => b.Id == competitionId && b.Teams.Where(c => c.Id == id) != null).Fixtures;

            return Ok(fixtures);
        }
    }
}