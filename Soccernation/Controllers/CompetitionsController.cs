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
    public class CompetitionsController : BaseController<Competition>
    {
        public CompetitionsController(IApplicationRepository<Competition> repository, SoccernationContext context) : base(repository, context)
        {
            Context.AddRange(Dummies.Competitions);
            Context.SaveChanges();
        }

        [HttpGet]
        [Route("{competitionId}/teams")]
        public IActionResult GetTeams(Guid competitionId)
        {
            var teams = Context.Competitions
                .Include(b => b.Fixtures)
                .Include(b => b.Teams)
                .FirstOrDefault(o => o.Id == competitionId).Teams;

            return Ok(teams);
        }

        //[HttpPost]
        //public IActionResult AddTeam([FromBody] Team team, Guid competitionId)
        //{

        //}
    }
}