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
        public DataContext _context { get; }
        private readonly IDataAccess _dataAccess;

        public GetTaskListHandler(DataContext context)
        {
            this._context = context;
        }

        public async Task<List<AppUser>> Handle(GetTaskListQuery request, CancellationToken cancellationToken)
        {
            var tasks = await _context.Tasks.ToListAsync();
            return tasks;
        }
    }
}