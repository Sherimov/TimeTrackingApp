using SEDC.TimeTrackingApp.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SEDC.TimeTrackingApp.Models.Interfaces
{
    public interface IUserDb
    {
        List<User> GetUsers();
        User GetUserById(long id);
        void InsertUser(User user);
        void RemoveUser(long id);
        User UpdateUser(User user);
    }
}
