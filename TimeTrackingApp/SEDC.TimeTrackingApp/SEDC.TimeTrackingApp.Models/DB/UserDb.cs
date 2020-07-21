using SEDC.TimeTrackingApp.Models.Interfaces;
using SEDC.TimeTrackingApp.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SEDC.TimeTrackingApp.Models.DB
{
    [Serializable]
    public class UserDb : IUserDb
    {
        private List<User> _users;

        public UserDb()
        {
            _users = new List<User>();
        }
        public List<User> GetUsers()
        {
            return _users;
        }

        public User GetUserById(long id)
        {
            return _users.FirstOrDefault(x => x.Id == id);
        }

        public void InsertUser(User user)
        {
            _users.Add(user);
        }

        public void RemoveUser(long id)
        {
            var findUserId = _users.FirstOrDefault(x => x.Id == id);
            if (findUserId != null)
                _users.Remove(findUserId);
        }

        public User UpdateUser(User user)
        {
            var update = _users.FirstOrDefault(x => x.Id == user.Id);
            update = user;
            return user;
        }
    }
}
