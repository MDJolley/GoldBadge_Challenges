using System;
using System.Collections.Generic;
using Claims;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Claim = Claims.Claim;

namespace Claims_Tests
{
    [TestClass]
    public class Claims_Tests
    {
        Claim accident = new Claim(1, 4, new DateTime(06 / 02 / 2010), new DateTime(07 / 01 / 2010), "someone stole my pancake.", ClaimType.Theft);
        ClaimRepo _TestRepo = new ClaimRepo();

        [TestMethod]
        public void AddNewClaim_ShouldReturnTrue()
        {
            bool success = _TestRepo.NewClaim(5,new DateTime (06/12/2010), new DateTime (07/02/2010), "someone stole my pancakes.",ClaimType.Theft);
            Assert.IsTrue(success);
        }

        [TestMethod]
        public void AddExistingClaim_ShouldReturnTrue()
        {
            bool success = _TestRepo.NewClaim(accident);
            Assert.IsTrue(success);
        }

        [TestMethod]
        public void GetClaims_ListShouldNotBeEmpty()
        {
            _TestRepo.NewClaim(accident);
            List<Claim> testList = _TestRepo.GetClaims();
            bool success = (testList.Count > 0) ? true: false;
            Assert.IsTrue(success);
        }

        [TestMethod]
        public void Next_RetrunedClaimShouldNotBeNull()
        {
            _TestRepo.NewClaim(accident);
            Claim testClaim = _TestRepo.Next();
            bool success = (testClaim != null) ? true : false;
            Assert.IsTrue(success);
        }

        [TestMethod]
        public void Dealt_ShouldContainFewerClaims()
        {
            _TestRepo.NewClaim(accident);
            _TestRepo.Next();
            int startingCount = _TestRepo.GetClaims().Count;
            _TestRepo.Dealt();
            bool success = (startingCount > _TestRepo.GetClaims().Count) ? true : false;
            Assert.IsTrue(success);
        }
    }
}
