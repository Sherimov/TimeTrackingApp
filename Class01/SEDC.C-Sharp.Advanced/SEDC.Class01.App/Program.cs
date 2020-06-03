using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace SEDC.Class01.App
{
    class Program
    {
        static void Main(string[] args)
        {

            List<string> namesFromInput = new List<string>();
            Console.WriteLine("Enter a name/word ! When u want to stop enter X");

            while (true)
            {
                var userInput = Console.ReadLine();
                if (userInput.ToLower() == "x")
                {
                    break;
                }
                namesFromInput.Add(userInput);
            }
            Console.WriteLine("Enter a text");
            var textInput = Console.ReadLine();

            NameContaining(namesFromInput, textInput);


            Console.ReadLine();
        }

        public static void NameContaining(List<string> names, string textInput)
        {
            foreach (var name in names)
            {
                var regex = new Regex(name);
                var times = regex.Matches(textInput).Count;
                Console.WriteLine($"The name {name} is used {times} times in the sentence");
            }
        }
    }
}
