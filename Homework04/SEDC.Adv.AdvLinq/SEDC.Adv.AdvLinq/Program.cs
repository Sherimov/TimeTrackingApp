using SEDC.Adv.AdvLinqData;
using SEDC.Adv.AdvLinqData.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SEDC.Adv.AdvLinq
{
    class Program
    {
        static void Main(string[] args)
        {
         
            var findFirstNameWithR = ExerciseData.people
                .Where(person => person.FirstName.StartsWith('R'))
                .OrderByDescending(person => person.Age)
                .ToList();

            foreach (var item in findFirstNameWithR)
            {
                Console.WriteLine(item.PrintInfo());                
            }
            Console.WriteLine("-------------------------------------");
            var findAllBrownDogs = ExerciseData.dogs
                .Where(dog => dog.Color == "Brown" && dog.Age > 3)
                .OrderBy(dog => dog.Age)
                .ToList();

            foreach (var item in findAllBrownDogs)
            {
                Console.WriteLine(item.PrintInfo());
            }
            Console.WriteLine("-------------------------------------");
            var findOwnersWithTwoOrMoreDogs = ExerciseData.people
                .Where(person => person.Dogs.Count > 2)
                .OrderBy(person => person.FirstName);

            foreach (var item in findOwnersWithTwoOrMoreDogs)
            {
                Console.WriteLine(item.PrintInfo());
            }
            Console.WriteLine("-------------------------------------");
            var printFredysDogs = ExerciseData.people
                .FirstOrDefault(person => person.FirstName == "Freddy")
                .Dogs.Where(dog => dog.Age > 1)
                .ToList();

            foreach (var item in printFredysDogs)
            {
                Console.WriteLine(item.PrintInfo());
            }
            Console.WriteLine("-------------------------------------");
            var printNathanFirstDog = ExerciseData.people
                .Where(person => person.FirstName == "Nathen")
                .Select(person => person.Dogs[0])
                .ToList()
                ;

           
            foreach (var item in printNathanFirstDog)
            {
                Console.WriteLine(item.PrintInfo());
            }
            Console.WriteLine("-------------------------------------");
            var dogOwners =  new List<string> { "Cristofer", "Freddy", "Erin", "Amelia"};

            var printAllWhiteDogs = ExerciseData.people
                .Where(person => dogOwners.Contains(person.FirstName))
                .SelectMany(person => person.Dogs)
                    .Where(dog => dog.Color == "White")
                    .ToList();

            foreach (var item in printAllWhiteDogs)
            {
                Console.WriteLine(item.PrintInfo());
            }

            Console.ReadLine();
        }

    }
}
