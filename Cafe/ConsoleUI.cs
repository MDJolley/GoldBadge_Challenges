using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafe
{
    class ConsoleUI
    {
        readonly MenuRepo _Repo = new MenuRepo();

        public void Run()
        {
            Console.Clear();
            Console.WriteLine("Welcome to Cafe console.  What would you like to do?  [number]  \n" +
                "[1] View Menu.   \n" +
                "[2] Add new meal to menu.  \n" +
                "[3] Remove meal from menu. \n" +
                "[4] Edit exsisting meal.   \n" +
                "[5] View meal by number.   \n" +
                "[6] Exit.");

            switch (Console.ReadKey().KeyChar)
            {
                case '1':
                    Console.Clear();
                    List<Meal> menu = _Repo.GetAllMeals();
                    foreach(Meal meal in menu)
                    {
                        Console.WriteLine($"{meal.number} -- {meal.name}");
                    }
                    Console.WriteLine("Press any key to continue.");
                    Console.ReadKey();
                    Run();
                    break;
                case '2':
                    Console.Clear();
                    Console.WriteLine("Adding new meal!    \n" +
                        "Enter new meal name.");
                    string name = Console.ReadLine().ToString();
                    Console.WriteLine("Enter meal number.");
                    int numb = int.Parse(Console.ReadLine());
                    Console.WriteLine("Enter meal price.");
                    double price = double.Parse(Console.ReadLine());
                    Console.WriteLine("Enter meal description.");
                    string description = Console.ReadLine();
                    Console.WriteLine("Enter ingredients separated by comma.  [lettuce,tomato]");
                    List<string> ingredients = Console.ReadLine().Split(',').ToList();
                    Meal addThis = new Meal(name, numb, price, description, ingredients);
                    if (_Repo.AddMealToMenu(addThis))
                    {
                        Console.WriteLine("Meal successfully added.  \n" +
                            "Press any key to continue.");
                        Console.ReadKey();
                        Run();
                    } else
                    {
                        Console.WriteLine("There was an error adding your meal, please try again. \n" +
                            "Press any key to continue.");
                        Console.ReadKey();
                        Run();
                    }
                    break;
                case '3':
                    Console.Clear();
                    Console.WriteLine("Enter the number of the meal you would like to remove.");
                    List<Meal> menu1 = _Repo.GetAllMeals();
                    foreach (Meal meal in menu1)
                    {
                        Console.WriteLine($"{meal.number} -- {meal.name}");
                    }
                    int removeThis = int.Parse(Console.ReadLine());
                    if (_Repo.RemoveMealFromMenu(_Repo.GetMealByNumber(removeThis)))
                    {
                        Console.WriteLine("Meal successfully removed from menu.  \n" +
                            "Press any key to continue.");
                        Console.ReadKey();
                        Run();
                    } else
                    {
                        Console.WriteLine("There was an error removing meal from menu, please try again.  \n" +
                            "Press any key to continue.");
                        Console.ReadKey();
                        Run();
                    }

                    Console.ReadKey();
                    Run();
                    break;
                case '4':
                    Console.Clear();
                    Console.WriteLine("Enter the number of the meal you would like to edit.");
                    List<Meal> options1 = _Repo.GetAllMeals();
                    foreach (Meal option in options1)
                    {
                        Console.WriteLine($"[{option.number}] {option.name}");
                    }
                    int input1 = int.Parse(Console.ReadLine());
                    Meal returned1 = _Repo.GetMealByNumber(input1);


                    Console.WriteLine($"Editing {returned1.name}!    \n" +
                        "Enter new name.");
                    string name1 = Console.ReadLine().ToString();
                    Console.WriteLine("Enter new number.");
                    int numb1 = int.Parse(Console.ReadLine());
                    Console.WriteLine("Enter new price.");
                    double price1 = double.Parse(Console.ReadLine());
                    Console.WriteLine("Enter new description.");
                    string description1 = Console.ReadLine();
                    Console.WriteLine("Enter new ingredients separated by comma.  [lettuce,tomato]");
                    List<string> ingredients1 = Console.ReadLine().Split(',').ToList();
                    Meal updated = new Meal(name1, numb1, price1, description1, ingredients1);
                    if (_Repo.UpdateMeal(input1, updated))
                    {
                        Console.WriteLine("Meal successfully updated.  \n" +
                            "Press any key to continue.");
                        Console.ReadKey();
                        Run();
                    }
                    else
                    {
                        Console.WriteLine("There was an error updating your meal, please try again. \n" +
                            "Press any key to continue.");
                        Console.ReadKey();
                        Run();
                    }






                    break;
                case '5':
                    Console.Clear();
                    List<Meal> options = _Repo.GetAllMeals();
                    
                    if (options.Count == 0)
                    {
                        Console.WriteLine("Menu is empty; add some meals.  \n" +
                            "Returning to main menu in 5");
                        System.Threading.Thread.Sleep(1000);
                        Console.Clear();
                        Console.WriteLine("Menu is empty; add some meals.  \n" +
                            "Returning to main menu in 4");
                        System.Threading.Thread.Sleep(1000);
                        Console.Clear();
                        Console.WriteLine("Menu is empty; add some meals.  \n" +
                            "Returning to main menu in 3");
                        System.Threading.Thread.Sleep(1000);
                        Console.Clear();
                        Console.WriteLine("Menu is empty; add some meals.  \n" +
                            "Returning to main menu in 2");
                        System.Threading.Thread.Sleep(1000);
                        Console.Clear();
                        Console.WriteLine("Menu is empty; add some meals.  \n" +
                            "Returning to main menu in 1");
                        System.Threading.Thread.Sleep(1000);
                        Run();
                    }
                    else
                    {
                        foreach (Meal option in options)
                        {
                            Console.WriteLine($"[{option.number}] {option.name}");
                        }
                    }
                    Console.WriteLine("Which menu item would you like to view?");
                    int input = int.Parse(Console.ReadLine());
                    Meal returned = _Repo.GetMealByNumber(input);
                    Console.Clear();
                    Console.WriteLine($"Meal number = {returned.number}  \n" +
                        $"Meal name = {returned.name}   \n" +
                        $"Meal price = {returned.price}  \n" +
                        $"Meal description = {returned.description}  \n" +
                        $"Meal ingredients = {string.Join(", ", returned.ingredients)} \n" +
                        $"Press any key to continue.");
                    Console.ReadKey();
                    Run();
                    break;
                case '6':
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid response, try again.");
                    Run();
                    break;
            }



        }
    }
}
