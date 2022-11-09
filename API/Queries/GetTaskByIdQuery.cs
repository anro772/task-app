using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Entities;
using MediatR;

namespace API.Queries
{

    public static class GetTask
    {
        public record GetTaskByIdQuery(int Id) : IRequest<AppUser>;
    }
}