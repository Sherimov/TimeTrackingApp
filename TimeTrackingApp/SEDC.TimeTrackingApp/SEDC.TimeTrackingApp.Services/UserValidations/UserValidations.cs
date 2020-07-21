using SEDC.TimeTrackingApp.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SEDC.TimeTrackingApp.Services.UserValidations
{
    public static class UserValidations
    {

        public static bool ValidateUsername (string username)
        {
            return username.Length < 5 ? false : true;
        }

        public static bool ValidateString (string str)
        {
            return str.Length < 2 ? false : true;
        }

        public static int ValidateAge(string age)
        {
            var parsedAge = 0;
            var isNumber = int.TryParse(age, out parsedAge);

            if (!isNumber)
            {
                return -1;
            }
            if(parsedAge < 18 || parsedAge > 120)
            {
                return -1;
            }

            return parsedAge;
        }

        public static bool ValidatePassword(string password)
        {
            if (password.Length < 6)
            {
                Console.WriteLine("Password must contain more than 6 characters!");
                return false;
            }
            if (!password.Any(char.IsUpper))
            {
                Console.WriteLine("Password must contain one upper character!");
                return false;
            }
            if (!password.Any(char.IsDigit))
            {
                Console.WriteLine("Password must contain one digit!");
                return false;
            }

            return true;
        }
    }
}
