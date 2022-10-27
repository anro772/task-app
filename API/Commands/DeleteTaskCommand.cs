using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Entities;
using MediatR;

namespace API.Commands
{
    public class DeleteTask
    {
        public record DeleteTaskCommand(int id) : IRequest<AppUser>;

        public record Response(AppUser Task);
    }
}