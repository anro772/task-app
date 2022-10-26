using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Entities;
using MediatR;

namespace API.Commands
{
    public record AddTaskCommand(AppUser AppUser) : IRequest<AppUser>;
}