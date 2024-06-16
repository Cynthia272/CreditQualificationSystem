using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawryStore
{
    // Enum to define menu options
    public enum MainMenuOption
    {
        CaptureDetails = 1,
        CheckCreditQualification,
        ShowQualificationStats,
        Exit
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Applicant> applicants = new List<Applicant>();
            List<Applicant> qualifiedApplicants = new List<Applicant>();
            int deniedCount = 0;

            while (true)
            {
                MainMenuOption choice = DisplayMainMenuAndGetUserChoice();

                switch (choice)
                {
                    case MainMenuOption.CaptureDetails:
                        applicants.AddRange(CreditQualification.CaptureApplicantDetails());
                        break;

                    case MainMenuOption.CheckCreditQualification:
                        CreditQualification.CheckCreditQualification(applicants, out qualifiedApplicants, out deniedCount);
                        Console.WriteLine("Credit qualification checked.");
                        break;

                    case MainMenuOption.ShowQualificationStats:
                        CreditQualification.ShowQualificationStats(qualifiedApplicants, deniedCount);
                        break;

                    case MainMenuOption.Exit:
                        Console.WriteLine("Exiting program. Goodbye!");
                        return;

                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        // Method to display main menu and get user choice
        private static MainMenuOption DisplayMainMenuAndGetUserChoice()
        {
            Console.WriteLine("\nMain Menu:");
            Console.WriteLine("1. Capture Applicant Details");
            Console.WriteLine("2. Check Credit Qualification");
            Console.WriteLine("3. Show Qualification Statistics");
            Console.WriteLine("4. Exit");
            Console.Write("Enter your choice (1-4): ");

            MainMenuOption choice;
            while (!Enum.TryParse(Console.ReadLine(), out choice) || !Enum.IsDefined(typeof(MainMenuOption), choice))
            {
                Console.Write("Invalid input. Please enter a number from 1 to 4: ");
            }

            return choice;
        }
    }
}
