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
using System.Net;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class TasksController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TasksController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public ActionResult<Task<List<AppUser>>> GetTasks()
        {
            Task<List<AppUser>> tasks = _mediator.Send(new GetTaskListQuery());
            if (tasks.Result.Count == 0)
                return NotFound();
            return tasks;
        }

        [HttpGet("{id}")]
        public ActionResult<Task<AppUser>> GetTask(int id)
        {
            Task<AppUser> task = _mediator.Send(new GetTask.GetTaskByIdQuery(id));
            if (task.Result == null)
                return NotFound();
            return task;
        }

        [HttpPost]
        public ActionResult<Task<AppUser>> AddTask([FromBody] AppUser task)
        {
            return _mediator.Send(new AddTaskCommand(task));
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