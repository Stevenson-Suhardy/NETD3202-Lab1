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
            if (MainWindow1.Focus())
            {
            }
        }
        /// <summary>
        /// This event will trigger when the create button is clicked. It will validate all the inputs by the user and then when all the input has passed the validation, it will create a new object Program called newProject and pass in all the user input into the class using parameterized constructor. After that, add the object to the list and display it in the listbox then, clear all the user inputs in the textbox.
        /// </summary>
        private void buttonCreate_Click(object sender, RoutedEventArgs e)
        {
            Program newProject = new Program(textBoxProjectName.Text, textBoxBudget.Text, textBoxSpent.Text, textBoxEstimatedHours.Text, comboBoxStatus.Text);
            if (newProject.SetValue())
            {
                programList.Add(newProject);

                listBoxProjects.Items.Add(newProject.ProjectName);
                SetDefault();
            }
        }

        private void SetDefault()
        {
            textBoxProjectName.Clear();
            textBoxBudget.Clear();
            textBoxSpent.Clear();
            textBoxEstimatedHours.Clear();
            comboBoxStatus.Text = "Requirements";
        }

        double projectBudget;
        double budgetSpent;
        double estimatedHours;
        public bool ValidateInput()
        {
            bool isValid = true;
            if (textBoxProjectName.Text == string.Empty)
            {
                isValid = false;
                MessageBox.Show("Project Name cannot be empty. Please enter the project name.", "INVALID PROJECT NAME", MessageBoxButton.OK, MessageBoxImage.Error);
                return isValid;
            }
            if (textBoxBudget.Text == string.Empty)
            {
                isValid = false;
                MessageBox.Show("Budget cannot be empty. Please enter the project budget.", "INVALID PROJECT BUDGET", MessageBoxButton.OK, MessageBoxImage.Error);
                return isValid;
            }
            else if (double.TryParse(textBoxBudget.Text, out projectBudget))
            {
                isValid = true;
            }
            else
            {
                isValid = false;
                MessageBox.Show("Project Budget must be a number or a decimal number.", "INVALID PROJECT BUDGET", MessageBoxButton.OK, MessageBoxImage.Error);
                return isValid;
            }
            if (textBoxSpent.Text == string.Empty)
            {
                isValid = false; 
                MessageBox.Show("Budget Spent cannot be empty. Please enter the amount of budget spent for the project.", "INVALID PROJECT AMOUNT SPENT", MessageBoxButton.OK, MessageBoxImage.Error);
                return isValid;
            }
            else if (double.TryParse(textBoxSpent.Text, out budgetSpent))
            {
                isValid = true;
            }
            else
            {
                isValid = false;
                MessageBox.Show("Budget Spent must be a number or a decimal number.", "INVALID PROJECT AMOUNT SPENT", MessageBoxButton.OK, MessageBoxImage.Error);
                return isValid;
            }
            if (textBoxEstimatedHours.Text == string.Empty)
            {
                isValid = false;
                MessageBox.Show("Estimated hours cannot be empty. Please enter the estimated hours that will take for the project to finish.", "INVALID ESTIMATED HOURS", MessageBoxButton.OK, MessageBoxImage.Error);
                return isValid;
            }
            else if (double.TryParse(textBoxEstimatedHours.Text, out estimatedHours))
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

        private void ListBoxClick(object sender, MouseButtonEventArgs e)
        {
            if (listBoxProjects.SelectedIndex >= 0)
            {
                currentIndex = listBoxProjects.SelectedIndex;
            }
            DisplayProject newWindow = new DisplayProject(ref programList, currentIndex, ref listBoxProjects);
            newWindow.Show();
            Application.Current.MainWindow = newWindow;
        }
    }
}
