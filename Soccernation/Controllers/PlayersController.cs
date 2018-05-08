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
    public class PlayersController : BaseController<Player>
    {
        IApplicationRepository<Player> _repo;
        SoccernationContext _context;

        public PlayersController(IApplicationRepository<Player> repository, SoccernationContext context) : base(repository, context)
        {
            _repo = repository;
            _context = context;
        }

        public override IEnumerable<Player> Get()
        {
            return _context.Players.ToList();
        }

        public override Player GetById(Guid id)
        {
            return _context.Players.FirstOrDefault(p => p.Id == id);
        }

        [Route("{playerId}/teams")]
        [HttpGet]
        public IActionResult GetTeams(Guid playerId)
        {
            var teams = Context.Teams.Where(t => t.Players.FirstOrDefault(p => p.Id == playerId) != null);
            if (teams == null)
                return BadRequest();

            return Ok(teams);
        }
    }
}