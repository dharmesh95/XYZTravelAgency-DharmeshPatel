using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XYZTravelAgency_Q5
{
    class Program
    {

        //List of all users int the file.
        private static List<User> clientList = new List<User>();

        //A list of all complete groups
        private static List<List<User>> completeGroups = new List<List<User>>();

        //A list of all incomplete groups
        private static List<List<User>> inCompleteGroups = new List<List<User>>();


        static void Main(string[] args)
        {
            Console.WriteLine("Enter Group Size:");
            int groupSize = Convert.ToInt32(Console.ReadLine());

            string path = @"data-file.txt";

            //Read text file
            using (StreamReader sr = new StreamReader(path))
            {
                string s;
                while ((s = sr.ReadLine()) != null)
                {
                    //Add item in file to list of user objects
                    clientList.Add(FileLineToUserInfo(s));
                }
            }

            //Randomize the user list
            Random rnd = new Random();
            var randomizedClients = clientList.OrderBy(a => rnd.Next());

            //FInd the groups of Travel Location/Date in the file
            var clientGroups = from client in randomizedClients
                               group client by new { package = client.Package , date = client.TravelDate };

            //For each group of location/date generate complete and incomplet lists based on group size
            foreach (var clientGroup in clientGroups)
            {
                var packageList = new List<User>();

                foreach (var client in clientGroup)
                {
                    packageList.Add(client);
                    if (packageList.Count == groupSize)
                    {
                        completeGroups.Add(packageList);
                        packageList = new List<User>();
                    }
                }

                if (packageList.Count < groupSize)
                {
                    inCompleteGroups.Add(packageList);
                }
            }

            //Display all complete groups
            foreach (var completeGroup in completeGroups)
            {
                Console.WriteLine("Complete Groups:");
                foreach (var client in completeGroup)
                {
                    Console.WriteLine($"Name: {client.Name} Package:{client.Package} Date{client.TravelDate}");
                }
            }

            //Display all incomplete groups
            foreach (var inCompleteGroup in inCompleteGroups)
            {
                Console.WriteLine("IN Complete Groups:");
                foreach (var client in inCompleteGroup)
                {
                    Console.WriteLine($"Name: {client.Name} Package: {client.Package} Date: {client.TravelDate}");
                }
            }
            Console.ReadKey();
        }

        //Converts a line in the file to a User object
        private static User FileLineToUserInfo(string s)
        {
            string[] lineItems = s.Split(',');
            User user = new User(lineItems[0].Trim() + " " + lineItems[1].Trim(), lineItems[2].Trim(), DateTime.Parse(lineItems[3].Trim()));
            return user;
        }
    }


}
