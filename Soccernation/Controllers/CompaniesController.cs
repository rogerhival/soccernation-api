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
    public class CompaniesController : BaseController<Company>
    {
        public CompaniesController(IApplicationRepository<Company> repository, SoccernationContext context) : base(repository, context)
        {
        }
    }
}