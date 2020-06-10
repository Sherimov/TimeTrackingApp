using SEDC.Abs_Int.Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SEDC.Abs_Int.Logic.Entities
{
    public class Student : User, IStudent
    {
        public Dictionary<string, int> Grades { get; set; }

        public Student(int id, string name, string userName, int password, Dictionary<string, int> grades)
            : base(id, name, userName, password)
        {
            Grades = grades;
        }

        public override void PrintUser()
        {
            Console.WriteLine($"Student's {Name} grades:");
            for (int i = 0; i < Grades.Count; i++)
            {
                var item = Grades.ElementAt(i);
                var itemKey = item.Key;
                var itemValue = item.Value;
                Console.WriteLine($"Subject: {itemKey}, Grade: {itemValue}");
            }
            
        }
    }
}
