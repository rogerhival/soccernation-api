using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Soccernation.Models;

namespace Soccernation.Controllers
{
    [Produces("application/json")]
    public class TeamsController : BaseController<Team>
    {
        IApplicationRepository<Team> _repo;
        SoccernationContext _context;

        public TeamsController(IApplicationRepository<Team> repository, SoccernationContext context) : base(repository, context)
        {
            _repo = repository;
            _context = context;
        }

        [HttpPost]
        [Route("{teamId}/player")]
        public async Task<IActionResult> AddPlayer([FromBody] Player player, Guid teamId)
        {
            GetById(teamId).Players.Add(player);

            if (await _repo.SaveAsync() == 0)
                return BadRequest();

            return NoContent();
        }

        public override IEnumerable<Team> Get()
        {
            return _context.Teams
                .Include(t => t.Players)
                .ToList();
        }

        public override Team GetById(Guid id)
        {
            return _context.Teams
               .Include(t => t.Players)
               .FirstOrDefault(t => t.Id == id);
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
            return Ok(GetById(teamId).Players);
        }
    }
}