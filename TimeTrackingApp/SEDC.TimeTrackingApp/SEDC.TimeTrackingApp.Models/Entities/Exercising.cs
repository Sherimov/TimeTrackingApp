using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using SEDC.TimeTrackingApp.Models.BaseModels;
using SEDC.TimeTrackingApp.Models.Enum;
using SEDC.TimeTrackingApp.Models.Models;

namespace SEDC.TimeTrackingApp.Models.Entities
{
    [Serializable]
    public class Exercising : Activities
    {
        public TypeOfExercise TypeOfExercise { get; set; }

        //public string PrintInfo(User user)
        //{
        //    return $"Today {user.FirstName} was doing {TypeOfExercise} excercise for {StopwatchTimeToString(TimeSpentInSeconds)}";
        //}
    }
}
