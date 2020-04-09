using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafe
{
    public class MenuRepo
    {
        protected readonly List<Meal> _menu = new List<Meal>();

        public void Add(Meal meal) => _menu.Add(meal);
        public List<Meal> GetAllMeals() => _menu;
        public Meal GetMealByNumber(int x)
        {
            foreach (Meal meal in _menu)
            {
                if (x == meal.number)
                {
                    return meal;
                }
            }
            return null;
        }
        public bool AddMealToMenu(Meal meal)
        {
            int startingCount = _menu.Count;
            _menu.Add(meal);
            if (_menu.Count > startingCount) { return true; }
            else { return false; }

        }
        public bool RemoveMealFromMenu(Meal meal)
        {
            bool removed = _menu.Remove(meal);
            return removed;
        }
        public bool UpdateMeal(int oldNumber, Meal newMeal)
        {
            Meal oldMeal = GetMealByNumber(oldNumber);
            oldMeal.name = newMeal.name;
            oldMeal.number = newMeal.number;
            oldMeal.description = newMeal.description;
            oldMeal.ingredients = newMeal.ingredients;
            oldMeal.price = newMeal.price;
            if (oldMeal == null) { return false; }
            else { return true; }

        }

    }
}
