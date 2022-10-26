using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Entities;
using API.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;
using static API.Queries.GetTask;

namespace API.Handlers
{
    public class GetTaskByIdHandler : IRequestHandler<GetTaskByIdQuery, AppUser>
    {
        public DataContext _context { get; }
        private readonly IDataAccess _dataAccess;

        public GetTaskByIdHandler(DataContext _context)
        {
            this._context = _context;
        }

        public async Task<AppUser> Handle(GetTaskByIdQuery request, CancellationToken cancellationToken)
        {
            var task = await _context.Tasks.FirstOrDefaultAsync(x => x.Id == request.Id);
            return task;

            // return Task.FromResult(_dataAccess.GetTaskById(request.Id));
        }
    }
}