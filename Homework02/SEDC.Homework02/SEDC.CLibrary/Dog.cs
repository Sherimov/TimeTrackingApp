using System;

namespace SEDC.CLibrary
{
    public class Dog
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }
        public Dog(int id, string name, string color)
        {
            Id = id;
            Name = name;
            Color = color;
        }

        public string Bark()
        {
            return "Bark Bark";
        }

        public static bool Validate(Dog dog)
        {
            bool hasAllProperties = true;
            if (dog.Id <= 0)
            {
                Console.WriteLine("The dog has no id!");
                hasAllProperties = !hasAllProperties;
                
            }
            if(dog.Name.Length <= 1)
            {
                Console.WriteLine("Dog's name got to be 2 or more characters");
                hasAllProperties = !hasAllProperties;
                
            }
            if(dog.Color == String.Empty)
            {
                Console.WriteLine("The dog has no color");
                hasAllProperties = !hasAllProperties;
                
            }
            //if (!hasAllProperties)
            //{
            //    Console.WriteLine("The validation of the dog didnt go through"); 
            //}
            if (hasAllProperties)
            {
                Console.WriteLine("The dog has all the properties");
                return hasAllProperties;
            }
            else
            {
                Console.WriteLine("Propertioes of dog not valid!");
                
                return hasAllProperties;
            }
            
            
            
        }
    }
}
