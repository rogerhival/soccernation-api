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
    public class ResultRowsController : BaseController<ResultRow>
    {
        public ResultRowsController(IApplicationRepository<ResultRow> repository, SoccernationContext context) : base(repository, context)
        {
        }

        [HttpGet]
        [Route("competition/{competitionId}")]
        public IActionResult GetByCompetition(Guid competitionId)
        {
            var competition = Context.Competitions.Include(o => o.Results).FirstOrDefault(o => o.Id == competitionId);
            if (competition == null)
                return BadRequest();

            return Ok(competition.Results.OrderBy(r=>r.Position));
        }

        [HttpPost]
        [Route("competition/{competitionId}")]
        public async Task<IActionResult> AddResultInCompetition([FromBody] ResultRow resultRow, Guid competitionId)
        {
            var competition = Context.Competitions.Include(o => o.Results).FirstOrDefault(o => o.Id == competitionId);
            if (competition == null)
                return BadRequest();

            competition.Results.Add(resultRow);
            if (await Context.SaveChangesAsync() == 0)
                return BadRequest();

            return NoContent();
        }

    }
}