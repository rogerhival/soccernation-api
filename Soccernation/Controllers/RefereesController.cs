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
    public class RefereesController : BaseController<Referee>
    {
        public RefereesController(IApplicationRepository<Referee> repository, SoccernationContext context) : base(repository, context)
        {
        }
    }
}