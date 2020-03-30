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
                string storageName = "";
                string storageLocation = "";

                for (int i = 0; i < placesAmount; i++)
                {
                    string defibliratorStorage = task.DefibliratorStorages[i];

                    int separatorIndex = defibliratorStorage.IndexOf(';');
                    string nameStorage = defibliratorStorage.Substring(0, separatorIndex);
                    defibliratorStorage = defibliratorStorage.Substring(separatorIndex + 1, defibliratorStorage.Length - separatorIndex - 1);

                    separatorIndex = defibliratorStorage.IndexOf(';');
                    string locationStorage = defibliratorStorage.Substring(0, separatorIndex);
                    defibliratorStorage = defibliratorStorage.Substring(separatorIndex + 1, defibliratorStorage.Length - separatorIndex - 1);

                    separatorIndex = defibliratorStorage.IndexOf(';');
                    float longitude = float.Parse(defibliratorStorage.Substring(0, separatorIndex));
                    defibliratorStorage = defibliratorStorage.Substring(separatorIndex + 1, defibliratorStorage.Length - separatorIndex - 1);

                    float latidute = float.Parse(defibliratorStorage);

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
                        storageName = nameStorage;
                        storageLocation = locationStorage;
                    }
                }

                return $"Name: {storageName}; Address: {storageLocation}";
            };

            Task3.CheckSolver(TaskSolver);
        }
    }
}
