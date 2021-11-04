using Challenge_One_Menu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_One_ConsoleApp
{
    public class ProgramUI


    {
        private MenuRepo _komodoMenuRepo = new MenuRepo();

      

        // The Method to run/start the Komodo Menu applicationClassLibrary1
        public void Run()
        {
            SeedMenuList();
            Menu();
        }
        private void Menu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                //Display the menu options to the user
                Console.WriteLine("Select a menu option:\n" +
                    "1. Add Menu Item\n" +
                    "2. View All Menu Items\n" +
                    "3. View All Ingredients in Menu Item\n" +
                    "4. Update Existing Menu Item\n" +
                    "5. Delete Existing Menu Item\n" +
                    "6. Exit");

                // Get user's input
                string input = Console.ReadLine();

                //Evaluate user's input
                switch (input)
                {
                    case "1":
                        //Add new Menu Item
                        AddNewMenuItem();
                        break;
                    case "2":
                        //View All Menu Items
                        GetMenuItemList();
                        break;
                    case "3":
                        //View Ingredient List by Menu Item
                        GetIngredientList();
                        break;
                    case "4":
                        //Update Existing Menu Item
                        UpdateExistingMenuItem();
                        break;
                    case "5":
                        //Delete Existing Menu Item
                        DeleteMenuItem();
                        break;
                    case "6":
                        //Exit
                        Console.WriteLine("GoodBye!");
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid number.");
                        break;
                }
                Console.WriteLine("Please press any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }
        }
        // Add new Menu Item
        private void AddNewMenuItem()
        {
            Console.Clear();
            Menu newContent = new Menu();

            //Menu Item Number
            Console.WriteLine("Enter the Menu Item Number:");
            newContent.MealNumber = Console.ReadLine();

            //Menu Meal Name
            Console.WriteLine("Enter the Meal Name:");
            newContent.MealName = Console.ReadLine();

            //Meal Description
            Console.WriteLine("Enter the description for the meal:");
            newContent.MealDescription = Console.ReadLine();

            //Meal Ingredients
            Console.WriteLine("Enter the ingredients for the meal:");
            newContent.Ingredients = Console.ReadLine();

            //Meal Price
            Console.WriteLine("Enter the price of the meal:");
            string priceAsString = Console.ReadLine();
            newContent.Price = double.Parse(priceAsString);

            _komodoMenuRepo.AddMenuItemToList(newContent);
        }
        // View the List of Menu Items
        private void GetMenuItemList()
        {
            Console.Clear();
            List<Menu> listOfMenuItems = _komodoMenuRepo.GetMenuItemList();

            foreach (Menu content in listOfMenuItems)
            {
                Console.WriteLine($"Menu Item: {content.MealNumber}\n" +
                    $"Meal Name: {content.MealName}\n" +
                    $"Meal Description: {content.MealDescription}\n" +
                    $"Ingredients: {content.Ingredients}\n" +
                    $"Price: {content.Price}\n");
            }
        }
        // View Ingredient List by Menu Item
        private void GetIngredientList()                // NEEDS WORK
        {
            Console.Clear();
            //Prompt user to tell you which menu item to get and view
            Console.WriteLine("Enter the Menu Item Number you want to view: ");

            //Get users input
            string mealNumber = Console.ReadLine();

            //Find the meal by meal item


            Menu content = _komodoMenuRepo.GetMenu(mealNumber);


            // View ingredients by menu item number
            Console.WriteLine("The ingredients for meal number " + mealNumber + ": " + content.Ingredients);


        }

        private void UpdateExistingMenuItem()
        {
            //Display the Menu Items
            GetMenuItemList();

            //Ask for the Menu Item that is to be updated
            Console.WriteLine("Enter the Menu Item that is to be updated:");

            //set the menu item that you want changed
            string oldMealNumber = Console.ReadLine();

            // Build a new menu item
            Menu newContent = new Menu();

            //Meal Item
            Console.WriteLine("Enter the Meal Number: ");
            newContent.MealNumber = Console.ReadLine();

            //Meal Name
            Console.WriteLine("Enter the Meal Name: ");
            newContent.MealName = Console.ReadLine();

            //Meal Description
            Console.WriteLine("Enter the Meal Description: ");
            newContent.MealDescription = Console.ReadLine();

            //Ingredients in Meal
            Console.WriteLine("Enter the Meal Ingredients: ");
            newContent.Ingredients = Console.ReadLine();

            //Price of Meal
            Console.WriteLine("Enter the Meal Price: ");
            string priceAsString = Console.ReadLine();
            newContent.Price = double.Parse(priceAsString);

            //Assert the update worked
            bool wasUpdated = _komodoMenuRepo.UpdateExistingMenuNumber(oldMealNumber, newContent);

            if (wasUpdated)
            {
                Console.WriteLine("\nMenu Item was successfully updated!");
            }
            else
            {
                Console.WriteLine("\nCould not update the Menu Item.");
            }
        }
        //Delete Menu Item
        private void DeleteMenuItem()
        {
            GetMenuItemList();

            // Get menu number that user wants to delete
            Console.WriteLine("\nEnter the Menu Number you want to delete");
            string input = Console.ReadLine();

            //Call the remove method
            bool wasDeleted = _komodoMenuRepo.RemoveMenuItem(input);

            //If menu item removed say so and if not say that too
            if (wasDeleted)
            {
                Console.WriteLine("The Menu Item was successfully deleted.");
            }
            else
            {
                Console.WriteLine("The Menu Item could not be deleted.");
            }
        }
        //Seed the menu for a starter
        private void SeedMenuList()
        {
            //Assign enu items to be added at start program
            Menu CheeseBurger = new Menu("1", "Cheeseburger", "Cheeseburger with Sweet potato fries", "beef burger, cassava flour bun, manchego cheese, lettuce, tomato, onion, pickle", 10.99);
            Menu Burger = new Menu("2", "Burger", "Burger with fries", "beef burger, bun, lettuce, tomato, onion, pickle", 9.99);
            Menu ChickenSandwich = new Menu("3", "ChickenSandwich", "Chicken Sandwich with salad", "Chicken patty, bun, lettuce, tomato, onion, pickle, salad lettuce, carrots, cucumber, dressing", 11.99);
            Menu SaladWithBurger = new Menu("4", "Salad with a Burger", "Burger on Salad", "beef burger, lettuce-salad, carrots,cucumber, tomato, onion, dressing", 11.50);

            // Add menu to repo
            _komodoMenuRepo.AddMenuItemToList(CheeseBurger);
            _komodoMenuRepo.AddMenuItemToList(Burger);
            _komodoMenuRepo.AddMenuItemToList(ChickenSandwich);
            _komodoMenuRepo.AddMenuItemToList(SaladWithBurger); ;
        }

        private class MenuRepo
        {
        }
    }
}
}
