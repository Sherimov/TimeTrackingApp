using SEDC.PetLibrary.Entities;
using SEDC.PetLibrary.Enum;
using System;
using System.Collections.Generic;


namespace SEDC.C_Adv.Homework03.App
{
    class Program
    {
        public static PetStore<Dog> DogDb = new PetStore<Dog>();
        public static PetStore<Cat> CatDb = new PetStore<Cat>();
        public static PetStore<Fish> FishDb = new PetStore<Fish>();
        static void Main(string[] args)
        {
            var dog = new Dog("Sarko", TypeOfPet.Dog, 3, true, "Bone");
            var dog1 = new Dog("Sarko1", TypeOfPet.Dog, 3, true, "Bone");
            var fish = new Fish("Koi", TypeOfPet.Fish, 2, "orange", "large");
            var fish1 = new Fish("Fish", TypeOfPet.Fish, 5, "black", "medium");
            var cat = new Cat("Meow", TypeOfPet.Cat, 7, false, 9);
            var cat1 = new Cat("Meow1", TypeOfPet.Cat, 3, true, 2);
            DogDb.AddPetToStore(dog);
            DogDb.AddPetToStore(dog1);
            CatDb.AddPetToStore(cat);
            CatDb.AddPetToStore(cat1);
            FishDb.AddPetToStore(fish);
            FishDb.AddPetToStore(fish1);

            DogDb.PrintPets();
            CatDb.PrintPets();
            FishDb.PrintPets();

            DogDb.BuyPet("Sarko");
            


            Console.ReadLine();
        }
    }
}
