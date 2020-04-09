using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Badges
{
    public class ConsoleUI
    {
        BadgeRepo _Repo = new BadgeRepo();
        public void Run()
        {
            Console.Clear();
            Console.WriteLine("Welcome to Komodo Insurance's Super Secure Door Privileges Console     \n" +
                "What would you like to do?  \n" +
                "[1] Create new badge.  \n" +
                "[2] Update existing badge.  \n" +
                "[3] Clear badge for new employee use.  \n" +
                "[4] View all badges. \n" +
                "[5] Exit menu.");

            switch (Console.ReadKey().KeyChar)
            {
                case '1':
                    BadgeCreation();
                    break;
                case '2':
                    UpdateBadge();
                    break;
                case '3':
                    ClearBadge();
                    break;
                case '4':
                    ViewBadges();
                    break;
                case '5':
                    Environment.Exit(0);
                    break;
                default:
                    Run();
                    break;
            }
        }

        private void BadgeCreation()
        {
            Console.Clear();
            Console.WriteLine("-----Creating new badge----- \n" +
                "What is the number on the badge?");
            int number = int.Parse(Console.ReadLine().ToString());
            bool moreDoors = true;
            List<string> accessableDoors = new List<string>();
            do
            {
                Console.WriteLine("\n" +
                    "List a door to give access to.");
                accessableDoors.Add(Console.ReadLine());
                Console.WriteLine("\n" +
                    "Any other doors?  [y/n]");
                switch (Console.ReadKey().KeyChar)
                {
                    case 'y':
                        break;
                    case 'n':
                        moreDoors = false;
                        break;
                    default:
                        Console.WriteLine("Error:  starting over.");
                        Thread.Sleep(1500);
                        BadgeCreation();
                        break;
                }
            } while (moreDoors);
            Badge newBadge = new Badge(number, accessableDoors);
            switch (_Repo.AddNewBadge(newBadge))
            {
                case (true):
                    Console.WriteLine("\n" +
                        "Badge successfully created!  \n" +
                        "Returning to main menu.");
                    Thread.Sleep(1500);
                    Run();
                    break;
                case (false):
                    Console.WriteLine("\n" +
                        "Error creating new badge!  \n" +
                        "Returning to main menu.");
                    Thread.Sleep(1500);
                    Run();
                    break;
            }

        }

        private void UpdateBadge()
        {
            Console.Clear();
            Console.WriteLine("-----Updating Badge----- \n" +
                "Enter the ID of the badge you wish to update.  ");
            int id = int.Parse(Console.ReadLine());
            Console.WriteLine($"Badge {id} has acces to doors {string.Join(", ",_Repo.GetDoorsByID(id))}.  \n" +
                $"What would you like to do?    \n" +
                $"[1] Add a door. \n" +
                $"[2] Remove a door.");
            switch (Console.ReadKey().KeyChar)
            {
                case '1':
                    Console.WriteLine("Which door would you like to add?");
                    string addThis = Console.ReadLine();
                    if (_Repo.AddDoorToBadge(id, addThis))
                    {
                        Console.WriteLine($"Success! Badge {id} has access to [{string.Join(", ", _Repo.GetDoorsByID(id))}]\n" +
                            "Returning to menu.");
                        Thread.Sleep(1500);
                        Run();
                    }  else
                    {
                        Console.WriteLine("There was an error adding door to badge! Returning to menu.");
                        Thread.Sleep(1500);
                        Run();
                    }

                    break;
                case '2':
                    Console.WriteLine("Which door would you like to remove?");
                    string removeThis = Console.ReadLine();
                    if (_Repo.RemoveDoor(id, removeThis))
                    {
                        Console.WriteLine($"Success! Badge {id} has access to [{string.Join(", ", _Repo.GetDoorsByID(id))}] \n" +
                            "Returning to menu.");
                        Thread.Sleep(1500);
                        Run();
                    }
                    else
                    {
                        Console.WriteLine("There was an error removing door from badge! Returning to menu.");
                        Thread.Sleep(1500);
                        Run();
                    }
                    break;
                default:
                    UpdateBadge();
                    break;
            }


        }

        private void ClearBadge()
        {
            Console.Clear();
            Console.WriteLine("Enter the ID of the badge you wish to clear.");
            int clearThis = int.Parse(Console.ReadLine().ToString());
            Console.WriteLine($"Clearing badge {clearThis}...");
            foreach (String door in _Repo.GetDoorsByID(clearThis))
            {
                _Repo.RemoveDoor(clearThis, door);

            }
            if (_Repo.GetDoorsByID(clearThis) == null)
            {
                Console.WriteLine("Badge successfully cleared!  \n" +
                    "Returning to menu.");
                Thread.Sleep(1500);
                Run();

            } else
            {
                Console.WriteLine("There was an error clearing badge.  \n" +
                    "Returning to menu.");
                Thread.Sleep(1500);
                Run();
            }
        }

        private void ViewBadges()
        {
            Console.Clear();
            List<Badge> badges = _Repo.GetBadges();
            Console.WriteLine("{0,-5} | {1,5}", "Badge", "Door Access");
            foreach (Badge badge in badges)
            {
                Console.WriteLine("{0,-5} | {1,5}", $"{ badge.ID}", $"{string.Join(", ",badge.Doors)}");
            }
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
            Run();

        }
    }
}
