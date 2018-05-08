using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Soccernation.Models;

namespace Soccernation.Controllers
{
    [Produces("application/json")]
    public class UsersController : BaseController<User>
    {
        IApplicationRepository<User> _repo;
        SoccernationContext _context;

        public UsersController(IApplicationRepository<User> repository, SoccernationContext context) : base(repository, context)
        {
            _repo = repository;
            _context = context;
        }

        [HttpPost]
        public override async Task<IActionResult> Create([FromBody] User record)
        {
            if (Context.Users.Where(o => o.Email == record.Email).Count() > 0)
                return BadRequest();

            using (var derivedBytes = new Rfc2898DeriveBytes(record.Password, 20))
            {
                var salt = derivedBytes.Salt;
                var key = derivedBytes.GetBytes(20);

                record.Key = key;
                record.KeySalt = salt;
            }

            record.LastTimeLoginUtc = DateTime.UtcNow;
            record.ExpireDateUtc = DateTime.UtcNow.AddYears(1);

            Context.Users.Add(record);
            if (await Context.SaveChangesAsync() == 0)
                return BadRequest();

            return Ok();
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginData login)
        {
            var user = Context.Users.FirstOrDefault(o => o.Email == login.Email);

            using (var derivedBytes = new Rfc2898DeriveBytes(login.Password, user.KeySalt))
            {
                var newKey = derivedBytes.GetBytes(20);

                if (!newKey.SequenceEqual(user.Key))
                    return BadRequest();
            }
            user.LastTimeLoginUtc = DateTime.UtcNow;
            if (await Context.SaveChangesAsync() == 0)
                return BadRequest();

            return new ObjectResult(user);
        }

        public override IEnumerable<User> Get()
        {
            return _context.Users
                .Include(u => u.Company)
                .Include(u => u.Manager)
                .Include(u => u.Player)
                .ToList();
        }

        public override User GetById(Guid id)
        {
            return _context.Users
                .Include(u => u.Company)
                .Include(u => u.Manager)
                .Include(u => u.Player)
                .FirstOrDefault(u=>u.Id == id);
        }
    }
}