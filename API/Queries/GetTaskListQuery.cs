using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Entities;
using MediatR;

namespace API.Queries
{
    public class GetTasks
    {
        public record GetTaskListQuery() : IRequest<List<AppUser>>;

    }
}