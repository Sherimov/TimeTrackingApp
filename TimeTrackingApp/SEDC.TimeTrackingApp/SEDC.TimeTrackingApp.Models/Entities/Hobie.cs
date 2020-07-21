using SEDC.TimeTrackingApp.Models.BaseModels;
using SEDC.TimeTrackingApp.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SEDC.TimeTrackingApp.Models.Entities
{
    [Serializable]
    public class Hobie : Activities
    {
        public string NameOfHobie { get; set; }

        //public string GetInfo(User user)
        //{
        //    return ""; //$"Today {user.FirstName} desided to try {NameOfHobie} as a new hobby and was doing it for {StopwatchTimeToString(Stopwatch)}";
        //}
    }
}
