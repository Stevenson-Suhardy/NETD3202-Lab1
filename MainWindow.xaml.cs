/*
 * Name: Stevenson Suhardy
 * Date: October 4, 2022
 * Student ID: 100839397
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace NETD3202_Lab1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // Creating a list of programs
        List<Program> programList = new List<Program>();
        int currentIndex;
        public MainWindow()
        {
            InitializeComponent();
        }
        /// <summary>
        /// This event will trigger when the create button is clicked. It will validate all the inputs by the user and then when all the input has passed the validation, it will create a new object Program called newProject and pass in all the user input into the class using parameterized constructor. After that, add the object to the list and display it in the listbox then, clear all the user inputs in the textbox.
        /// </summary>
        private void buttonCreate_Click(object sender, RoutedEventArgs e)
        {
            // Creating a new Program object
            Program newProject = new Program(textBoxProjectName.Text, textBoxBudget.Text, textBoxSpent.Text, textBoxEstimatedHours.Text, comboBoxStatus.Text);
            // Checking to see if all the passed in value by the user is valid.
            if (newProject.SetValue(textBoxProjectName, ref textBoxBudget, ref textBoxSpent, ref textBoxEstimatedHours, comboBoxStatus))
            {
                // Add the new object to the list
                programList.Add(newProject);
                // Add the new object projectName to the list box
                listBoxProjects.Items.Add(newProject.ProjectName);
                SetDefault();
            }
        }
        /// <summary>
        /// This function reset all the textbox and combo box to default.
        /// </summary>
        private void SetDefault()
        {
            textBoxProjectName.Clear();
            textBoxBudget.Clear();
            textBoxSpent.Clear();
            textBoxEstimatedHours.Clear();
            comboBoxStatus.Text = "Requirements";
        }

        /// <summary>
        /// This event handler will occur when someone double clicks a project in the list box. This will open up a new window and displaying all the information about the project. The user has the option to change the information for the project.
        /// </summary>
        
        private void ListBoxClick(object sender, MouseButtonEventArgs e)
        {
            // If the user selects a project
            if (listBoxProjects.SelectedIndex >= 0)
            {
                // Set the current index to the selected index
                currentIndex = listBoxProjects.SelectedIndex;
            }
            // Creating a new DisplayProject object called newWindow and passing in the list, current index, and the listbox
            DisplayProject newWindow = new DisplayProject(ref programList, currentIndex, ref listBoxProjects);
            // Showing the new window
            newWindow.Show();
        }
        /// <summary>
        /// This event handler will occur when the main window closes. It will shutdown the application.
        /// </summary>
        private void MainWindow1_Closed(object sender, EventArgs e)
        {
            // Shutdown the app
            Application.Current.Shutdown();
        }
    }
}
