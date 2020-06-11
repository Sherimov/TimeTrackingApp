using System;
using System.Collections.Generic;
using System.Text;

namespace SEDC.CLibrary
{
    public static class DogShelter
    {
        public static List<Dog> Dogs { get; set; } = new List<Dog>();


        public static List<Dog> AddDogsToShelter(Dog dog)
        {
            if (Dog.Validate(dog))
            {
                Dogs.Add(dog);
                Console.WriteLine("Dog succesfully added to the shelter");
            }
            else
            {
                Console.WriteLine("The dog could't be added to the shelter");
            }
            return Dogs;
        }
        
        public static void PrintAll()
        {
            foreach (var dog in Dogs)
            {
                Console.WriteLine($"Id: {dog.Id}, Name: {dog.Name}, Color: {dog.Color}");
            }
        }

    }
}
