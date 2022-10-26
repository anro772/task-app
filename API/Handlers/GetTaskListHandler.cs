using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Entities;
using API.Queries;
using MediatR;

namespace API.Handlers
{
    public class GetTaskListHandler : IRequestHandler<GetTaskListQuery, List<AppUser>>
    {
        private readonly IDataAccess _dataAccess;
        public GetTaskListHandler(IDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public Task<List<AppUser>> Handle(GetTaskListQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_dataAccess.GetTasks());
        }
    }
}