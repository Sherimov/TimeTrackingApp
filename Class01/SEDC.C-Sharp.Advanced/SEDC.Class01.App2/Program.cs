using System;
using System.Collections.Generic;

namespace SEDC.Class01.App2
{
    class Program
    {
        static void Main(string[] args)
        {

            var isPlaying = true;
            var counterForUser = 0;
            var counterForApp = 0;
            var resultForUser = 0;
            var resultForApp = 0;
            var timesPlayed = 0;
            while (isPlaying)
            {
                Console.WriteLine("Rock Papper Scissors");
                Console.WriteLine("1. Play");
                Console.WriteLine("2. Statistics");
                Console.WriteLine("3. Exit");
                var input = int.Parse(Console.ReadLine());
                // Try/catch !!
                switch (input)
                {
                    case 1:
                        Play(counterForUser, counterForApp, out resultForUser, out resultForApp);
                        timesPlayed++;
                        counterForApp = resultForApp;
                        counterForUser = resultForUser;
                        if(Console.ReadLine() == null)
                        {
                            continue;
                        }
                        break;
                    case 2:
                        StatisticsForUser(timesPlayed, resultForUser, resultForApp);
                        if (Console.ReadLine() == null)
                        {
                            continue;
                        }
                        break;
                    case 3:
                        isPlaying = !isPlaying;
                        break;
                }
            }

            Console.ReadLine();
        }
        public static void Play( int counterForUser, int counterForApp, out int resultForUser, out int resultForApp)
        {
            Console.WriteLine("Rock Papper Scissors");
            Console.WriteLine("Choose one !!");
            var inputUser = Console.ReadLine().ToLower();
            //var tuple = new Tuple<int, int>(counterForUser, counterForApp) { };
            resultForApp = counterForApp;
            resultForUser = counterForUser;
            var random = new Random();
            var listForRandom = new List<string>() { "rock", "papper", "scissor" };
            var index = random.Next(0, (listForRandom.Count - 1));
            var randomChoiceApp = listForRandom[index];

            if (inputUser == "rock" && randomChoiceApp == "rock")
            {
                Console.WriteLine($"It's a tie ! User choice: {inputUser}, App choice: {randomChoiceApp}");
            }
            if (inputUser == "rock" && randomChoiceApp == "scissors")
            {
                Console.WriteLine($"The user has won ! User choice: {inputUser}, App choice: {randomChoiceApp}");
                resultForUser = counterForUser + 1;
            }
            if (inputUser == "rock" && randomChoiceApp == "papper")
            {
                Console.WriteLine($"The app has won ! User choice: {inputUser}, App choice: {randomChoiceApp}");
                resultForApp = counterForApp + 1;
            }
            if (inputUser == "papper" && randomChoiceApp == "rock")
            {
                Console.WriteLine($"The user has won ! User choice: {inputUser}, App choice: {randomChoiceApp}");
                resultForUser = counterForUser + 1;
            }
            if (inputUser == "papper" && randomChoiceApp == "scissors")
            {
                Console.WriteLine($"The app has won ! User choice: {inputUser}, App choice: {randomChoiceApp}");
                resultForApp = counterForApp + 1;
            }
            if (inputUser == "papper" && randomChoiceApp == "papper")
            {
                Console.WriteLine($"It's a tie ! User choice: {inputUser}, App choice: {randomChoiceApp}");
            }
            if (inputUser == "scissors" && randomChoiceApp == "papper")
            {
                Console.WriteLine($"The user has won ! User choice: {inputUser}, App choice: {randomChoiceApp}");
                resultForUser = counterForUser + 1;
            }
            if (inputUser == "scissors" && randomChoiceApp == "scissors")
            {
                Console.WriteLine($"It's a tie! User choice: {inputUser}, App choice: {randomChoiceApp}");
            }
            if (inputUser == "scissors" && randomChoiceApp == "rock")
            {
                Console.WriteLine($"The app has won! User choice: {inputUser}, App choice: {randomChoiceApp}");
                resultForApp = counterForApp + 1;
            }
            //return $"User: {tuple.Item1}, App: {tuple.Item2}";
        }

        public static void StatisticsForUser(int timesPlayed, int userTimesWon, int appTimesWon)
        {
            var userWinRate = (userTimesWon / (double)timesPlayed) * 100;
            var userLoseRate = 100 - userWinRate;
            var tie = timesPlayed - (userTimesWon + appTimesWon);
            Console.WriteLine($"Times played: {timesPlayed}, User won: {userTimesWon}, Win rate: {userWinRate}%, Lose rate: {userLoseRate}%, App won: {appTimesWon}, Ties: {tie}");
        }
    }
}
