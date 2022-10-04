//These are default (keep them!)
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Windows;
//keep the default namespace too, BillingApp is just the name of my project.
namespace NETD3202_Lab1
{
    public class Program
    {
        //First private data member
        private string projectName;
        private string budget;
        private string amountSpent;
        private string hoursRemaining;
        private string projectStatus;
        //Complete the rest (there are four more mentioned in the description).
        //constructor, you need to complete it this is a no parameter constructor
        // shown below.

        private double projectBudget;
        private double budgetSpent;
        private double estimatedHours;
        public Program()
        {
            projectName = "";
            budget = "";
            amountSpent = "";
            hoursRemaining = "";
            projectStatus = "Requirements";
        }
        //Getters and Setters for each private data member go below.
        /*This one is an example, notice that the data member is called private
        string “projectName” the getter/setter property is named
        “ProjectName”(different capitalization).*/
    public Program(string name, string budget, string amountSpent, string hoursRemaining, string projectStatus)
        {
            this.projectName = name;
            this.budget = budget;
            this.amountSpent = amountSpent;
            this.hoursRemaining = hoursRemaining;
            this.projectStatus = projectStatus;
        }
        public string ProjectName
        {
            get { return this.projectName; }
            set { this.projectName = value; }
        }

        public string Budget
        {
            get { return this.budget; }
            set { this.budget = value; }
        }

        public string AmountSpent
        {
            get { return this.amountSpent; }
            set { this.amountSpent = value; }
        }

        public string HoursRemaining
        {
            get { return this.hoursRemaining; }
            set { this.hoursRemaining = value; }
        }

        public string ProjectStatus
        {
            get { return this.projectStatus; }
            set { this.projectStatus = value; }
        }

        public bool ValidateInput()
        {
            bool isValid = true;
            if (projectName == string.Empty)
            {
                isValid = false;
                MessageBox.Show("Project Name cannot be empty. Please enter the project name.", "INVALID PROJECT NAME", MessageBoxButton.OK, MessageBoxImage.Error);
                return isValid;
            }
            if (double.TryParse(budget, out projectBudget))
            {
                isValid = true;
            }
            else
            {
                isValid = false;
                MessageBox.Show("Project Budget must be a number or a decimal number.", "INVALID PROJECT BUDGET", MessageBoxButton.OK, MessageBoxImage.Error);
                return isValid;
            }
            if (amountSpent == string.Empty)
            {
                isValid = false;
                MessageBox.Show("Budget Spent cannot be empty. Please enter the amount of budget spent for the project.", "INVALID PROJECT AMOUNT SPENT", MessageBoxButton.OK, MessageBoxImage.Error);
                return isValid;
            }
            else if (double.TryParse(amountSpent, out budgetSpent))
            {
                isValid = true;
            }
            else
            {
                isValid = false;
                MessageBox.Show("Budget Spent must be a number or a decimal number.", "INVALID PROJECT AMOUNT SPENT", MessageBoxButton.OK, MessageBoxImage.Error);
                return isValid;
            }
            if (hoursRemaining == string.Empty)

            {
                isValid = false;
                MessageBox.Show("Estimated hours cannot be empty. Please enter the estimated hours that will take for the project to finish.", "INVALID ESTIMATED HOURS", MessageBoxButton.OK, MessageBoxImage.Error);
                return isValid;
            }
            else if (double.TryParse(hoursRemaining, out estimatedHours))
            {
                isValid = true;
            }
            else
            {
                isValid = false;
                MessageBox.Show("Estimated hours must be a number or a decimal number.", "INVALID ESTIMATED HOURS", MessageBoxButton.OK, MessageBoxImage.Error);
                return isValid;
            }

            return isValid;
        }

        public bool SetValue()
        {
            if (ValidateInput())
            {
                this.projectName = ProjectName;
                this.budget = projectBudget.ToString();
                this.amountSpent = budgetSpent.ToString();
                this.hoursRemaining = estimatedHours.ToString();
                this.projectStatus = ProjectStatus;
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}