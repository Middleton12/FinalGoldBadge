using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_One_Menu
{
    public class MenuRepo
    {
        private List<Menu> _listOfMenuItems = new List<Menu>();


        public void AddMenuItemToList(Menu mealNumber)
        {
            _listOfMenuItems.Add(mealNumber);
        }

        public List<Menu> GetMenuItemList()
        {
            return _listOfMenuItems;
        }

        // Update

        public bool UpdateExistingMenuNumber(string existingMealNumber, Menu newMealNumber)
        {
            // Find the existing ingredients
            Menu oldMealNumber = GetMenu(existingMealNumber);


            // Update the ingredients
            if (oldMealNumber != null)
            {
                oldMealNumber.MealNumber = newMealNumber.MealNumber;
                oldMealNumber.MealName = newMealNumber.MealName;
                oldMealNumber.MealDescription = newMealNumber.MealDescription;
                oldMealNumber.Ingredients = newMealNumber.Ingredients;
                oldMealNumber.Price = newMealNumber.Price;

                return true;
            }
            else
            {
                return false;
            }
        }
        // Delete
        public bool RemoveMenuItem(string menuNumber)
        {
            Menu content = GetMenu(menuNumber);
            if (content == null)
            {
                return false;
            }
            int initalCount = _listOfMenuItems.Count;
            _listOfMenuItems.Remove(content);
            if (initalCount > _listOfMenuItems.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        //Helper Method
        public Menu GetMenu(string menuNumber)
        {
            foreach (Menu content in _listOfMenuItems)
            {
                if (content.MealNumber.ToLower() == menuNumber.ToLower())
                {
                    return content;
                }
            }
            return null;
        }
    }
}
}
