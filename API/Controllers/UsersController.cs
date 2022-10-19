using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using API.Data;
using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class TasksController : ControllerBase
    {
        private readonly DataContext _context;
        public TasksController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppUser>>> GetTasks()
        {
            return await _context.Tasks.ToListAsync();
        }

        //api/Tasks/2
        [HttpGet("{id}")]
        public async Task<ActionResult<AppUser>> GetTasks(int id)
        {
            return await _context.Tasks.FindAsync(id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutTasks(int id, AppUser appUser)
        {
            if (id != appUser.Id)
            {
                return BadRequest();
            }

            _context.Entry(appUser).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TasksExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<AppUser>> PostTasks(AppUser appUser)
        {
            _context.Tasks.Add(appUser);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTasks", new { id = appUser.Id }, appUser);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<AppUser>> DeleteTasks(int id)
        {
            var appUser = await _context.Tasks.FindAsync(id);
            if (appUser == null)
            {
                return NotFound();
            }

            _context.Tasks.Remove(appUser);
            await _context.SaveChangesAsync();

            return appUser;
        }

        private bool TasksExists(int id)
        {
            return _context.Tasks.Any(e => e.Id == id);
        }
    }
}