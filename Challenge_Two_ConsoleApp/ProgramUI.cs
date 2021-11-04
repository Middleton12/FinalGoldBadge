using Challenge_Two_Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_Two_ConsoleApp
{
    public class ProgramUI
    {
        private ClaimsRepo _claimsRepo = new ClaimsRepo();
        private ClaimsRepo _claimsQueue = new ClaimsRepo();
        public void Run()
        {
            SeedQueue();
            Menu();
        }
        //Menu
        private void Menu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                //Display our options to the user
                Console.WriteLine("Select a menu option:\n" +
                    "1. See all Claims\n" +
                    "2. Take care of the next claim\n" +
                    "3. Enter a new claim\n" +
                    "4. Exit");
                //Get user input
                string input = Console.ReadLine();

                //Evaluate the user's input and act accordingly
                switch (input)
                {
                    case "1":
                        DisplayClaimsQueue();
                        break;
                    case "2":
                        ViewAnItemInQueue();
                        break;
                    case "3":
                        AddNewClaimToQueue();
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
                Console.Clear();
            }
        }
        private void DisplayClaimsQueue()
        {
            Console.Clear();


            Queue<Claims> queueOfClaims = _claimsRepo.DisplayClaimsQueue();

            Console.WriteLine($"ClaimID\t" + "  Type  " + "  Description\t" + "         Amount\t" + "   DateOfIccident\t" + "" + "   DateOfClaim \t" + " Claim is Valid");

            foreach (Claims content in queueOfClaims)
            {
                Console.WriteLine($"{content.ClaimID}\t  { content.TypeOfClaim}\t  {content.Description}\t ${content.ClaimAmount}\t   {content.DateOfIncident.ToShortDateString()}\t\t   {content.DateOfClaim.ToShortDateString()}\t {content.IsValid}");
            }
        }
        private void ViewAnItemInQueue()
        {
            Console.Clear();
            Queue<Claims> queueOfClaims = _claimsRepo.DisplayClaimsQueue();

            //get the next item in queue
            Claims claim = queueOfClaims.Peek();

            Console.WriteLine($"ClaimID: {claim.ClaimID} Type:   {claim.TypeOfClaim }   Description:   {claim.Description}  Amount:$ {claim.ClaimAmount} DateOfIccident: {claim.DateOfIncident.ToShortDateString()} DateOfClaim: {claim.DateOfClaim}");


            //Ask if user wants to take care of next claim.  
            Console.WriteLine("\nDo you want to take car of this claim? (yes or no)");
            string delete = Console.ReadLine();
            bool finish = true;
            while (finish)
            {
                switch (delete)
                {
                    case "yes":
                        queueOfClaims.Dequeue();
                        finish = false;
                        break;
                    case "no":
                        finish = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid response: yes / no");
                        delete = Console.ReadLine();
                        break;
                }
            }
        }
        private void AddNewClaimToQueue()
        {
            Console.Clear();
            Claims newContent = new Claims();

            Queue<Claims> queueOfClaims = _claimsRepo.DisplayClaimsQueue();

            // Enter claim id
            Console.WriteLine("Enter the claim id:");
            string isUsed = Console.ReadLine();

            //Check to see if the claim id is already in use in the queue
            foreach (Claims claim in queueOfClaims)
            {
                while (isUsed == claim.ClaimID)
                {
                    Console.WriteLine("This ClaimID already is in use.\n" +
                        "  Please enter a valid ClaimID:");
                    isUsed = Console.ReadLine();
                }
            }
            newContent.ClaimID = isUsed;
            //Enter claim type
            Console.WriteLine("Enter the claim type:\n" +
                " 1-Auto\n" +
                " 2-Home\n" +
                " 3-Theft");
            string claimTypeAsString = Console.ReadLine();
            int claimTypeInt = int.Parse(claimTypeAsString);
            newContent.TypeOfClaim = (ClaimType)claimTypeInt;

            //Enter claim description max length of 21 characters

            Console.WriteLine("Enter the claim description: (max length 21 characters");
            string descript = Console.ReadLine();
            newContent.Description = descript;

            //Enter Claim Cost
            Console.WriteLine("Amount of Damage:");
            string amountAsString = Console.ReadLine();
            double claimAmountDouble = double.Parse(amountAsString);
            newContent.ClaimAmount = claimAmountDouble;
            //Enter date of incident
            Console.WriteLine("Date of Accident: (yyyy, mm, dd)");
            string dateOfIncident = Console.ReadLine();
            DateTime dateTimeIncident = DateTime.Parse(dateOfIncident);
            newContent.DateOfIncident = dateTimeIncident;


            //Enter date of Claim:
            Console.WriteLine("Date of Claim: (yyyy, mm, dd)");
            string dateOfClaim = Console.ReadLine();
            DateTime dateTimeClaim = DateTime.Parse(dateOfClaim);
            newContent.DateOfClaim = dateTimeClaim;

            //Calculate to see if the difference between incident and claim is < 30 days
            TimeSpan timeBetweeenIncidentClaim = dateTimeClaim - dateTimeIncident;

            double days1 = 30;
            double days = Math.Floor(days1);

            if (timeBetweeenIncidentClaim.TotalDays <= days)
            {
                newContent.IsValid = true;
            }
            else
            {
                newContent.IsValid = false;
            }
            _claimsRepo.AddNewClaimToQueue(newContent);
        }
        //Seed queue to start program
        private void SeedQueue()
        {
            Claims claims = new Claims(ClaimType.Car, "1", "Car accident on 465", 400.00, new DateTime(2018, 04, 25).Date, new DateTime(2018, 4, 27).Date, true);
            Claims claims1 = new Claims(ClaimType.Home, "2", "House fire in kitchen", 4000.00, new DateTime(2018, 04, 11).Date, new DateTime(2018, 04, 12).Date, true);
            Claims claims2 = new Claims(ClaimType.Theft, "3", "Stolen Pancakes", 4.00, new DateTime(2018, 04, 27), new DateTime(2018, 06, 01), false);

            _claimsRepo.AddNewClaimToQueue(claims);
            _claimsRepo.AddNewClaimToQueue(claims1);
            _claimsRepo.AddNewClaimToQueue(claims2);
        }
    }
}
}
