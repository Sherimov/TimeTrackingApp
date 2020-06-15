using System;
using System.Collections.Generic;
using System.Text;

namespace SEDC.PetLibrary.Entities
{
    public class PetStore<T> where T : Pet
    {
        private List<T> ListOfPets;
        public PetStore()
        {
            ListOfPets = new List<T>();
        }

        public void PrintPets()
        {
            foreach (T pet in ListOfPets)
            {
                Console.WriteLine(pet.PrintInfo());
            }
        }

        public void AddPetToStore(T item)
        {
            ListOfPets.Add(item);
            Console.WriteLine($"Pet was added in the pet store");
        }

        public void BuyPet(string name)
        {
            for (int i = 0; i < ListOfPets.Count; i++)
            {
                T pet = ListOfPets[i];
                if (pet.Name == name)
                {
                    ListOfPets.Remove(pet);
                    Console.WriteLine("Congrats you have a new pet now");
                }
                else
                {
                    Console.WriteLine("There is no such name of a pet!");
                }
            }
            
        }
    }
}
