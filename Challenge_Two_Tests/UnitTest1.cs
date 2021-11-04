using Challenge_Two_Repo;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Challenge_Two_Tests
{
    [TestClass]
    public class UnitTest1
    {
        private ClaimsRepo _repository;
        private Claims _content;

        [TestInitialize]
        public void Arrange()
        {
            //Arrange method to avoid adding info for each test
            _content = new Claims();
            _repository = new ClaimsRepo();

            //Adding claims
            _content.ClaimAmount = 2000.00;
            _content.ClaimID = "123";
            _content.DateOfClaim = new DateTime(2018, 04, 27).Date;
            _content.DateOfIncident = new DateTime(2018, 4, 25).Date;
            _content.IsValid = true;
            _content.TypeOfClaim = (ClaimType.Car);
            _content.Description = "Wreck on 465";

            _repository.AddNewClaimToQueue(_content);
        }

        [TestMethod]

        public void AddClaimToQueueTest()
        {
            //assign new claim to properties
            _content.ClaimAmount = 2000.00;
            _content.ClaimID = "234";
            _content.DateOfClaim = new DateTime(2020, 04, 27).Date;
            _content.DateOfIncident = new DateTime(2020, 4, 25).Date;
            _content.IsValid = true;
            _content.TypeOfClaim = (ClaimType.Home);
            _content.Description = "House fire in kitchen";

            //add to queuebadge
            _repository.AddNewClaimToQueue(_content);

            string actual = _content.ClaimID;
            string expected = "234";
            Assert.AreEqual(expected, actual);
        }
    }
}

