using SEDC.TimeTrackingApp.Models.BaseModels;
using SEDC.TimeTrackingApp.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SEDC.TimeTrackingApp.Models.DB
{
    [Serializable]
    public class ActivitiesDb<T> : IActivitiesDb<T> where T : Activities
    {
        private List<T> _activities;

        public ActivitiesDb()
        {
            _activities = new List<T>();
        }


        public List<T> GetAllActivities()
        {
            return _activities;
        }

        public void InsertActivity(T activity)
        {
            _activities.Add(activity);
        }
    }
}
