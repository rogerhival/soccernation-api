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
    public class PlayersController : BaseController<Player>
    {
        public PlayersController(IApplicationRepository<Player> repository, SoccernationContext context) : base(repository, context)
        {
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