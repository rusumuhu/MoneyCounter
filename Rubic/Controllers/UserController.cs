using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Rubic.DbContext;
using Rubic.Models;
using Rubic.Models.Dto;

namespace Rubic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public MoneyBotContext _context;

        public UserController(MoneyBotContext context)
        {
            _context = context;
        }

        [HttpPost("register")]
        public async Task<ActionResult> Register (UserIdentity userIdentity)
        {
            User user = new User() {
                PhoneNumberPrefix = userIdentity.PhoneNumberPrefix,
                PhoneNumber = userIdentity.PhoneNumber,
                Password = userIdentity.Password
            };
            _context.Users.Add(user);

            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpPost("Auth")]
        public async Task<ActionResult> Auth(UserIdentity userIdentity)
        {
            User user = await _context.Users.FirstOrDefaultAsync(
                u => u.PhoneNumberPrefix == userIdentity.PhoneNumberPrefix && 
                u.PhoneNumber == userIdentity.PhoneNumber && 
                u.Password == userIdentity.Password
                );

            if (user == null) return NotFound();

            return Ok();
        }

        [HttpPost("Get")]
        public async Task<User> Get(UserIdentity userIdentity)
        {
            User user = await _context.Users.FirstOrDefaultAsync(
                u => u.PhoneNumberPrefix == userIdentity.PhoneNumberPrefix &&
                u.PhoneNumber == userIdentity.PhoneNumber &&
                u.Password == userIdentity.Password
                );

            if (user == null) return NotFound();

            return user;
        }
    }
}
