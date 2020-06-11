using SEDC.CLibrary;
using System;

namespace SEDC.Homework02.App
{
    class Program
    {
        static void Main(string[] args)
        {
            var dog = new Dog(1, "BU", "Black");
            var dog1 = new Dog(1, "Bob", "Blue");
            var dog2 = new Dog(3, "bobski", "Red");


            DogShelter.AddDogsToShelter(dog);
            DogShelter.AddDogsToShelter(dog1);
            DogShelter.AddDogsToShelter(dog2);


            DogShelter.PrintAll();
            Console.ReadLine();
        }
    }
}
