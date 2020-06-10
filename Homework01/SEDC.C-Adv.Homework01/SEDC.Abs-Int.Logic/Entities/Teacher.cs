using SEDC.Abs_Int.Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SEDC.Abs_Int.Logic.Entities
{
    public class Teacher :  User, ITeacher
    {
        public List<string> Subjects { get; set; }

        public Teacher(int id, string name, string userName, int password, List<string> subjects)
            : base(id, name, userName, password)
        {
            Subjects = subjects;
        }

        public override void PrintUser()
        {
            Console.WriteLine($"Teacher: {Name}, Subjects:");
            foreach (var subject in Subjects)
            {
                Console.WriteLine(subject);
            }
        }
    }
}
