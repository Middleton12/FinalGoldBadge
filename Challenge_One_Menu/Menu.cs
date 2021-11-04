using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_One_Menu
{
    public class Menu
    {
        public string Ingredients { get; set; }
        public double Price { get; set; }
        public string MealDescription { get; set; }
        public string MealNumber { get; set; }
        public string MealName { get; set; }
        public Menu() { }
        public Menu(string mealNumber, string mealName, string mealDescription, string ingredients, double price)
        {
            MealNumber = mealNumber;
            MealName = mealName;
            MealDescription = mealDescription;
            Ingredients = ingredients;
            Price = price;


        }
    }
}
