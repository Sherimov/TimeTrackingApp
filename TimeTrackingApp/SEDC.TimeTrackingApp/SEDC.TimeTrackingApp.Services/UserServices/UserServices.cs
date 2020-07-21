using SEDC.TimeTrackingApp.Models.DB;
using SEDC.TimeTrackingApp.Models.Models;
using SEDC.TimeTrackingApp.Services.Helpers;
using SEDC.TimeTrackingApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;

namespace SEDC.TimeTrackingApp.Services.UserServices
{
    public class UserServices : IUserService
    {
        private UserDb _userDb;
        public UserServices()
        {
            if (!File.Exists("users.txt"))
            {
                _userDb = new UserDb();
                return;
            }

            var formatter = new BinaryFormatter();

            using (var stream = new FileStream("users.txt", FileMode.Open, FileAccess.Read))
            {
                _userDb = (UserDb)formatter.Deserialize(stream);
            }

            if (_userDb == null)
            {
                _userDb = new UserDb();
            }
        }

        private void SaveUsers()
        {
            var formatter = new BinaryFormatter();

            using (var stream = new FileStream("users.txt", FileMode.Create, FileAccess.Write))
            {
                formatter.Serialize(stream, _userDb);
                stream.Close();
            }
        }

        public void ChangeInfo(long userId, string firstName, string lastName)
        {
            var user = _userDb.GetUserById(userId);
            if(!UserValidations.UserValidations.ValidateString(firstName))
            {
                MessageHelper.Color("Firstname is not valid!", ConsoleColor.Red);
                return;
            }

            user.FirstName = firstName;

            if (!UserValidations.UserValidations.ValidateString(lastName))
            {
                MessageHelper.Color("Lastname is not valid!", ConsoleColor.Red);
                return;
            }

            user.LastName = lastName;

            _userDb.UpdateUser(user);
            MessageHelper.Color("Updating First and Last name...", ConsoleColor.Green);
            this.SaveUsers();
            Thread.Sleep(2000);
            MessageHelper.Color("Data successfuly changed!", ConsoleColor.Green);
        }

        public void ChangePassword(long userId, string oldPassword, string newPassword)
        {
            var user = _userDb.GetUserById(userId);
            if(oldPassword != newPassword)
            {
                MessageHelper.Color("Passwords did not match", ConsoleColor.Red);
                return;
            }
            if (UserValidations.UserValidations.ValidatePassword(newPassword))
            {
                user.Password = newPassword;
            }

            _userDb.UpdateUser(user);
            MessageHelper.Color("Updating password...", ConsoleColor.Green);
            Thread.Sleep(2000);
            this.SaveUsers();
            MessageHelper.Color("Password successfuly changed!", ConsoleColor.Green);

        }

        public User LogIn()
        {
            int counter = 3;
            while (counter > 0)
            {
                MessageHelper.Color($"You you have {counter} times to try to log in", ConsoleColor.Red);
                Console.WriteLine("Enter username:");
                var username = Console.ReadLine();
                Console.WriteLine("Enter password:");
                var password = Console.ReadLine();

                User user = _userDb.GetUsers().FirstOrDefault(x => x.Username == username && x.Password == password);
                if (user != null)
                {
                    Console.WriteLine($"Welcome {user.FirstName}.You are successfully logged in.");
                    return user;
                }
                else
                {
                    MessageHelper.Color("Username or password did not match! Please try again!", ConsoleColor.Red);
                }
                counter--;
            }
            Console.WriteLine("You entered wrong username/password 3 times. App is closing");
            Thread.Sleep(3000);
            return null;
        }

        public User Register()
        {
            var user = new User();
            MessageHelper.Color("Welcome to registration", ConsoleColor.Green);
            Console.WriteLine("Enter First Name:");
           var firstName = Console.ReadLine();
            if (!UserValidations.UserValidations.ValidateString(firstName))
            {
                MessageHelper.Color("Invalid firstname! Please try again", ConsoleColor.Red);
                return null;
            }
            user.FirstName = firstName;

            Console.WriteLine("Enter Last Name:");
            var lastName =Console.ReadLine();
            if (!UserValidations.UserValidations.ValidateString(lastName))
            {
                MessageHelper.Color("Invalid lastname! Please try again", ConsoleColor.Red);
                return null;
            }
            user.LastName = lastName;

            Console.WriteLine("Enter Age:");
            
            user.Age = (UserValidations.UserValidations.ValidateAge(Console.ReadLine()));
            if(user.Age == -1)
            {
                MessageHelper.Color("Invalid age! Please try again", ConsoleColor.Red);
                return null;
            }
            
            Console.WriteLine("Enter Username(must be longer than 5 characters):");
            var username = Console.ReadLine();
            if (!UserValidations.UserValidations.ValidateUsername(username))
            {
                MessageHelper.Color("Invalid Username! Please try again", ConsoleColor.Red);
                return null;
            }
            user.Username = username;

            Console.WriteLine("Enter Password(shoud contain at lease one capital letter and one number):");
            var password = Console.ReadLine();
            if (!UserValidations.UserValidations.ValidatePassword(password))
            {
                MessageHelper.Color("Invalid password! shoud contain at lease one capital letter and one number", ConsoleColor.Red);
                return null;
            }
            user.Password = password;
           
            _userDb.InsertUser(user);
            Console.WriteLine("Registering user...");
            Thread.Sleep(2000);
            this.SaveUsers();
            MessageHelper.Color("You have been successfully registered", ConsoleColor.Green);
            Thread.Sleep(2000);

            return _userDb.GetUserById(user.Id);
        }

        public void RemoveUser(long userId)
        {
            _userDb.RemoveUser(userId);
            this.SaveUsers();
        }
    }
}
