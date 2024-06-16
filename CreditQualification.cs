using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawryStore
{
    public class CreditQualification
    {
        // Method to capture details of multiple applicants and return a list
        public static List<Applicant> CaptureApplicantDetails()
        {
            List<Applicant> applicants = new List<Applicant>();

            Console.WriteLine("Enter applicant details:");

            while (true)
            {
                Console.Write("Name: ");
                string name = Console.ReadLine();

                Console.Write("Employment status (Employed/Unemployed): ");
                string employmentStatus = Console.ReadLine();

                int yearsInCurrentJob = 0;
                if (employmentStatus.ToLower() == "employed")
                {
                    Console.Write("Years in current job: ");
                    yearsInCurrentJob = GetValidIntegerInput();
                }

                Console.Write("Years at current residence: ");
                int yearsAtCurrentResidence = GetValidIntegerInput();

                Console.Write("Monthly salary: ");
                decimal monthlySalary = GetValidDecimalInput();

                Console.Write("Amount of non-mortgage debt: ");
                decimal nonMortgageDebt = GetValidDecimalInput();

                Console.Write("Number of children: ");
                int numberOfChildren = GetValidIntegerInput();

                applicants.Add(new Applicant(name, employmentStatus, yearsInCurrentJob, yearsAtCurrentResidence, monthlySalary, nonMortgageDebt, numberOfChildren));

                Console.Write("Do you want to add another applicant? (Y/N): ");
                string continueAdding = Console.ReadLine().Trim().ToUpper();
                if (continueAdding != "Y")
                {
                    break;
                }
            }

            return applicants;
        }

        // Method to check credit qualification for applicants
        public static void CheckCreditQualification(List<Applicant> applicants, out List<Applicant> qualifiedApplicants, out int deniedCount)
        {
            qualifiedApplicants = new List<Applicant>();
            deniedCount = 0;

            foreach (var applicant in applicants)
            {
                bool isQualified = IsQualifiedForCredit(applicant);
                if (isQualified)
                {
                    qualifiedApplicants.Add(applicant);
                }
                else
                {
                    deniedCount++;
                }
            }
        }

        // Method to determine if an applicant qualifies for credit
        private static bool IsQualifiedForCredit(Applicant applicant)
        {
            if (applicant.EmploymentStatus.ToLower() != "employed" || applicant.YearsInCurrentJob <= 1 || applicant.YearsAtCurrentResidence < 2 ||
                applicant.NonMortgageDebt >= applicant.MonthlySalary * 2 || applicant.NumberOfChildren > 6)
            {
                return false;
            }

            return true;
        }

        // Method to display credit qualification statistics
        public static void ShowQualificationStats(List<Applicant> qualifiedApplicants, int deniedCount)
        {
            Console.WriteLine("\nCredit qualification statistics:");
            Console.WriteLine($"Applicants granted credit: {qualifiedApplicants.Count}");
            Console.WriteLine($"Applicants denied credit: {deniedCount}");

            if (qualifiedApplicants.Count > 0)
            {
                Console.WriteLine("\nQualified Applicants:");
                foreach (var applicant in qualifiedApplicants)
                {
                    Console.WriteLine($"- {applicant.Name}");
                }
            }
        }

        // Method to get valid integer input from user
        private static int GetValidIntegerInput()
        {
            int value;
            while (!int.TryParse(Console.ReadLine(), out value))
            {
                Console.Write("Invalid input. Please enter a valid number: ");
            }
            return value;
        }

        // Method to get valid decimal input from user
        private static decimal GetValidDecimalInput()
        {
            decimal value;
            while (!decimal.TryParse(Console.ReadLine(), out value))
            {
                Console.Write("Invalid input. Please enter a valid number: ");
            }
            return value;
        }

    }
}


