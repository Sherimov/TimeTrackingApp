using SEDC.PetLibrary.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace SEDC.PetLibrary.Entities
{
    public class Cat : Pet
    {
        public bool Lazy { get; set; }
        public int LivesLeft { get; set; }

        public Cat(string name, TypeOfPet type, int age, bool lazy, int livesLeft)
            : base(name, type, age)
        {
            Lazy = lazy;
            LivesLeft = livesLeft;
        }

        public override string PrintInfo()
        {
            var print = String.Empty;
            if (Lazy)
            {
                print = "is lazy";
            }
            else
            {
                print = "is not lazy";
            }
            return $"{Type}, name: {Name}, Age {Age}, {print}, lives left: {LivesLeft}";
        }
    }
}
