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
            ActionResult<Task<List<AppUser>>> tasks = _mediator.Send(new GetTaskListQuery());
            if (tasks.Value.Result == null)
                return NotFound();
            return Ok(tasks);
        }

        [HttpGet("{id}")]
        public ActionResult<Task<AppUser>> GetTask(int id)
        {
            ActionResult<Task<AppUser>> task = _mediator.Send(new GetTask.GetTaskByIdQuery(id));
            if (task.Value.Result == null)
                return NotFound();
            return Ok(task);
        }

        [HttpPost]
        public ActionResult<Task<AppUser>> AddTask([FromBody] AppUser task)
        {
            Task<AppUser> taskOut = _mediator.Send(new AddTaskCommand(task));
            return Ok(taskOut);
        }

        [HttpDelete("{id}")]
        public ActionResult<Task<AppUser>> DeleteTask(int id)
        {
            Task<AppUser> task = _mediator.Send(new DeleteTaskCommand(id));
            if (task.Result == null)
                return NotFound();
            return Ok(task.Result);
        }

        [HttpPut("{id}")]
        public ActionResult<Task<AppUser>> UpdateTask([FromBody] AppUser task, int id)
        {
            Task<AppUser> taskOut = _mediator.Send(new UpdateTaskCommand(task, id));
            if (taskOut.Result == null)
                return NotFound();
            return Ok(taskOut.Result);
        }
    }
}