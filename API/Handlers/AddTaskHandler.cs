using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Commands;
using API.Data;
using API.Entities;
using MediatR;

namespace API.Handlers
{
    public class AddTaskHandler : IRequestHandler<AddTaskCommand, AppUser>
    {
        private readonly IDataAccess _dataAccess;

        public AddTaskHandler(IDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public Task<AppUser> Handle(AddTaskCommand request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_dataAccess.AddUser(request.AppUser));
        }
    }
}