using SEDC.TimeTrackingApp.Models.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace SEDC.TimeTrackingApp.Models.BaseModels
{
    [Serializable]
    public class Activities
    {
        public int TimeSpentInSeconds { get; set; }

        public User User { get; set; }

        public string StopwatchTimeToString(int seconds)
        {
            // change
            return $"Your time for the actibity was {seconds/60} minutes and {seconds} seconds";
        }
    }
}
