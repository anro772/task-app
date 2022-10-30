using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Entities;
using API.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;
using static API.Queries.GetTasks;

namespace API.Handlers
{
    public class GetTaskListHandler : IRequestHandler<GetTaskListQuery, List<AppUser>>
    {
        private readonly IDataAccess _dataAccess;

        public GetTaskListHandler(IDataAccess dataAccess)
        {
            this._dataAccess = dataAccess;
        }

        public Task<List<AppUser>> Handle(GetTaskListQuery request, CancellationToken cancellationToken)
        {
            //  var tasks = await _context2.Tasks.ToListAsync();
            // return tasks;
            return Task.FromResult(_dataAccess.GetTasks());
        }
    }
}