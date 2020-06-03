using System;
using System.Collections.Generic;
using System.Linq;

namespace SEDC.Class01.App1
{
    class Program
    {
        static void Main(string[] args)
        {
            
            var holidays = new List<DateTime>()
            { new DateTime(1,1,1),
              new DateTime (1,1,7),
              new DateTime(1,4,20),
              new DateTime(1,5,1),
              new DateTime(1,1,25),
              new DateTime(1,8,3),
              new DateTime(1,9,8),
              new DateTime(1,10,12),
              new DateTime(1,10,23),
              new DateTime(1,12,8)
            };
            while (true)
            {
                Console.WriteLine("Enter a date and we will check if it is a working day or weekday");
                DateTime dateFromInput;
                DateTime.TryParse(Console.ReadLine(), out dateFromInput);
                bool isHoliday = false;
                foreach (var holiday in holidays)
                {
                    if (dateFromInput.Day == holiday.Day && dateFromInput.Month == holiday.Month)
                    {
                        Console.WriteLine($"{dateFromInput} is a holiday");
                        isHoliday = !isHoliday;
                    }
                    
                }

                if (!isHoliday)
                {
                    if (dateFromInput.DayOfWeek == DayOfWeek.Saturday || dateFromInput.DayOfWeek == DayOfWeek.Sunday)
                    {
                        Console.WriteLine($"The date you have entered {dateFromInput} is weekend day");
                    }
                    else
                    {
                        Console.WriteLine($"{dateFromInput} is a working day");
                    }
                }

                Console.WriteLine("Do you want to continue yes/no ?");
                var answerInput = Console.ReadLine();
                if(answerInput.ToLower() == "yes")
                {
                    continue;
                }
                if(answerInput.ToLower() == "no")
                {
                    break;
                }

            }
 
            Console.ReadLine();
        }
    }
}
