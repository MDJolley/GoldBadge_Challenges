using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafe
{
    public class Meal
    {
        public string name { get; set; }
        public int number { get; set; }
        public double price { get; set; }
        public List<string> ingredients { get; set; }
        public string description { get; set; }

        public Meal() { }
        public Meal(string mname, int mnumber, double mprice, string mdescription, List<string> mingredients)
        {
            name = mname;
            number = mnumber;
            price = mprice;
            description = mdescription;
            ingredients = mingredients;
        }
    }

}
