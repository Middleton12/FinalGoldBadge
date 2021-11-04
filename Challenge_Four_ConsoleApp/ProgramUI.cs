using Challenge_Four_Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_Four_ConsoleApp
{
    class ProgramUI
    {
        private OutingsRepository _outingsRepository = new OutingsRepository();
        private Outings _content;
        public void Run()
        {
            SeedOutingsList();
            Menu();
        }
        private void Menu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                //Menu for user to see the options for Events/Outings
                Console.WriteLine("Select an option from the menu:\n" +
                "1. Display the list of all Outings\n" +
                "2. Add a new Outing\n" +
                "3. Display Events by Event type\n" +
                "4. Display the total cost for the Outings by event type\n" +
                "5. Display the total cost for all Outings\n" +
                "6. Exit Menu");
                //Get users input
                string input = Console.ReadLine();
                //Evaluate the user input
                switch (input)
                {
                    case "1":
                        //Display the list of all Outings
                        DisplayEventList();
                        break;
                    case "2":
                        //Add new event
                        AddNewOuting();
                        break;
                    case "3":
                        //View Outing by Type
                        DisplayEventsByType();
                        break;
                    case "4":
                        //View total cost of Outings
                        DisplayCostEventsByType();
                        break;
                    case "5":
                        //Update Existing Menu Item
                        DisplayTotalCostAllEvents();
                        break;
                    case "6":
                        //Exit
                        Console.WriteLine("GoodBye!");
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("please enter a valid number.");
                        break;
                }
                Console.WriteLine("Please press any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }
        }
        private void DisplayEventList()
        {
            Console.Clear();
            //Get the event listing
            List<Outings> eventList = _outingsRepository.GetEventList();
            //Display the events
            Console.WriteLine("{0, -20} {1, -20} {2, -25} {3, -18} {4, -15}\n", "Type of Outing", "Date of Event", "Number of Attendees", "Cost per Person", "Total Cost of Event");

            foreach (Outings content in eventList)
            {
                Console.WriteLine("{0, -20} {1, -20} {2, -25} {3, -18} {4, -15}\n", $"{content.TypeOfEvent}", $"{content.DateOfEvent.ToShortDateString()}", $"{content.NumPeopleAttend}", $"${content.CostPerPerson}", $"${content.TotalCostEvent}");
            }

        }
        private void AddNewOuting()
        {
            Console.Clear();
            _content = new Outings();
            //Ask user what type of event to add
            Console.WriteLine("What type of outing would you like to add?\n" +
                "enter 1 for Golf\n" +
                "2 for Bowling\n" +
                "3 for Amusement Park\n" +
                "4 for Concert\n" +
                "5 for Other");
            //Evaluate input
            string input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    _content.TypeOfEvent = EventType.Golf;
                    break;
                case "2":
                    _content.TypeOfEvent = EventType.Bowling;
                    break;
                case "3":
                    _content.TypeOfEvent = EventType.Amusement_Park;
                    break;
                case "4":
                    _content.TypeOfEvent = EventType.Concert;
                    break;
                case "5":
                    _content.TypeOfEvent = EventType.Other;
                    break;
                default:
                    Console.WriteLine("please enter a valid number.");
                    break;
            }
            //Get the date of the event
            Console.WriteLine("Please enter the date in yyyy mm dd of the outing.");
            string dateOfEvent = Console.ReadLine();
            DateTime dateTimeNewEvent = DateTime.Parse(dateOfEvent);
            _content.DateOfEvent = dateTimeNewEvent;
            //Get the Cost Per Person
            Console.WriteLine("Please enter the cost per person for the outing");
            string costPerson = Console.ReadLine();
            _content.CostPerPerson = double.Parse(costPerson);
            //Get the number of people attending
            Console.WriteLine("How many people attended the outing?");
            string people = Console.ReadLine();
            _content.NumPeopleAttend = int.Parse(people);
            //Calculate the total cost of the event
            _content.TotalCostEvent = _outingsRepository.CalculateTotalCost(_content.NumPeopleAttend, _content.CostPerPerson);
            //Add the event to repository
            _outingsRepository.AddEventToList(_content);

        }
        private void DisplayEventsByType()
        {
            Console.Clear();
            //Get the event listing golf
            List<Outings> eventList = _outingsRepository.GetEventList();

            //Display the events grouped by type
            Console.Write("{0, -20}\n", "Type of Outing");

            //Console.WriteLine($"{0, -20}", $"{content.TypeOfEvent}");
            Outings expect = new Outings();
            expect.TypeOfEvent = EventType.Concert;
            foreach (Outings content in eventList)
            {
                bool cont = true;
                if (content.TypeOfEvent == expect.TypeOfEvent)
                {
                    Console.WriteLine("{0, -20} {1, -20} {2, -25} {3, -18} {4, -15}\n", $"{content.TypeOfEvent}", $"{content.DateOfEvent.ToShortDateString()}", $"{content.NumPeopleAttend}", $"${content.CostPerPerson}", $"${content.TotalCostEvent}");
                    cont = true;
                }
                else
                {
                    cont = false;
                }
            }
            //Display the golf outings
            expect.TypeOfEvent = EventType.Golf;
            foreach (Outings content in eventList)
            {
                bool cont = true;
                if (content.TypeOfEvent == expect.TypeOfEvent)
                {
                    Console.WriteLine("{0, -20} {1, -20} {2, -25} {3, -18} {4, -15}\n", $"{content.TypeOfEvent}", $"{content.DateOfEvent.ToShortDateString()}", $"{content.NumPeopleAttend}", $"${content.CostPerPerson}", $"${content.TotalCostEvent}");
                    cont = true;
                }
                else
                {
                    cont = false;
                }

            }
            //Display the Amusement Park outings
            expect.TypeOfEvent = EventType.Amusement_Park;
            foreach (Outings content in eventList)
            {
                bool cont = true;
                if (content.TypeOfEvent == expect.TypeOfEvent)
                {
                    Console.WriteLine("{0, -20} {1, -20} {2, -25} {3, -18} {4, -15}\n", $"{content.TypeOfEvent}", $"{content.DateOfEvent.ToShortDateString()}", $"{content.NumPeopleAttend}", $"${content.CostPerPerson}", $"${content.TotalCostEvent}");
                    cont = true;
                }
                else
                {
                    cont = false;
                }
            }
            //Display the Amusement Park outings
            expect.TypeOfEvent = EventType.Bowling;
            foreach (Outings content in eventList)
            {
                bool cont = true;
                if (content.TypeOfEvent == expect.TypeOfEvent)
                {
                    Console.WriteLine("{0, -20} {1, -20} {2, -25} {3, -18} {4, -15}\n", $"{content.TypeOfEvent}", $"{content.DateOfEvent.ToShortDateString()}", $"{content.NumPeopleAttend}", $"${content.CostPerPerson}", $"${content.TotalCostEvent}");
                    cont = true;
                }
                else
                {
                    cont = false;
                }
            }
            //Display the Amusement Park outings
            expect.TypeOfEvent = EventType.Other;
            foreach (Outings content in eventList)
            {
                bool cont = true;
                if (content.TypeOfEvent == expect.TypeOfEvent)
                {
                    Console.WriteLine("{0, -20} {1, -20} {2, -25} {3, -18} {4, -15}\n", $"{content.TypeOfEvent}", $"{content.DateOfEvent.ToShortDateString()}", $"{content.NumPeopleAttend}", $"${content.CostPerPerson}", $"${content.TotalCostEvent}");
                    cont = true;
                }
                else
                {
                    cont = false;
                }
            }
        }
        private void DisplayCostEventsByType()
        {
            Console.Clear();
            List<Outings> eventList = _outingsRepository.GetEventList();
            var totalGolf = 0.00;
            var totalBowling = 0.00;
            var totalAmusementPark = 0.00;
            var totalConcert = 0.00;
            var totalOther = 0.00;
            foreach (Outings content in eventList)
            {

                if (content.TypeOfEvent == EventType.Golf)
                {
                    totalGolf = totalGolf + content.TotalCostEvent;
                }
                else if (content.TypeOfEvent == EventType.Amusement_Park)
                {
                    totalAmusementPark += content.TotalCostEvent;
                }
                else if (content.TypeOfEvent == EventType.Concert)
                {
                    totalConcert += content.TotalCostEvent;
                }
                else if (content.TypeOfEvent == EventType.Other)
                {
                    totalOther += content.TotalCostEvent;
                }
                else
                {
                    totalBowling += content.TotalCostEvent;
                }
            }
            Console.WriteLine("{0, -29} {1, -15}", $"Outing Type", $" Cost");
            Console.WriteLine("{0, -30} {1, -15}", $"Total Golf Outings:", $"${totalGolf}\n");
            Console.WriteLine("{0, -30} {1, -15}", $"Total Bowling Outings:", $"${ totalBowling}\n");
            Console.WriteLine("{0, -30} {1, -15}", $"Total Concert Outings:", $"${ totalConcert}\n");
            Console.WriteLine("{0, -30} {1, -15}", $"Total Amusement Park Outings:", $"${totalAmusementPark}\n");
            Console.WriteLine("{0, -30} {1, -15}", $"Total Other Outings:", $"${ totalOther}\n");
        }
        private void DisplayTotalCostAllEvents()
        {
            Console.Clear();
            List<Outings> eventList = _outingsRepository.GetEventList();
            var totalCost = 0.00;
            foreach (Outings content in eventList)
            {
                totalCost += content.TotalCostEvent;
            }
            Console.WriteLine("Total Cost All Outings:$" + totalCost);
        }
        private void SeedOutingsList()
        {
            //Assign Outing to be added at the start of the program
            Outings event1 = new Outings(EventType.Golf, new DateTime(2020, 04, 26).Date, 42, 105.50, 4431.00);
            Outings event2 = new Outings(EventType.Bowling, new DateTime(2020, 12, 31).Date, 74, 65.20, 4824.80);
            Outings event3 = new Outings(EventType.Amusement_Park, new DateTime(2020, 5, 29).Date, 81, 110.10, 8918.10);
            Outings event4 = new Outings(EventType.Concert, new DateTime(2020, 7, 4).Date, 53, 49.99, 2649.47);
            Outings event5 = new Outings(EventType.Other, new DateTime(2020, 12, 4).Date, 22, 15.04, 330.08);
            //Add the Outings to the List
            _outingsRepository.AddEventToList(event1);
            _outingsRepository.AddEventToList(event2);
            _outingsRepository.AddEventToList(event3);
            _outingsRepository.AddEventToList(event4);
            _outingsRepository.AddEventToList(event5);
        }
    }
}
}
