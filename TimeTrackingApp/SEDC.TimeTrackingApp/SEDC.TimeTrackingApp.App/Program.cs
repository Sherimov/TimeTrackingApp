using SEDC.TimeTrackingApp.Models.Entities;
using SEDC.TimeTrackingApp.Models.Enum;
using SEDC.TimeTrackingApp.Models.Models;
using SEDC.TimeTrackingApp.Services.Activities;
using SEDC.TimeTrackingApp.Services.Helpers;
using SEDC.TimeTrackingApp.Services.Interfaces;
using SEDC.TimeTrackingApp.Services.Menus;
using SEDC.TimeTrackingApp.Services.UserServices;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;

namespace SEDC.TimeTrackingApp.App
{
    class Program
    {
        public static IUserService _userService = new UserServices();
        public static ActivitiesServices _activitiesService = new ActivitiesServices();
        public static Imenus _menus = new Menus();
        public static ExercisingServices<Exercising> _exercisingService = new ExercisingServices<Exercising>();
        public static HobiesServices<Hobie> _hobiesService = new HobiesServices<Hobie>();
        public static ReadingServices<Reading> _readingService = new ReadingServices<Reading>();
        public static WorkingServices<Working> _workingService = new WorkingServices<Working>();
        public static User _user;
        private static readonly Stopwatch _stopwatch = new Stopwatch();
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                int registerOrLoginChoise = _menus.LogInOrRegisterMenu();
                while (true)
                {
                    if (registerOrLoginChoise == 1)
                    {
                        _user = _userService.LogIn();
                        if (_user == null) Environment.Exit(0);
                        break;
                    }
                    else
                    {
                        Console.Clear();
                        _user = _userService.Register();
                        if (_user == null) continue;
                        break;
                    }
                }
                Console.Clear();
                bool mainMenu = true;
                while (mainMenu)
                {
                    Console.Clear();
                    switch (_menus.MainMenu())
                    {
                        case 1:
                            //Track time
                            bool trackMenu = true;
                            while (trackMenu)
                            {
                                Console.Clear();
                                switch (_menus.TrackMenu())
                                {
                                    case 1:
                                        //Reading
                                        Reading reading = new Reading();
                                        reading.User = _user;
                                        var timeSpentReading = _activitiesService.TimeSpentOnActivity("reading", _stopwatch);
                                        reading.TimeSpentInSeconds += timeSpentReading;
                                        MessageHelper.Color("Please enter number of pages that you have read", ConsoleColor.Green);
                                        int numberOfPages;
                                        var isNumber = int.TryParse(Console.ReadLine(), out numberOfPages);
                                        reading.Pages =numberOfPages;
                                        switch (_menus.ReadingMenu())
                                        {
                                            case 1:
                                                reading.GenreOfBook = GenreOfBook.BellesLettres;
                                                break;
                                            case 2:
                                                reading.GenreOfBook = GenreOfBook.Fiction;
                                                break;
                                            case 3:
                                                reading.GenreOfBook = GenreOfBook.ProfessionalLiterature;
                                                break;
                                        }
                                        _readingService.InsertReading(reading);
                                        MessageHelper.Color($"{_user.LastName} you have been reading for {reading.TimeSpentInSeconds} seconds and you read {reading.Pages} pages from the book that has genre {reading.GenreOfBook}", ConsoleColor.Yellow);
                                        Thread.Sleep(3000);
                                        break;
                                    case 2:
                                        //Excercising
                                        Exercising exercise = new Exercising();
                                        exercise.User = _user;
                                        var timeSpentExercising = _activitiesService.TimeSpentOnActivity("exercising", _stopwatch);
                                        exercise.TimeSpentInSeconds += timeSpentExercising;
                                        switch (_menus.ExerciseMenu())
                                        {
                                            case 1:
                                                exercise.TypeOfExercise = TypeOfExercise.General;
                                                break;
                                            case 2:
                                                exercise.TypeOfExercise = TypeOfExercise.Running;
                                                break;
                                            case 3:
                                                exercise.TypeOfExercise = TypeOfExercise.Sport;
                                                break;
                                        }
                                        _exercisingService.StartExercise(exercise);
                                        MessageHelper.Color($"{_user.LastName} you have been doing {exercise.TypeOfExercise} exercise for {exercise.TimeSpentInSeconds} seconds", ConsoleColor.Yellow);
                                        Thread.Sleep(3000);
                                        break;
                                    case 3:
                                        //Working
                                        Working working = new Working();
                                        working.User = _user;
                                        var timeSpentWorking = _activitiesService.TimeSpentOnActivity("working", _stopwatch);
                                        working.TimeSpentInSeconds += timeSpentWorking;
                                        switch (_menus.WorkingMenu())
                                        {
                                            case 1:
                                                working.WorkingFrom = WorkingFrom.Office;
                                                break;
                                            case 2:
                                                working.WorkingFrom = WorkingFrom.Home;
                                                break;
                                        }
                                        _workingService.InsertWork(working);
                                        MessageHelper.Color($"{_user.LastName} you have been working from {working.WorkingFrom} for {working.TimeSpentInSeconds} seconds", ConsoleColor.Yellow);
                                        Thread.Sleep(3000);
                                        break;
                                    case 4:
                                        //Hobies                                        
                                        MessageHelper.Color("What's the name of the new Hobby?", ConsoleColor.Green);
                                        var nameOfHobie = Console.ReadLine();
                                        Hobie hobie = _hobiesService.GetHobie(nameOfHobie) ?? new Hobie();
                                        hobie.User = _user;
                                        var timeSpentOnHobie = _activitiesService.TimeSpentOnActivity("hobie", _stopwatch);
                                        hobie.TimeSpentInSeconds += timeSpentOnHobie;
                                        _hobiesService.InsertHobies(hobie);
                                        MessageHelper.Color($"{_user.LastName} you have been doing your new hobbie {hobie.NameOfHobie} for {hobie.TimeSpentInSeconds} seconds", ConsoleColor.Yellow);
                                        Thread.Sleep(3000);
                                        break;
                                    case 5:
                                        MessageHelper.Color("Going back to Main Menu!", ConsoleColor.Green);
                                        Thread.Sleep(2000);
                                        trackMenu = false;
                                        break;
                                }
                            }
                            break;
                        case 2:
                            //Statistics
                            bool StatsMenu = true;
                            while (StatsMenu)
                            {
                                Console.Clear();
                                switch (_menus.StatsMenu())
                                {
                                    case 1:
                                        //Reading Stats
                                        _readingService.Statistics(_user);
                                        MessageHelper.Color("Press any key to go back", ConsoleColor.Red);
                                        Console.ReadLine();
                                        break;
                                    case 2:
                                        //Exercising stats
                                        _exercisingService.Statistics(_user);
                                        MessageHelper.Color("Press any key to go back", ConsoleColor.Red);
                                        Console.ReadLine();
                                        break;
                                    case 3:
                                        //Working stats
                                        _workingService.Statistics(_user);
                                        MessageHelper.Color("Press any key to go back", ConsoleColor.Red);
                                        Console.ReadLine();
                                        break;
                                    case 4:
                                        //OtherHobbies stats
                                        _hobiesService.Statistics(_user);
                                        MessageHelper.Color("Press any key to go back", ConsoleColor.Red);
                                        Console.ReadLine();
                                        break;
                                    case 5:
                                        //Global stats
                                        Dictionary<string, int> dict = new Dictionary<string, int>();
                                        dict.Add("Reading", _readingService.TotalSeconds());
                                        dict.Add("Working", _workingService.TotalSeconds());
                                        dict.Add("Hobies", _hobiesService.TotalSeconds());
                                        dict.Add("Exercise", _exercisingService.TotalSeconds());

                                        var favouriteActivity = dict.Aggregate((l, r) => l.Value > r.Value ? l : r);
                                        var totalActiviyTime = dict.Sum(x => x.Value);

                                        Console.WriteLine($"Total activity time: {totalActiviyTime / (double)3600 } hours");

                                        if (favouriteActivity.Value == 0)
                                        {
                                            Console.WriteLine("You don't have favorite activity yet");
                                        }
                                        else
                                        {
                                            Console.WriteLine("Favorite activity: " + favouriteActivity.Key);
                                        }

                                        MessageHelper.Color("Press any key to go back", ConsoleColor.Red);
                                        Console.ReadLine();
                                        break;
                                    case 6:
                                        MessageHelper.Color("Going back to Main Menu!", ConsoleColor.Green);
                                        Thread.Sleep(2000);
                                        StatsMenu = false;
                                        break;
                                }
                            }
                            break;
                        case 3:
                            //Acc Management
                            bool manageAccaount = true;
                            while (manageAccaount)
                            {
                                Console.Clear();
                                switch (_menus.AccManagement())
                                {
                                    case 1:
                                        //change password
                                        Console.Clear();
                                        Console.WriteLine($"Mr. {_user.LastName}, please enter new password");
                                        _userService.ChangePassword(_user.Id, _user.Password, Console.ReadLine());
                                        break;
                                    case 2:
                                        //change First and Last Name
                                        Console.Clear();
                                        Console.WriteLine("Please enter new First name");
                                        string firstName = Console.ReadLine();
                                        Console.WriteLine("Please enter new Last name");
                                        string lastName = Console.ReadLine();
                                        _userService.ChangeInfo(_user.Id, firstName, lastName);
                                        break;
                                    case 3:
                                        Console.Clear();
                                        _userService.RemoveUser(_user.Id);
                                        Console.WriteLine("Deactivating the account. Thank you for using our service");
                                       
                                        MessageHelper.Color("The account has been deactivated", ConsoleColor.Red);
                                        mainMenu = false;
                                        break;
                                    case 4:
                                        MessageHelper.Color("Going back to Main Menu!", ConsoleColor.Green);
                                        Thread.Sleep(2000);
                                        manageAccaount = false;
                                        break;
                                }
                            }
                            break;
                        case 4:
                            _user = null;
                            MessageHelper.Color("Thank you for using our application! Have a good day!", ConsoleColor.Green);
                            mainMenu = false;
                            break;
                    }
                }
            }

        }
    }
}
