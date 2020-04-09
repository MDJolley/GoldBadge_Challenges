using System;
using System.Collections.Generic;
using Cafe;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Cafe_Tests
{
    [TestClass]
    public class MenuRepoTests
    {
        readonly static List<string> ing1 = new List<string>() { "burger", "pinapple", "avacado", "chicken", "lettuce", "cheese" };
        readonly static List<string> ing2 = new List<string>() { "burger", "bacon", "flame sauce", "lettuce", "tomato" };
        Meal aussieBurger = new Meal("Aussie Burger", 1, 5.99, "An Australian classic!", ing1);
        Meal flameThrower = new Meal("Flame Thrower", 2, 4.89, "Melt off your taste buds", ing2);

        [TestMethod]
        public void AddNewMeal_ShouldReturnTrue()
        {
            MenuRepo testRepo = new MenuRepo();
            testRepo.Add(aussieBurger);

            bool success = testRepo.AddMealToMenu(flameThrower);
            Assert.IsTrue(success);
        }

        [TestMethod]
        public void GetMeals_ShouldContainList()
        {
            MenuRepo testRepo = new MenuRepo();
            testRepo.AddMealToMenu(aussieBurger);
            testRepo.AddMealToMenu(flameThrower);
            List<Meal> testList = new List<Meal>();

            testList = testRepo.GetAllMeals();

            Assert.IsTrue(testList.Contains(aussieBurger));
        }

        [TestMethod]
        public void RemoveMeal_ShouldReturnTrue()
        {
            MenuRepo testRepo = new MenuRepo();
            testRepo.AddMealToMenu(aussieBurger);

            bool deleteresult = testRepo.RemoveMealFromMenu(aussieBurger);

            Assert.IsTrue(deleteresult);
        }

        [TestMethod]
        public void GetMealByNumber_ShouldContainItem()
        {
            MenuRepo testRepo = new MenuRepo();
            testRepo.AddMealToMenu(aussieBurger);
            List<Meal> returnedItems = new List<Meal>();

            returnedItems.Add(testRepo.GetMealByNumber(1));
            bool success = (returnedItems.Contains(aussieBurger)) ? true : false;

            Assert.IsTrue(success);

        }

        [TestMethod]
        public void UpdateMeal_ShouldReturnTrue()
        {
            MenuRepo testRepo = new MenuRepo();
            testRepo.AddMealToMenu(aussieBurger);

            bool success = testRepo.UpdateMeal(1, flameThrower);

            Assert.IsTrue(success);
        }
    }
}
