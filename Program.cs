/*
 * Edited By: Stevenson Suhardy
 * Date: October 4, 2022
 * Student ID: 100839397
 */

//These are default (keep them!)
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Windows;
using System.Windows.Controls;

//keep the default namespace too, BillingApp is just the name of my project.
namespace NETD3202_Lab1
{
    public class Program
    {
        //Private data members
        private string projectName;
        private string budget;
        private string amountSpent;
        private string hoursRemaining;
        private string projectStatus;

        // More data members to store the budget, amountspent, hoursremaining when they are converted to a double.
        double projectBudget;
        double budgetSpent;
        double estimatedHours;
        /// <summary>
        /// Default constructor
        /// </summary>
        public Program()
        {
            projectName = "";
            budget = "0";
            amountSpent = "0";
            hoursRemaining = "0";
            projectStatus = "Requirements";
        }

        /// <summary>
        /// Parameterized constructor
        /// </summary>
    public Program(string name, string budget, string amountSpent, string hoursRemaining, string projectStatus)
        {
            this.projectName = name;
            this.budget = budget;
            this.amountSpent = amountSpent;
            this.hoursRemaining = hoursRemaining;
            this.projectStatus = projectStatus;
        }
        // Getters and Setters
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

        // Public method
        /// <summary>
        /// This method validates the input that are give into the object. It takes in the textboxes and combo box in the window as a parameter.
        /// </summary>
        /// <returns>isValid (true or false)</returns>
        public bool ValidateInput(TextBox One, ref TextBox Two, ref TextBox Three, ref TextBox Four, ComboBox Five)
        {
            // Declaring isValid and set it to true;
            bool isValid = true;
            // Checking to see if the first textbox is empty
            if (One.Text == string.Empty)
            {
                // Set isValid to false and show the following messagebox
                isValid = false;
                MessageBox.Show("Project Name cannot be empty. Please enter the project name.", "INVALID PROJECT NAME", MessageBoxButton.OK, MessageBoxImage.Error);
                // return the value of isValid
                return isValid;
            }
            // Checking to see if the second textbox is empty
            if (Two.Text == string.Empty)
            {
                // Set isValid to false and show the following messagebox
                isValid = false;
                MessageBox.Show("Budget cannot be empty. Please enter the project budget.", "INVALID PROJECT BUDGET", MessageBoxButton.OK, MessageBoxImage.Error);
                // return the value of isValid
                return isValid;
            }
            // Check to see if the text in Textbox two can be converted to double
            else if (double.TryParse(Two.Text, out projectBudget))
            {
                // Set isValid to true if it can be converted
                isValid = true;
            }
            else
            {
                // Set isValid to false if it cannot be converted and show the following messagebox
                isValid = false;
                MessageBox.Show("Project Budget must be a number or a decimal number.", "INVALID PROJECT BUDGET", MessageBoxButton.OK, MessageBoxImage.Error);
                // return the value of isValid
                Two.Clear();
                return isValid;
            }
            // Checking to see if the second textbox is empty
            if (Three.Text == string.Empty)
            {
                // Set isValid to false and show the following messagebox
                isValid = false;
                MessageBox.Show("Budget Spent cannot be empty. Please enter the amount of budget spent for the project.", "INVALID PROJECT AMOUNT SPENT", MessageBoxButton.OK, MessageBoxImage.Error);
                return isValid;
            }
            // Check to see if the text in Textbox two can be converted to double
            else if (double.TryParse(Three.Text, out budgetSpent))
            {
                // Set isValid to true if it can be converted
                isValid = true;
            }
            else
            {
                // Set isValid to false and show the following messagebox
                isValid = false;
                MessageBox.Show("Budget Spent must be a number or a decimal number.", "INVALID PROJECT AMOUNT SPENT", MessageBoxButton.OK, MessageBoxImage.Error);
                Three.Clear();
                return isValid;
            }
            // Checking to see if the second textbox is empty
            if (Four.Text == string.Empty)

            {
                // Set isValid to false and show the following messagebox
                isValid = false;
                MessageBox.Show("Estimated hours cannot be empty. Please enter the estimated hours that will take for the project to finish.", "INVALID ESTIMATED HOURS", MessageBoxButton.OK, MessageBoxImage.Error);
                return isValid;
            }
            // Check to see if the text in Textbox two can be converted to double
            else if (double.TryParse(Four.Text, out estimatedHours))
            {
                // Set isValid to true if it can be converted
                isValid = true;
            }
            else
            {
                // Set isValid to false and show the following messagebox
                isValid = false;
                MessageBox.Show("Estimated hours must be a number or a decimal number.", "INVALID ESTIMATED HOURS", MessageBoxButton.OK, MessageBoxImage.Error);
                Four.Clear();
                return isValid;
            }
            if (Five.Text == "Completed")
            {
                estimatedHours = 0;
            }
            // return the value of isValid at the end of everything
            return isValid;
        }
        /// <summary>
        /// This method will set the values of the object after validating it using the ValidateInput method.
        /// </summary>
        /// <returns>true or false</returns>
        public bool SetValue(TextBox One, ref TextBox Two, ref TextBox Three, ref TextBox Four, ComboBox Five)
        {
            // Validate all inputs made by the user
            if (ValidateInput(One, ref Two, ref Three, ref Four, Five))
            {
                // Once everything is valid, set all attributes of the object.
                this.projectName = ProjectName;
                this.budget = projectBudget.ToString();
                this.amountSpent = budgetSpent.ToString();
                this.hoursRemaining = estimatedHours.ToString();
                this.projectStatus = ProjectStatus;
                return true;
            }
            else
            {
                // return false if one or more of the inputs is not valid
                return false;
            }
        }
    }
}