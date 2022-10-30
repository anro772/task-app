using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Commands;
using API.Data;
using API.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using static API.Commands.DeleteTask;

namespace API.Handlers
{
    public class DeleteTaskHandler : IRequestHandler<DeleteTaskCommand, AppUser>
    {
        private readonly IDataAccess _dataAccess;

        public DeleteTaskHandler(IDataAccess dataAccess)
        {
            this._dataAccess = dataAccess;
        }

        public Task<AppUser> Handle(DeleteTaskCommand request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_dataAccess.DeleteTask(request.Id));
        }
    }
}