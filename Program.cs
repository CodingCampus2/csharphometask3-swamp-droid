using System;
using CodingCampusCSharpHomework;

namespace HomeworkTemplate
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<Task3, string> TaskSolver = task =>
            {
                // Your solution goes here
                // You can get all needed inputs from task.[Property]
                // Good luck!
                string UserLongitude = task.UserLongitude;
                string UserLatitude = task.UserLatitude;
                int placesAmount = task.DefibliratorStorages.Length;

                float minDistance = float.MaxValue;
                string nearestStorageName = "";
                string nearestStorageLocation = "";

                for (int i = 0; i < placesAmount; i++)
                {
                    string defibliratorStorage = task.DefibliratorStorages[i];

                    int lastSeparatorIndex = defibliratorStorage.LastIndexOf(';');
                    int secondSeparatorIndex = defibliratorStorage.Substring(0, lastSeparatorIndex - 1).LastIndexOf(';');
                    int firstSeparatorIndex = defibliratorStorage.IndexOf(';');

                    float longitude = float.Parse(defibliratorStorage.Substring(secondSeparatorIndex + 1, lastSeparatorIndex - secondSeparatorIndex - 1));
                    float latidute = float.Parse(defibliratorStorage.Substring(lastSeparatorIndex + 1, defibliratorStorage.Length - lastSeparatorIndex - 1));

                    float userLongitude = (float)(float.Parse(UserLongitude) * Math.PI / 180);
                    float userLatitude = (float)(float.Parse(UserLatitude) * Math.PI / 180);
                    longitude = (float)(longitude * Math.PI / 180);
                    latidute = (float)(latidute * Math.PI / 180);

                    float x = (longitude - userLongitude) * (float)Math.Cos((latidute + userLatitude)/2);
                    float y = (latidute - userLatitude);
                    float distance = (float)Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2)) * 6371;

                    if(distance < minDistance)
                    {
                        minDistance = distance;

                        nearestStorageName = defibliratorStorage.Substring(0, firstSeparatorIndex);
                        nearestStorageLocation = defibliratorStorage.Substring(firstSeparatorIndex + 1, secondSeparatorIndex - firstSeparatorIndex - 1);
                    }
                }

                return $"Name: {nearestStorageName}; Address: {nearestStorageLocation}";
            };

            Task3.CheckSolver(TaskSolver);
        }
    }
}
