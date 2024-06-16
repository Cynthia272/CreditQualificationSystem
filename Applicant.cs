using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawryStore
{
    public class Applicant
    {
        public string Name { get; set; }
        public string EmploymentStatus { get; set; }
        public int YearsInCurrentJob { get; set; }
        public int YearsAtCurrentResidence { get; set; }
        public decimal MonthlySalary { get; set; }
        public decimal NonMortgageDebt { get; set; }
        public int NumberOfChildren { get; set; }

        public Applicant(string name, string employmentStatus, int yearsInCurrentJob, int yearsAtCurrentResidence, decimal monthlySalary, decimal nonMortgageDebt, int numberOfChildren)
        {
            Name = name;
            EmploymentStatus = employmentStatus;
            YearsInCurrentJob = yearsInCurrentJob;
            YearsAtCurrentResidence = yearsAtCurrentResidence;
            MonthlySalary = monthlySalary;
            NonMortgageDebt = nonMortgageDebt;
            NumberOfChildren = numberOfChildren;
        }
    }
}

   
