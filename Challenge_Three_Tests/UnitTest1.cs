using Challenge_Three_Repo;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Challenge_Three_Tests
{
    [TestClass]
    public class BadgeTesting
    {
        private Badge _content;
        private BadgeRepo _repository;

        [TestInitialize]
        public void Arrange()
        {
            //Arrange method for all Badge tests
            _content = new Badge();
            _repository = new BadgeRepo();

            // Setting the information to add
            _content.BadgeID = 123;
            _content.ListOfDoorNames = new List<string> { "a1", "a2", "a3" };

            _repository.CreateANewBadge(_content);

        }

        [TestMethod]
        public void CreatNewBadgeTest()
        {
            _content.BadgeID = 456;
            _content.ListOfDoorNames = new List<string> { "a5", "a4", "b1" };

            _repository.CreateANewBadge(_content);

            int actual = _content.BadgeID;
            int expected = 456;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void AddADoorTest()
        {
            _content.BadgeID = 123;
            _content.ListOfDoorNames = new List<string> { "a4" };

            int beforeCount = _content.ListOfDoorNames.Count;
            _repository.AddDoorsOnBadge("a4");
            int afterCount = _content.ListOfDoorNames.Count;

            Assert.IsTrue(beforeCount < afterCount);

        }
        [TestMethod]
        public void RemoveDoorTest()
        {
            _content.BadgeID = 123;
            int beforeCount = _content.ListOfDoorNames.Count;
            _repository.DeleteDoorFromBadge("a3");
            int afterCount = _content.ListOfDoorNames.Count;
            Assert.IsTrue(beforeCount > afterCount);
        }
    }
}
