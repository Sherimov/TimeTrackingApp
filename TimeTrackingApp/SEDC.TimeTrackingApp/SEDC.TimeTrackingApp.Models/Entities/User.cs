using SEDC.TimeTrackingApp.Models.BaseModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace SEDC.TimeTrackingApp.Models.Models
{
    [Serializable]
    public class User
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public User()
        {
            Id = System.DateTime.Now.Ticks;
        }
    }
}
