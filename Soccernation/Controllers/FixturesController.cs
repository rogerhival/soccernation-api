using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Soccernation.Models;

namespace Soccernation.Controllers
{
    [Produces("application/json")]
    public class FixturesController : BaseController<Fixture>
    {
        public FixturesController(IApplicationRepository<Fixture> repository, SoccernationContext context) : base(repository, context)
        {
            Context.AddRange(Dummies.Fixtures);
            Context.SaveChanges();
        }

        [HttpGet("{id}")]
        [Route("team")]
        public IActionResult GetTeamInFixture(Guid id)
        {
            Context.Fixtures.Add(new Fixture() { Id = Guid.NewGuid(), CreatedOn = DateTime.Today });
            Context.SaveChanges();

            return Ok(Context.Fixtures.First());
        }
    }
}