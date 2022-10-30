using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class DataAccess : DataContext, IDataAccess
    {
        private List<AppUser> _tasks = new();

        public DataAccess(DbContextOptions options) : base(options)
        {
            _tasks = Tasks.ToList<AppUser>();
        }

        public List<AppUser> GetTasks()
        {
            return Tasks.ToList<AppUser>();
        }

        public AppUser AddTask(AppUser appUser)
        {
            Tasks.Add(appUser);
            SaveChanges();
            _tasks.Add(appUser);
            return appUser;
        }

        public AppUser GetTaskById(int id)
        {
            return _tasks.FirstOrDefault(x => x.Id == id);
        }

        public AppUser DeleteTask(int id)
        {
            var task = _tasks.FirstOrDefault(x => x.Id == id);

            if (task != null)
            {
                _tasks.Remove(task);
            }
            Tasks.Remove(task);
            SaveChanges();
            return task;
        }
    }
}