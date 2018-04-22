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
            Context.AddRange(Dummies.Teams);
            Context.SaveChanges();
        }

        [HttpPost]
        public IActionResult AddPlayer([FromBody] Player player, Guid teamId)
        {
            _repo.Get(teamId).Players.Add(player);
            Context.SaveChanges();

            return CreatedAtRoute("/", player);
        }
    }
}