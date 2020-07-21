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

namespace SEDC.TimeTrackingApp.Services.Activities
{
    [Serializable]
    public class ReadingServices<T> : IStatisticInterface where T : Reading
    {
        private ActivitiesDb<Reading> _readingDb;
        public ReadingServices()
        {
            if (!File.Exists("reading.txt"))
            {
                _readingDb = new ActivitiesDb<Reading>();
                return;
            }

            var formatter = new BinaryFormatter();

            using (var stream = new FileStream("reading.txt", FileMode.Open, FileAccess.Read))
            {
                _readingDb = (ActivitiesDb<Reading>)formatter.Deserialize(stream);
            }

            if (_readingDb == null)
            {
                _readingDb = new ActivitiesDb<Reading>();
            }
        }

        public void InsertReading(Reading reading)
        {
            _readingDb.InsertActivity(reading);
            this.SaveReading();
        }

        private void SaveReading()
        {
            var formatter = new BinaryFormatter();

            using (var stream = new FileStream("reading.txt", FileMode.Create, FileAccess.Write))
            {
                formatter.Serialize(stream, _readingDb);
                stream.Close();
            }
        }
        public int TotalSeconds()
        {
            return _readingDb.GetAllActivities().Sum(x => x.TimeSpentInSeconds);
        }

        public void Statistics(User user)
        {
            var listOfReadings = _readingDb.GetAllActivities().Where(x => x.User.Id == user.Id).ToList();
            double totalTimeInSeconds = 0;
            int totalPages = 0;
            int bellesLettresType = 0;
            int fictionType = 0;
            int proffesionalLiteratureType = 0;

            for (int i = 0; i < listOfReadings.Count; i++)
            {
                totalTimeInSeconds += listOfReadings[i].TimeSpentInSeconds;
                totalPages += listOfReadings[i].Pages;
                if (listOfReadings[i].GenreOfBook.ToString().ToLower() == "BellesLettres".ToLower())
                {
                    bellesLettresType++;
                }
                else if (listOfReadings[i].GenreOfBook.ToString().ToLower() == "Fiction".ToLower())
                {
                    fictionType++;
                }
                else
                {
                    proffesionalLiteratureType++;
                }
            }

            if (listOfReadings.Count != 0)
            {
                Console.WriteLine($"Total time: {totalTimeInSeconds / 3600} hours");
                Console.WriteLine($"Average time: {(totalTimeInSeconds / listOfReadings.Count) / 60} minutes");
                Console.WriteLine($"Total number of pages: {totalPages} pages");

                int mostUsedType = new List<int> { bellesLettresType, proffesionalLiteratureType, proffesionalLiteratureType }.Max();
                if (mostUsedType == bellesLettresType)
                {
                    Console.WriteLine("Favorite type: Belles Lettres");
                }
                else if (mostUsedType == proffesionalLiteratureType)
                {
                    Console.WriteLine("Favorite type: Proffecional Literature");
                }
                else if (mostUsedType == fictionType)
                {
                    Console.WriteLine("Favorite type: Fiction");
                }
            }
            else
            {
                Console.WriteLine("You haven't read anything yet");
            }
        }
    }
}
