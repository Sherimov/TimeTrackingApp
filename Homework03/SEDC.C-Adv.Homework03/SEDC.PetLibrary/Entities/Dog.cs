using SEDC.PetLibrary.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace SEDC.PetLibrary.Entities
{
    public class Dog : Pet
    {
        public bool GoodBoi { get; set; }
        public string FavouriteFood { get; set; }
        public Dog(string name, TypeOfPet type, int age, bool goodBoi, string favouriteFood)
            : base (name, type, age)
        {
            GoodBoi = goodBoi;
            FavouriteFood = favouriteFood;
        }

        public override string PrintInfo()
        {
            var print = String.Empty;
            if (GoodBoi)
            {
                print = "is a good boi";
            }
            else
            {
                print = "is not a good boi";
            }
            return $"{Type}, name: {Name}, Age {Age}, {print}, favourite food: {FavouriteFood}";
        }
    }
}
