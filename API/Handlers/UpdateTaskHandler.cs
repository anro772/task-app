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
        private readonly IDataAccess _dataAccess;

        public UpdateTaskHandler(IDataAccess dataAccess)
        {
            this._dataAccess = dataAccess;
        }

        public Task<AppUser> Handle(UpdateTaskCommand request, CancellationToken cancellationToken)
        {
            var task = new AppUser
            {
                //Id = request.Task.Id,
                Text = request.Task.Text,
                Day = request.Task.Day,
                Reminder = request.Task.Reminder
            };
            return Task.FromResult(_dataAccess.UpdateTask(task, request.id));
        }
    }
}