/*
 * Name: Stevenson Suhardy
 * Date: October 4, 2022
 * Student ID: 100839397
 */

using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace NETD3202_Lab1
{
    /// <summary>
    /// Interaction logic for DisplayProject.xaml
    /// </summary>
    public partial class DisplayProject : Window
    {
        // Declaring all the values passed in from the main window
        int selectedIndex;
        List<Program> programList;
        ListBox listBoxProjects;

        // Declaring variables to save list
        string projectName;
        string budget;
        string amountSpent;
        string hoursRemaining;
        string projectStatus;
        // Getting the reference to list and listbox and the value of the current selected index from main window.
        public DisplayProject(ref List<Program> programList, int selectedIndex, ref ListBox listBoxProjects)
        {
            // Setting the declared variable and lists to the values passed in.
            this.selectedIndex = selectedIndex;
            this.programList = programList;
            this.listBoxProjects = listBoxProjects;
            InitializeComponent();
            // Displaying the values inside the list into the textbox in the Display Project window
            SetTextBoxValues();
        }


        /// <summary>
        /// This event occurs when the close button is clicked. This event closes the window.
        /// </summary>
        private void buttonClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// This event occurs when the alter button is clicked. This event updates the list and listbox based on the textbox inside the display project as well as update the list and listbox on the main window by using a reference.
        /// </summary>
        private void buttonAlter_Click(object sender, RoutedEventArgs e)
        {
            // Calling SaveList function
            SaveList();
            // Calling UpdateList function
            UpdateList();
            // If all the value from the textbox is valid
            if (programList[selectedIndex].SetValue(textBoxProjectName, ref textBoxBudget,  ref textBoxSpent, ref textBoxEstimatedHours, comboBoxStatus))
            {
                // Display them in the textbox using the SetTextBoxValues functions.
                SetTextBoxValues();
                // Calling the UpdateListBox function that updates the listbox in the mainwindow
                UpdateListBox();
                // Show the following messagebox.
                MessageBox.Show("Changes has been saved.", "Saved", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            else
            {
                // Revert the list back to before it was updated
                RevertList();
            }
        }

        /// <summary>
        /// This function will change the textbox values to the updated list of programs.
        /// </summary>
        private void SetTextBoxValues()
        {
            // Changing all the text in the textbox to the updated list of programs
            textBoxProjectName.Text = programList[selectedIndex].ProjectName;
            textBoxBudget.Text = programList[selectedIndex].Budget;
            textBoxSpent.Text = programList[selectedIndex].AmountSpent;
            textBoxEstimatedHours.Text = programList[selectedIndex].HoursRemaining;
            comboBoxStatus.Text = programList[selectedIndex].ProjectStatus;

        }

        /// <summary>
        /// This function will update the listbox based on the updated list of programs.
        /// </summary>
        private void UpdateListBox()
        {
            // Removes the project in the selected index
            listBoxProjects.Items.RemoveAt(selectedIndex);
            // Insert a new project in the selected index with all the updated information
            listBoxProjects.Items.Insert(selectedIndex, programList[selectedIndex].ProjectName);
        }

        /// <summary>
        /// This function will update the list of programs based on the values in the textbox that has been changed by the user.
        /// </summary>
        private void UpdateList()
        {
            // Updating the list of programs based on the user input in the textbox
            programList[selectedIndex].ProjectName = textBoxProjectName.Text;
            programList[selectedIndex].Budget = textBoxBudget.Text;
            programList[selectedIndex].AmountSpent = textBoxSpent.Text;
            programList[selectedIndex].HoursRemaining = textBoxEstimatedHours.Text;
            programList[selectedIndex].ProjectStatus = comboBoxStatus.Text;
        }
        /// <summary>
        /// This function will save a project in selected index of the list of programs into an existing variable
        /// </summary>
        private void SaveList()
        {
            // Saving all the project datas into a variable
            projectName = programList[selectedIndex].ProjectName;
            budget = programList[selectedIndex].Budget;
            amountSpent = programList[selectedIndex].AmountSpent;
            hoursRemaining = programList[selectedIndex].HoursRemaining;
            projectStatus = programList[selectedIndex].ProjectStatus;
        }
        /// <summary>
        /// Undoing all changes made in case the updated list has an invalid input by the user.
        /// </summary>
        private void RevertList()
        {
            // Reverting back all the changes made
            programList[selectedIndex].ProjectName = projectName;
            programList[selectedIndex].Budget = budget;
            programList[selectedIndex].AmountSpent = amountSpent;
            programList[selectedIndex].HoursRemaining = hoursRemaining;
            programList[selectedIndex].ProjectStatus = projectStatus;
        }
    }
}
