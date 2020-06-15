using SEDC.PetLibrary.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace SEDC.PetLibrary.Entities
{
    public class Fish : Pet
    {
        public string Color { get; set; }
        public string Size { get; set; }

        public Fish(string name, TypeOfPet type, int age, string color, string size)
            : base(name, type, age)
        {
            Color = color;
            Size = size;
        }

        public override string PrintInfo()
        {
            return $"{Type}, name: {Name}, Age {Age}, Color: {Color}, size: {Size}";
        }
    }
}
