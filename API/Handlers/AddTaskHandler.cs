using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Commands;
using API.Data;
using API.Entities;
using MediatR;
using static API.Commands.AddTask;

namespace API.Handlers
{
    public class AddTaskHandler : IRequestHandler<AddTaskCommand, AppUser>
    {
        public DataContext _context { get; }
        private readonly IDataAccess _dataAccess;

        public AddTaskHandler(DataContext context)
        {
            this._context = context;
        }

        public Task<AppUser> Handle(AddTaskCommand request, CancellationToken cancellationToken)
        {
            var task = new AppUser
            {
                Id = request.Task.Id,
                Text = request.Task.Text,
                Day = request.Task.Day,
                Reminder = request.Task.Reminder
            };

            _context.Tasks.Add(task);
            _context.SaveChanges();

            return Task.FromResult(task);
        }
    }
}