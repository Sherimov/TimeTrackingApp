using System;
using System.Collections.Generic;
using System.Text;
using SEDC.TimeTrackingApp.Models.BaseModels;
using SEDC.TimeTrackingApp.Models.Enum;
using SEDC.TimeTrackingApp.Models.Models;

namespace SEDC.TimeTrackingApp.Models.Entities
{
    public class Reading : Activities
    {
        public int Pages { get; set; }
        public GenreOfBook GenreOfBook { get; set; }

        //public string GetInfo(User user)
        //{
        //    return "";// $"{user.FirstName} read {Pages} pages from the {GenreOfBook} for {StopwatchTimeToString(Stopwatch)}";
        //}
    }
}
