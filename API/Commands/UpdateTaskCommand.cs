using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Entities;
using MediatR;

namespace API.Commands
{
    public class UpdateTask
    {
        public record UpdateTaskCommand(AppUser Task, int id) : IRequest<AppUser>;

        public record Response(AppUser Task);
    }
}