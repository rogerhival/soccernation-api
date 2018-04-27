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
    public class TeamsController : BaseController<Team>
    {
        IApplicationRepository<Team> _repo;

        public TeamsController(IApplicationRepository<Team> repository, SoccernationContext context) : base(repository, context)
        {
            _repo = repository;
        }

        [HttpPost]
        [Route("{teamId}/player")]
        public async Task<IActionResult> AddPlayer([FromBody] Player player, Guid teamId)
        {
            _repo.Get(teamId).Players.Add(player);

            if (await _repo.SaveAsync() == 0)
                return BadRequest();

            return NoContent();
        }

        [HttpGet]
        [Route("{teamId}/competitions")]
        public IActionResult GetCompetitions(Guid teamId)
        {
            var competitions = Context.CompetitionsTeams.Where(o => o.Team.Id == teamId).Select(t => t.Competition);

            if (competitions == null)
                return BadRequest();

            return Ok(competitions);
        }

        [HttpGet]
        [Route("{teamId}/players")]
        public IActionResult GetPlayers(Guid teamId)
        {
            return Ok(_repo.Get(teamId).Players); //TODO: test if it works
        }
    }
}