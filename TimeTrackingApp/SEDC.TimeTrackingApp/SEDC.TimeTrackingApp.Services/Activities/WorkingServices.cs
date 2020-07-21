using SEDC.TimeTrackingApp.Models.DB;
using SEDC.TimeTrackingApp.Models.Entities;
using SEDC.TimeTrackingApp.Models.Interfaces;
using SEDC.TimeTrackingApp.Models.Models;
using SEDC.TimeTrackingApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace SEDC.TimeTrackingApp.Services.Activities
{
    [Serializable]
    public class WorkingServices<T> : IStatisticInterface where T : Working
    {
        private ActivitiesDb<Working> _workingDb;

        public WorkingServices()
        {
            if (!File.Exists("working.txt"))
            {
                _workingDb = new ActivitiesDb<Working>();
                return;
            }

            var formatter = new BinaryFormatter();

            using (var stream = new FileStream("working.txt", FileMode.Open, FileAccess.Read))
            {
                _workingDb = (ActivitiesDb<Working>)formatter.Deserialize(stream);
            }

            if (_workingDb == null)
            {
                _workingDb = new ActivitiesDb<Working>();
            }
        }

        public void InsertWork(Working working)
        {
            _workingDb.InsertActivity(working);
            this.SaveWorking();
        }

        private void SaveWorking()
        {
            var formatter = new BinaryFormatter();

            using (var stream = new FileStream("working.txt", FileMode.Create, FileAccess.Write))
            {
                formatter.Serialize(stream, _workingDb);
                stream.Close();
            }
        }

        public int TotalSeconds()
        {
            return _workingDb.GetAllActivities().Sum(x => x.TimeSpentInSeconds);
        }
        public void Statistics(User user)
        {
            var listOfWorking = _workingDb.GetAllActivities().Where(x => x.User.Id == user.Id).ToList();
            double totalTimeInSeconds = 0;
            int homeType = 0;
            int officeType = 0;

            for (int i = 0; i < listOfWorking.Count; i++)
            {
                totalTimeInSeconds += listOfWorking[i].TimeSpentInSeconds;
                if (listOfWorking[i].WorkingFrom.ToString().ToLower() == "Home".ToLower())
                {
                    homeType++;
                }
                else
                {
                    officeType++;
                }
            }

            if (listOfWorking.Count != 0)
            {
                Console.WriteLine($"Total time: {totalTimeInSeconds / 3600 } hours");
                Console.WriteLine($"Average time: {(totalTimeInSeconds / listOfWorking.Count) / 60 } minutes");
                int mostUsedType = new List<int> { homeType, officeType }.Max();
                if (mostUsedType == 0)
                {
                    Console.WriteLine("No favorite type. Please do some work first");
                }
                else
                {
                    if (mostUsedType == homeType)
                    {
                        Console.WriteLine("Favorite place: Home");
                    }
                    else if (mostUsedType == officeType)
                    {
                        Console.WriteLine("Favorite place: Office");
                    }
                }
            }
            else
            {
                Console.WriteLine("You haven't done any work yet");
            }
        }
    }
}
