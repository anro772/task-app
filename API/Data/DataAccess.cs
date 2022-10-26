using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class DataAccess : IDataAccess
    {
        private List<AppUser> _tasks = new();

        public DataAccess()
        {
            // _tasks = Tasks.ToList();
        }

        public List<AppUser> GetTasks()
        {
            return _tasks;
        }

        public AppUser AddUser(AppUser appUser)
        {
            _tasks.Add(appUser);
            return appUser;
        }

        public AppUser GetTaskById(int id)
        {
            return _tasks.FirstOrDefault(x => x.Id == id);
        }
    }
}