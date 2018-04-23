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

        [HttpPost]
        [Route("{competitionId}/team/{teamId}")]
        public IActionResult AddTeam(Guid teamId, Guid competitionId)
        {
            var competition = Context.Competitions
                .Include(c=>c.Teams)
                .FirstOrDefault(c => c.Id == competitionId);

            if (competition == null)
                return BadRequest();

            //its adding all teams for now
            var teams = Context.Teams.ToList();
            if (teams == null)
                return BadRequest();

            competition.Teams.AddRange(teams);
            Context.SaveChanges();

            return Ok(competition);
        }
    }
}