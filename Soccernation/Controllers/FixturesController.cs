using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Soccernation.Models;

namespace Soccernation.Controllers
{
    [Produces("application/json")]
    public class FixturesController : BaseController<Fixture>
    {
        IApplicationRepository<Fixture> _repo;
        SoccernationContext _context;

        public FixturesController(IApplicationRepository<Fixture> repository, SoccernationContext context) : base(repository, context)
        {
            _repo = repository;
            _context = context;
        }

        [HttpGet]
        [Route("team/{teamId}/competition/{competitionId}")]
        public IActionResult GetFixturesOfATeamInACompetition(Guid teamId, Guid competitionId)
        {
            var competition = Context.Competitions
                            .Include(a => a.Fixtures)
                            .FirstOrDefault(b => b.Id == competitionId);
            if (competition == null)
                return BadRequest();

            var team = Context.Teams.FirstOrDefault(o => o.Id == teamId);
            if (team == null)
                return BadRequest();

            var fixtures = competition.Fixtures.Where(o => o.TeamHome == team || o.TeamVisitor == team).OrderBy(o => o.DateUtc).ThenBy(o => o.Round);
            if (fixtures == null)
                return BadRequest();

            return Ok(fixtures);
        }

        [HttpGet]
        [Route("team/{teamId}")]
        public IActionResult GetByTeam(Guid teamId)
        {
            var team = Context.Teams.FirstOrDefault(o => o.Id == teamId);
            if (team == null)
                return BadRequest();

            var fixtures = Context.Fixtures.Where(o => o.TeamHome == team || o.TeamVisitor == team).OrderBy(o => o.DateUtc).ThenBy(o => o.Round);
            if (fixtures == null)
                return BadRequest();

            return Ok(fixtures);
        }

        [HttpGet]
        [Route("player/{playerId}")]
        public IActionResult GetByPlayer(Guid playerId)
        {
            var player = Context.Players.FirstOrDefault(p => p.Id == playerId);
            if (player == null)
                return BadRequest();

            var teams = Context.Teams.Where(o => o.Players.Contains(player));
            if (teams == null)
                return BadRequest();

            var fixtures = Context.Fixtures.Where(o => teams.Any(t => t == o.TeamHome || t == o.TeamVisitor)).OrderBy(o => o.DateUtc).ThenBy(o => o.Round);
            if (fixtures == null)
                return BadRequest();

            return Ok(fixtures);
        }

        public override IEnumerable<Fixture> Get()
        {
            return _context.Fixtures
                 .Include(f => f.TeamHome)
                 .Include(f => f.TeamVisitor)
                 .ToList();
        }

        public override Fixture GetById(Guid id)
        {
            return _context.Fixtures
                .Include(f => f.TeamHome)
                .Include(f => f.TeamVisitor)
                .FirstOrDefault(f => f.Id == id);
        }
    }
}