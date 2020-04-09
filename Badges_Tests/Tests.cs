using System;
using System.Collections.Generic;
using Badges;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Badges_Tests
{
    [TestClass]
    public class Tests
    {
        BadgeRepo _TestRepo = new BadgeRepo();
        static List<string> doorList = new List<string>() { "A5", "D2", "D3" };
        Badge testBadge = new Badge(1, doorList);


        [TestMethod]
        public void AddBadge_ShouldReturnTrue()
        {
            Assert.IsTrue(_TestRepo.AddNewBadge(testBadge));
        }

        [TestMethod]
        public void RemoveBadge_ShouldReturnTrue()
        {
            _TestRepo.AddNewBadge(testBadge);
            Assert.IsTrue(_TestRepo.RemoveBadge(testBadge.ID));
        }

        [TestMethod]
        
        public void RemoveDoorFromBadge_ShouldReturnTrue()
        {
            _TestRepo.AddNewBadge(testBadge);
            Assert.IsTrue(_TestRepo.RemoveDoor(testBadge.ID,"A5"));
        }

        [TestMethod]
        public void AddDoorToBadge_ShouldReturnTrue()
        {
            _TestRepo.AddNewBadge(testBadge);
            Assert.IsTrue(_TestRepo.AddDoorToBadge(testBadge.ID, "B6"));
        }


    }
}
