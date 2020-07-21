using SEDC.TimeTrackingApp.Models.DB;
using SEDC.TimeTrackingApp.Models.Entities;
using SEDC.TimeTrackingApp.Models.Interfaces;
using SEDC.TimeTrackingApp.Models.Models;
using SEDC.TimeTrackingApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace SEDC.TimeTrackingApp.Services.Activities
{
    [Serializable]
    public class ExercisingServices<T> : IStatisticInterface where T : Exercising
    {
        private ActivitiesDb<Exercising> _exercisingDb;

        public ExercisingServices()
        {
            if (!File.Exists("exercise.txt"))
            {
                _exercisingDb = new ActivitiesDb<Exercising>();
                return;
            }

            var formatter = new BinaryFormatter();

            using (var stream = new FileStream("exercise.txt", FileMode.Open, FileAccess.Read))
            {
                _exercisingDb = (ActivitiesDb<Exercising>)formatter.Deserialize(stream);
            }

            if (_exercisingDb == null)
            {
                _exercisingDb = new ActivitiesDb<Exercising>();
            }
        }

        public void StartExercise(Exercising exercise)
        {
            _exercisingDb.InsertActivity(exercise);
            this.SaveExercise();
        }

        private void SaveExercise()
        {
            var formatter = new BinaryFormatter();

            using (var stream = new FileStream("exercise.txt", FileMode.Create, FileAccess.Write))
            {
                formatter.Serialize(stream, _exercisingDb);
                stream.Close();
            }
        }

        public int TotalSeconds()
        {
            return _exercisingDb.GetAllActivities().Sum(x => x.TimeSpentInSeconds);
        }

        // POPRAVI
        public void Statistics(User user)
        {
            var listOfExercising = _exercisingDb.GetAllActivities().Where(x => x.User.Id == user.Id).ToList();
            double totalTimeInSeconds = 0;
            int generalType = 0;
            int runningType = 0;
            int sportType = 0;

            for (int i = 0; i < listOfExercising.Count; i++)
            {
                totalTimeInSeconds += listOfExercising[i].TimeSpentInSeconds;
                if (listOfExercising[i].TypeOfExercise.ToString().ToLower() == "General".ToLower())
                {
                    generalType++;
                }
                else if (listOfExercising[i].TypeOfExercise.ToString().ToLower() == "Running".ToLower())
                {
                    runningType++;
                }
                else
                {
                    sportType++;
                }
            }

            if (listOfExercising.Count != 0)
            {
                Console.WriteLine($"Total time: {totalTimeInSeconds / 3600} hours");
                Console.WriteLine($"Average time: {(totalTimeInSeconds / listOfExercising.Count) / 60} minutes");
                int mostUsedType = new List<int> { generalType, runningType, sportType }.Max();
                if (mostUsedType == generalType)
                {
                    Console.WriteLine("Favorite type: General");
                }
                else if (mostUsedType == runningType)
                {
                    Console.WriteLine("Favorite type: Running");
                }
                else if (mostUsedType == sportType)
                {
                    Console.WriteLine("Favorite type: Sport");
                }
            }
            else
            {
                Console.WriteLine("You haven't done any exercise yet");
            }
        }
    }
}
