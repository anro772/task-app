using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Entities;

namespace API.Data
{
    public interface IDataAccess
    {
        List<AppUser> GetTasks();
        AppUser AddUser(AppUser appUser);
        AppUser GetTaskById(int id);
    }
}