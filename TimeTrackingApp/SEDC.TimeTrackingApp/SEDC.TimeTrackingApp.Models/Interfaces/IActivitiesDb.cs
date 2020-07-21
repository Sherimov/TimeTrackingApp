using SEDC.TimeTrackingApp.Models.BaseModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace SEDC.TimeTrackingApp.Models.Interfaces
{
    public interface IActivitiesDb<T> where T : Activities
    {
        List<T> GetAllActivities();
        void InsertActivity(T activity);
    }
}
