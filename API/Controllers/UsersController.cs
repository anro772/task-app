using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using API.Data;
using API.Entities;
using Microsoft.EntityFrameworkCore;
using MediatR;
using API.Queries;
using API.Commands;
using static API.Queries.GetTask;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class TasksController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IMediator _mediator;

        public TasksController(IMediator mediator, DataContext context)
        {
            _mediator = mediator;
            _context = context;
        }

        // [HttpGet]
        // public async Task<List<AppUser>> GetTasks()
        // {
        //     return await _mediator.Send(new GetTaskListQuery());
        // }

        [HttpGet("{id}")]
        public async Task<AppUser> GetTask(int id)
        {
            return await _mediator.Send(new GetTask.GetTaskByIdQuery(id));
        }

        // [HttpPost]
        // public async Task<AppUser> Post([FromBody] AppUser task)
        // {
        //     return await _mediator.Send(new AddTaskCommand(task));
        // }


        //=================================================================================================================
        // [HttpGet]
        // public async Task<ActionResult<IEnumerable<AppUser>>> GetTaskss()
        // {
        //     return await _context.Tasks.ToListAsync();
        // }

        // //api/Tasks/2
        // [HttpGet("{id}")]
        // public async Task<ActionResult<AppUser>> GetTasks(int id)
        // {
        //     return await _context.Tasks.FindAsync(id);
        // }

        // [HttpPut("{id}")]
        // public async Task<IActionResult> PutTasks(int id, AppUser appUser)
        // {
        //     if (id != appUser.Id)
        //     {
        //         return BadRequest();
        //     }

        //     _context.Entry(appUser).State = EntityState.Modified;

        //     try
        //     {
        //         await _context.SaveChangesAsync();
        //     }
        //     catch (DbUpdateConcurrencyException)
        //     {
        //         if (!(await TaskExists(id)))
        //         {
        //             return NotFound();
        //         }
        //         else
        //         {
        //             throw;
        //         }
        //     }

        //     return NoContent();
        // }

        // [HttpPost]
        // public async Task<ActionResult<AppUser>> PostTasks(AppUser appUser)
        // {
        //     _context.Tasks.Add(appUser);
        //     await _context.SaveChangesAsync();

        //     return CreatedAtAction("GetTasks", new { id = appUser.Id }, appUser);
        // }

        // [HttpDelete("{id}")]
        // public async Task<ActionResult<AppUser>> DeleteTasks(int id)
        // {
        //     var appUser = await _context.Tasks.FindAsync(id);
        //     if (appUser == null)
        //     {
        //         return NotFound();
        //     }

        //     _context.Tasks.Remove(appUser);
        //     await _context.SaveChangesAsync();

        //     return appUser;
        // }

        // private async Task<bool> TaskExists(int id)
        // {
        //     return await _context.Tasks.AnyAsync(e => e.Id == id);
        // }
    }
}