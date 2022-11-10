using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Entities
{
    public class AppUser
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public string Day { get; set; }
        public bool Reminder { get; set; }

        public AppUser()
        {
            this.Id = 0;
            this.Text = "";
            this.Day = "";
            this.Reminder = false;
        }
    }
}