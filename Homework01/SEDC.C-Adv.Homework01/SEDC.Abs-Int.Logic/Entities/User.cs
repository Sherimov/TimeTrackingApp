using SEDC.Abs_Int.Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SEDC.Abs_Int.Logic.Entities
{
    public abstract class User : IUser
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public int Password { get; set; }
        public User(int id, string name, string userName, int password)
        {
            Id = id;
            Name = name;
            UserName = userName;
            Password = password;

        }
        public virtual void PrintUser()
        {
            Console.WriteLine($"Id: {Id}, Name: {Name}, Username: {UserName} ...");
        }
    }
}
