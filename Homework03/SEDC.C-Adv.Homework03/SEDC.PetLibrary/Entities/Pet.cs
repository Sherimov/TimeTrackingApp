using SEDC.PetLibrary.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace SEDC.PetLibrary.Entities
{
    public abstract class Pet
    {
        public string Name { get; set; }
        public TypeOfPet Type { get; set; }
        public int Age { get; set; }

        public Pet(string name, TypeOfPet type, int age)
        {
            Name = name;
            Type = type;
            Age = age;
        }

        public abstract string PrintInfo();
    }
}
