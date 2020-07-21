using SEDC.TimeTrackingApp.Models.DB;
using SEDC.TimeTrackingApp.Models.Entities;
using SEDC.TimeTrackingApp.Models.Models;
using SEDC.TimeTrackingApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;

namespace SEDC.TimeTrackingApp.Services.Activities
{
    [Serializable]
    public class HobiesServices<T> : IStatisticInterface where T : Hobie
    {
        public ActivitiesDb<Hobie> _hobiesDb;

        public HobiesServices()
        {
            if (!File.Exists("hobies.txt"))
            {
                _hobiesDb = new ActivitiesDb<Hobie>();
                return;
            }

            var formatter = new BinaryFormatter();

            using (var stream = new FileStream("hobies.txt", FileMode.Open, FileAccess.Read))
            {
                _hobiesDb = (ActivitiesDb<Hobie>)formatter.Deserialize(stream);
            }

            if (_hobiesDb == null)
            {
                _hobiesDb = new ActivitiesDb<Hobie>();
            }
        }

        public void InsertHobies(Hobie hobie)
        {
            _hobiesDb.InsertActivity(hobie);
            this.SaveHobie();
        }
        private void SaveHobie()
        {
            var formatter = new BinaryFormatter();
            using (var stream = new FileStream("hobies.txt", FileMode.Create, FileAccess.Write))
            {
                formatter.Serialize(stream, _hobiesDb);
                stream.Close();
            }
        }

        public Hobie GetHobie(string name)
        {
            return _hobiesDb.GetAllActivities().FirstOrDefault(x => x.NameOfHobie == name);
        }
        public int TotalSeconds()
        {
            return _hobiesDb.GetAllActivities().Sum(x => x.TimeSpentInSeconds);
        }

        public void Statistics(User user)
        {
            var listOfOtherHobbies = _hobiesDb.GetAllActivities().Where(x => x.User.Id == user.Id).ToList();
            int totalTimeInSeconds = 0;
            List<string> nameOfHobbies = new List<string>();

            for (int i = 0; i < listOfOtherHobbies.Count; i++)
            {
                totalTimeInSeconds += listOfOtherHobbies[i].TimeSpentInSeconds;
                nameOfHobbies.Add(listOfOtherHobbies[i].NameOfHobie + ",");

            }

            if (listOfOtherHobbies.Count != 0)
            {
                Console.WriteLine($"Total time: {totalTimeInSeconds / 3600} hours");
                Console.WriteLine($"Average time: {totalTimeInSeconds / listOfOtherHobbies.Count /60} minutes");
                List<string> finalListWithHobbies = nameOfHobbies.Distinct().ToList();
                Console.Write($"Name of new Hobbies:");
                finalListWithHobbies.ForEach(i => Console.Write(i));
            }
            else
            {
                Console.WriteLine("You haven't done any hobby yet");
            }
        }
    }
}
