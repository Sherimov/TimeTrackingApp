using SEDC.TimeTrackingApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace SEDC.TimeTrackingApp.Services.Activities
{
    public class ActivitiesServices : IActivitiesServices
    {
        public void Statistics()
        {
            throw new NotImplementedException();
        }

        public int TimeSpentOnActivity(string activity, Stopwatch stopwatch)
        {
            stopwatch.Start();
            Console.WriteLine($"Started activity: {activity}");
            Console.WriteLine($"Press enter to stop {activity}");
            Console.ReadLine();
            stopwatch.Stop();

            Console.WriteLine("Activity ended");
            return stopwatch.Elapsed.Seconds;
        }

        public double TotalActivityTime(List<double> activities)
        {
            double totalTime = 0;
            foreach (var activity in activities)
            {
                totalTime += activity;
            }
            return totalTime / 3600;
        }
    }
}
