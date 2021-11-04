using Challenge_Three_Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_Three_ConsoleApp
{
    class ProgramUI
    {
        private BadgeRepo _badgeDictionary = new BadgeRepo();
        public void Run()
        {
            SeedDictionary();
            Menu();
        }
        //Menu
        private void Menu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                //Display our options to the user
                Console.WriteLine("\nHello Security Admin, What would you like to do?\n" +
                    "1. Add a badge.\n" +
                    "2. Edit a badge.\n" +
                    "3. List all Badges\n" +
                    "4. Exit");

                //Get user input
                string input = Console.ReadLine();

                //Evaluate the user input and act accordingly
                switch (input)
                {
                    case "1":
                        CreateANewBadge();
                        break;
                    case "2":
                        UpdateDoorsOnBadge();
                        break;
                    case "3":
                        ListOfBadges();
                        break;
                    case "4":
                        Console.WriteLine("GoodBye!");
                        keepRunning = false;
                        //Exit
                        break;
                    default:
                        Console.WriteLine("Please enter a valid number.");
                        break;
                }
                Console.WriteLine("\nPlease press any key to continue...");
                Console.ReadKey();
            }
        }
        //Add a new badge to dictionary
        private void CreateANewBadge()
        {
            Console.Clear();
            Badge newContent = new Badge();

            //Enter new badge ID
            Console.WriteLine("Enter the new badge ID:");
            string isUsedAsString = Console.ReadLine();
            int isUsedAsInt = int.Parse(isUsedAsString);


            Dictionary<int, Badge> badgeDictionary = _badgeDictionary.ShowBadgeDictionary();

            //Check to see if the badge ID is already in dictionary
            foreach (int ID in badgeDictionary.Keys)
            {
                while (isUsedAsInt == ID)
                {
                    Console.WriteLine("This BadgeID already is in use.\n" +
                        "  Please enter a valid BadgeID:");
                    isUsedAsString = Console.ReadLine();
                    isUsedAsInt = int.Parse(isUsedAsString);
                }
            }
            newContent.BadgeID = isUsedAsInt;
            //Get user input on the door names
            Console.WriteLine("Please enter a Door that needs access to:");
            string doorname = Console.ReadLine();
            newContent.ListOfDoorNames.Add(doorname);

            //Ask user if they want to add more door access
            Console.WriteLine("Do you want to add another door access? yes/no");
            string addMore = Console.ReadLine();

            while (addMore != "yes" && addMore != "no")
            {
                Console.WriteLine("Please enter yes or no");
                addMore = Console.ReadLine();
            }

            while (addMore == "yes")
            {
                Console.WriteLine("Please enter a Door that needs access to:");
                doorname = Console.ReadLine();
                newContent.ListOfDoorNames.Add(doorname);
                Console.WriteLine("Do you want to add another Door access?");
                addMore = Console.ReadLine();
                while (addMore != "yes" && addMore != "no")
                {
                    Console.WriteLine("Please enter yes or no");
                    addMore = Console.ReadLine();
                }
            }
            _badgeDictionary.CreateANewBadge(newContent);
        }
        //View list of Badges
        private void ListOfBadges()
        {
            Console.Clear();
            //Call up the dictionary
            Dictionary<int, Badge> badgeDictionary = _badgeDictionary.ShowBadgeDictionary();

            Console.WriteLine("List of Badges\n" +
                "\nBadge #        Door Access");
            foreach (KeyValuePair<int, Badge> ele in badgeDictionary)
            {
                Console.Write($"{ele.Key,-15}");
                foreach (var door in ele.Value.ListOfDoorNames)
                {
                    Console.Write($"{door} ");
                }
                Console.WriteLine();
            }
        }
        //Update a badge
        private void UpdateDoorsOnBadge()
        {
            Console.Clear();

            //Display the list of badge and doors
            ListOfBadges();

            //Get Users input
            Console.WriteLine("Which badge do you want to update?   Please list BadgeID");
            string updateID = Console.ReadLine();
            int updateIDAsInt = int.Parse(updateID);

            //Get Badge from the badgeID
            var badge4 = _badgeDictionary.GetBadge(updateIDAsInt);

            foreach (var door in badge4.ListOfDoorNames)
            {
                Console.Write($"{door} ");
            }
            Console.WriteLine();
            Console.WriteLine("What would you like to do?\n" +
                "1. Remove a door\n" +
                "2. Add a door\n" +
                "Please enter a number");
            string choice = Console.ReadLine();
            //Evaluate the choice
            switch (choice)
            {
                case "1":
                    Console.WriteLine("Which door do you want to remove");
                    string removeDoor = Console.ReadLine();
                    _badgeDictionary.DeleteDoorFromBadge(removeDoor);
                    break;
                case "2":
                    Console.WriteLine("What door would you like to add?");
                    string addDoor = Console.ReadLine();
                    _badgeDictionary.AddDoorsOnBadge(addDoor);
                    break;
                default:
                    Console.WriteLine("Please hit any key to continue..");
                    break;
            }
        }
        //Seed Dictionary
        private void SeedDictionary()
        {
            //create new badges to add to dictionary
            Badge badge1 = new Badge(123, new List<string> { "a1", "a2", "a3" });
            Badge badge2 = new Badge(234, new List<string> { "a1", "a4", "a6" });
            Badge badge3 = new Badge(345, new List<string> { "b2", "b4" });

            //Add badges to Dictionary
            _badgeDictionary.CreateANewBadge(badge1);
            _badgeDictionary.CreateANewBadge(badge2);
            _badgeDictionary.CreateANewBadge(badge3);
        }
    }
}
}
