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
using static API.Queries.GetTasks;
using static API.Commands.AddTask;
using static API.Commands.DeleteTask;
using static API.Commands.UpdateTask;

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

        [HttpGet]
        public async Task<List<AppUser>> GetTasks()
        {
            return await _mediator.Send(new GetTaskListQuery());
        }

        [HttpGet("{id}")]
        public async Task<AppUser> GetTask(int id)
        {
            return await _mediator.Send(new GetTask.GetTaskByIdQuery(id));
        }

        [HttpPost]
        public async Task<AppUser> AddTask([FromBody] AppUser task)
        {
            return await _mediator.Send(new AddTaskCommand(task));
        }

        [HttpDelete("{id}")]

        public async Task<AppUser> DeleteTask(int id)
        {
            return await _mediator.Send(new DeleteTaskCommand(id));
        }

        [HttpPut("{id}")]
        public async Task<AppUser> UpdateTask([FromBody] AppUser task, int id)
        {
            return await _mediator.Send(new UpdateTaskCommand(task, id));
        }
    }
}