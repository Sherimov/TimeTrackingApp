using SEDC.Adv.AdvLinqData.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace SEDC.Adv.AdvLinqData.Models
{
    public class Dog
    {
		public string Name { get; set; }
		public string Color { get; set; }
		public int Age { get; set; }
		public Race Race { get; set; }

		public Dog(string name, string color, int age, Race race)
		{
			Name = name;
			Color = color;
			Age = age;
			Race = race;
		}

		public string PrintInfo()
		{
			return $"Dog's name: {Name}, Age: {Age}";
		}
	}
}
