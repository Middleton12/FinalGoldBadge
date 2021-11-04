using Challenge_One_Menu;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Challenge_One_Tests
{
    [TestClass]
    public class UnitTest1
    {
        private Menu _content;
        private MenuRepo _repository;
        [TestInitialize]
        public void Arrange()
        {
            //Arrange method to avoid adding to each test
            _content = new Menu();
            _repository = new MenuRepo();

            //Adding the menu items
            _content.Ingredients = "Burger, bun, lettuce";
            _content.Price = 9.99;
            _content.MealDescription = "Burger on a bun";
            _content.MealNumber = "1";
            _content.MealName = "Burger";

            //adding it to the repository
            _repository.AddMenuItemToList(_content);
        }
        [TestMethod]
        public void MealNumberTest()
        {
            Menu content = new Menu();
            content.MealNumber = "1";
            string actual = content.MealNumber;
            string expected = "1";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void IngredientTest()
        {
            Menu content = new Menu();
            content.Ingredients = "Beef Patty, Cheese, lettuce, tomato, onion, bun";
            string actual = content.Ingredients;
            string expected = "Beef Patty, Cheese, lettuce, tomato, onion, bun";
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void PriceTest()
        {
            Menu content = new Menu();
            content.Price = 10.99;
            double actual = content.Price;
            double expected = 10.99;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void MealNameTest()
        {
            Menu content = new Menu();
            content.MealName = "Cheese Burger";
            string actual = content.MealName;
            string expected = "Cheese Burger";
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void MealDescriptionTest()
        {
            Menu content = new Menu();
            content.MealDescription = "Cheese Burger with lettuce, tomato, onion";
            string actual = content.MealDescription;
            string expected = "Cheese Burger with lettuce, tomato, onion";
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void AddMenuItemShouldNotGetNull()
        {
            //checking to be sure it was in the menu
            string actual = _content.MealNumber;
            string expected = "1";
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void UpdateExistingMenuNumberTest()
        {

            //updating the meal number from 1 to 3
            Menu content1 = new Menu();

            content1.Ingredients = "Burger, bun, lettuce";
            content1.Price = 9.99;
            content1.MealDescription = "Burger on a bun ";
            content1.MealNumber = "3";
            content1.MealName = "Burger";
            _repository.UpdateExistingMenuNumber(_content.MealNumber, content1);

            //checking to be sure it updated from 1 to 3
            Assert.AreEqual(_content.MealNumber, content1.MealNumber);
        }
        [TestMethod]
        public void DeleteMenuItemTest()
        {

            //deleting from repository
            _repository.RemoveMenuItem("1");
            string menuNumber = "1";

            //Assert the it is deleted
            Menu content = _repository.GetMenu(menuNumber);
            if (content == null)
            {
                Console.WriteLine("item deleted");
            }
            else
            {
                Console.WriteLine("Item still there");
            }
        }
    }
}

