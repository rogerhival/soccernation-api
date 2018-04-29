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
    public class ManagersController : BaseController<Manager>
    {
        public ManagersController(IApplicationRepository<Manager> repository, SoccernationContext context) : base(repository, context)
        {
        }
    }
}