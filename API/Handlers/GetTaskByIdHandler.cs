using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Entities;
using API.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static API.Queries.GetTask;

namespace API.Handlers
{
    public class GetTaskByIdHandler : IRequestHandler<GetTaskByIdQuery, AppUser>
    {
        private readonly IDataAccess _dataAccess;

        public GetTaskByIdHandler(IDataAccess dataAccess)
        {
            this._dataAccess = dataAccess;
        }
        public Task<AppUser> Handle(GetTaskByIdQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_dataAccess.GetTaskById(request.Id));
        }
    }
}