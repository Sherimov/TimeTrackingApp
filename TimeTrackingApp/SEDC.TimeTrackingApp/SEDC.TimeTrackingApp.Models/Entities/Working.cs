using SEDC.TimeTrackingApp.Models.BaseModels;
using SEDC.TimeTrackingApp.Models.Enum;
using SEDC.TimeTrackingApp.Models.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace SEDC.TimeTrackingApp.Models.Entities
{
    public class Working : Activities
    {
        public WorkingFrom WorkingFrom { get; set; }

        //public string GetInfo(User user)
        //{
        //    return $"{user.FirstName} was working from {WorkingFrom} for {StopwatchTimeToString(TimeSpentInSeconds)}";
        //}

    }
}
