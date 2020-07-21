using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace SEDC.TimeTrackingApp.Services.Interfaces
{
    public interface IActivitiesServices
    {
        int TimeSpentOnActivity(string activity, Stopwatch stopwatch);
        double TotalActivityTime(List<double> list);

        
    }
}
