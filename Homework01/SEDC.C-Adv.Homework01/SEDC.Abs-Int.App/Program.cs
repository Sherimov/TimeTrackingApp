using SEDC.Abs_Int.Logic.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SEDC.Abs_Int.App
{
    class Program
    {
        static void Main(string[] args)
        {
            var studentOneSubjects = new Dictionary<string, int>
            {
                {"Html", 3 },
                {"Css", 5 },
                {"C#", 6 }
            };
            var studentOne = new Student(1, "Bob", "Bobs username", 123123, studentOneSubjects);

            studentOne.PrintUser();

            var studentTwoSubjects = new Dictionary<string, int>
            {
                {"Html", 6 },
                {"Css", 3 },
                {"C#", 10 }
            };

            var studentTwo = new Student(2, "Bobski", "Bobski username", 123123, studentTwoSubjects);

            studentTwo.PrintUser();

            var teacherSubjects = new List<string>() {"Html", "Css", "Python", "Javascript" };
            var teacherOne = new Teacher(3, "Jill", "Jills username", 123123, teacherSubjects);

            teacherOne.PrintUser();

            var teacherTwoSubjects = new List<string>() { "Html", "C#", "Python", "Javascript" };
            var teacherTwo = new Teacher(4, "Mike", "Mikes username", 16546879, teacherTwoSubjects);

            teacherTwo.PrintUser();
            Console.ReadLine();
        }
    }
}
