using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Commands;
using API.Data;
using API.Entities;
using MediatR;
using static API.Commands.AddTask;
using static API.Commands.DeleteTask;
using static API.Commands.UpdateTask;

namespace API.Handlers
{
    public class UpdateTaskHandler : IRequestHandler<UpdateTaskCommand, AppUser>
    {
        public DataContext _context { get; }
        private readonly IDataAccess _dataAccess;

        public UpdateTaskHandler(DataContext context)
        {
            this._context = context;
        }

        public Task<AppUser> Handle(UpdateTaskCommand request, CancellationToken cancellationToken)
        {
            var task = _context.Tasks.FirstOrDefault(x => x.Id == request.id);

            if (task != null)
            {
                task.Text = request.Task.Text;
                task.Day = request.Task.Day;
                task.Reminder = request.Task.Reminder;
                _context.SaveChanges();
            }

            return Task.FromResult(task);
        }
    }
}