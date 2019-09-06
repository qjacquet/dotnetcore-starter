using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore; 
using DotnetCoreStarter.API.Data;
using Microsoft.AspNetCore.Authorization;
using DotnetCoreStarter.API.Models;

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
        public async Task<IActionResult> Put(int id, [FromBody] User user)
        {
            try {
                // Get the current entity
                var entity = await _context.Users.FirstOrDefaultAsync(x => x.Id == id);

                if (entity != null) {
                    // Set values
                    entity.Profile = user.Profile;

                    // Update entity
                    _context.Users.Update(entity);

                    // Set changes
                    _context.SaveChanges();
                }
                
                return Ok(entity);
            }
            catch(Exception) {
                return BadRequest("Can't update user profile");
            }
        }

        // DELETE api/users/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

    }
}
