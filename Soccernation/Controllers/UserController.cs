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
    [Route("api/Users")]
    public class UsersController : BaseController<User>
    {
        IApplicationRepository<User> _context;

        public UsersController(IApplicationRepository<User> context) : base(context)
        {
            _context = context;
        }
    }
}