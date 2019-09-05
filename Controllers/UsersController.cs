using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore; 
using DotnetCoreStarter.API.Data;
using Microsoft.AspNetCore.Authorization;

namespace DotnetCoreStarter.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly DataContext _context;
        public UsersController(DataContext context)
        {
            _context = context;
        }
        // GET api/users
        [HttpGet]
        public async Task<IActionResult> GetValues()
        {
            var users  = await _context.Users
                .Include(u => u.Profile.PersonnalDetails)
                .Include(u => u.Profile.Contact)
                .ToListAsync();
            return Ok(users);
        }

        // GET api/users/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetValue(int id)
        {
            var user = await _context.Users
            .Include(u => u.Profile.PersonnalDetails)
            .Include(u => u.Profile.Contact)
            .FirstOrDefaultAsync(x => x.Id == id);
            return Ok(user);
        }

        // POST api/users
        [HttpPost]
        public void Post([FromBody] string user)
        {
        }

        // PUT api/users/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string user)
        {
        }

        // DELETE api/users/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
