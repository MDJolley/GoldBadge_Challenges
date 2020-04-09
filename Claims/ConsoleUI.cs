
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Claims
{
    public class ConsoleUI
    {
        ClaimRepo _Repo = new ClaimRepo();

        public void Run()
        {
            Console.Clear();
            Console.WriteLine("Welcome to Komodo Insurance Claims Dept.   What would you like to do?   \n" +
                "[1] See all claims.  \n" +
                "[2] Add new claim.  \n" +
                "[3] Take care of next claim. \n" +
                "[4] Exit menu." );

            switch (Console.ReadKey().KeyChar)
            {
                case '1':
                    SeeClaims();
                    break;
                case '2':
                    AddClaim();
                    break;
                case '3':
                    TakeClaim();
                    break;
                case '4':
                    Environment.Exit(0);
                    break;
                default:
                    Run();
                    break;
            }

            void SeeClaims()
            {
                Console.Clear();
                List<Claim> claims = _Repo.GetClaims();
                string top = String.Format("{0,-9} | {1,10} | {2,-30} | {3,5} | {4,10} | {5,-10} | {6,5}", "ClaimID", "ClaimType", "Description", "Amount", "Date of Accident", "Date of Claim", "IsValid");
                Console.WriteLine(top);
                foreach (Claim claim in claims)
                {
                    Console.WriteLine("{0,-9} | {1,10} | {2,-30} | {3,-6} | {4,-16} | {5,-13} | {6,5}", $"{ claim.ClaimID}", $"{claim.ClaimType}", $"{claim.Description}", $"{claim.ClaimAmount}", $"{claim.DateOfIncident.ToShortDateString()}", $"{claim.DateOfClaim.ToShortDateString()}", $"{claim.IsValid.ToString()}");
                }
                Console.WriteLine("Press any key to continue.");
                Console.ReadKey();
                Run();
            }

            void AddClaim()
            {
                Console.Clear();
                Console.WriteLine("What is the tpe of claim? \n" +
                    "[1] Theft  \n" +
                    "[2] Home  \n" +
                    "[3] Car");
                ClaimType type = ClaimType.Car;
                switch (Console.ReadKey().KeyChar)
                {
                    case '1':
                        type = ClaimType.Theft;
                        break;
                    case '2':
                        type = ClaimType.Home;
                        break;
                    case '3':
                        type = ClaimType.Car;
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("\n" +
                            "Error:  Returning to menu.");
                        Thread.Sleep(2000);
                        Run();
                        break;
                }
                Console.WriteLine("\n" +
                    "Enter claim amount.");
                double amount = double.Parse(Console.ReadLine().ToString());
                Console.WriteLine("\n" +
                    "When did this incident occur?  [yyyy,mm,dd]");
                DateTime dateOfIncident = (DateTime.Parse(Console.ReadLine().ToString()));
                Console.WriteLine("\n" +
                    "When was this claim filed?  [yyyy,mm,dd]");
                DateTime dateOfClaim = DateTime.Parse(Console.ReadLine().ToString());
                Console.WriteLine("\n" +
                    "Describe the incident.");
                string description = Console.ReadLine().ToString();
                List<Claim> queue = _Repo.GetClaims();
                int lastID;
                if (queue.Count > 0)
                {
                    Claim lastClaim = queue[queue.Count - 1];
                    lastID = lastClaim.ClaimID;
                } else
                {
                    lastID = 0;
                }
                Claim newClaim = new Claim(lastID+1, amount, dateOfIncident, dateOfClaim, description, type);

                bool wasAdded = _Repo.NewClaim(newClaim);
                if (wasAdded)
                {
                    Console.WriteLine("\n" +
                        "Claim successfully added!  Returning to main menu.");
                    Thread.Sleep(2000);
                    Run();
                } else
                {
                    Console.WriteLine("\n" +
                        "There was an error adding this claim.  Returning to main menu.");
                    Thread.Sleep(2000);
                    Run();
                }

            }

            void TakeClaim()
            {
                Console.Clear();
                Claim claim = _Repo.Next();
                string claiminfo = String.Format("{0,-9} | {1,10} | {2,-30} | {3,-6} | {4,-16} | {5,-13} | {6,5}", $"{ claim.ClaimID}", $"{claim.ClaimType}", $"{claim.Description}", $"{claim.ClaimAmount}", $"{claim.DateOfIncident.ToShortDateString()}", $"{claim.DateOfClaim.ToShortDateString()}", $"{claim.IsValid.ToString()}");
                Console.WriteLine($"Next claim in queue:");
                Console.WriteLine("{0,-9} | {1,10} | {2,-30} | {3,5} | {4,10} | {5,-10} | {6,5}", "ClaimID", "ClaimType", "Description", "Amount", "Date of Accident", "Date of Claim", "IsValid");
                Console.WriteLine(claiminfo);
                Console.WriteLine("Do you want to deal with this claim now?  [y/n]");
                switch (Console.ReadKey().KeyChar)
                {
                    case 'y':
                        if (_Repo.Dealt())
                        {
                            Console.WriteLine("\n" +
                                "Claim successfully dealt with.  Returning to main menu.");
                            Thread.Sleep(2000);
                            Run();
                        } else
                        {
                            Console.WriteLine("\n" +
                                "Something went terribly wrong.  Returning to main menu.");
                            Thread.Sleep(2000);
                            Run();
                        }
                        break;
                    case 'n':
                        Console.WriteLine("\n" +
                            "Claim not dealt with, nothing will change.  Returning to main menu.");
                        Thread.Sleep(2000);
                        Run();
                        break;
                    default:
                        Console.WriteLine("\n" +
                            "There was an error returning to main menu.");
                        Thread.Sleep(2000);
                        Run();
                        break;
                }
            }

        }


    }
}
