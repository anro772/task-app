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

namespace API.Handlers
{
    public class DeleteTaskHandler : IRequestHandler<DeleteTaskCommand, AppUser>
    {
        public DataContext _context { get; }
        private readonly IDataAccess _dataAccess;

        public DeleteTaskHandler(DataContext context)
        {
            this._context = context;
        }

        public Task<AppUser> Handle(DeleteTaskCommand request, CancellationToken cancellationToken)
        {
            var task = _context.Tasks.FirstOrDefault(x => x.Id == request.id);

            if (task != null)
            {
                _context.Tasks.Remove(task);
                _context.SaveChanges();
            }

            return Task.FromResult(task);
        }
    }
}