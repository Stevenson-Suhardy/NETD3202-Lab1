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

        int selectedIndex;
        List<Program> programList;
        ListBox listBoxProjects;
        public DisplayProject(ref List<Program> programList, int selectedIndex, ref ListBox listBoxProjects)
        {
            this.selectedIndex = selectedIndex;
            this.programList = programList;
            this.listBoxProjects = listBoxProjects;
            InitializeComponent();

            SetTextBoxValues(ref programList, selectedIndex);
        }



        private void buttonClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void buttonAlter_Click(object sender, RoutedEventArgs e)
        {
            programList[selectedIndex].ProjectName = textBoxProjectName.Text;
            programList[selectedIndex].Budget = textBoxBudget.Text;
            programList[selectedIndex].AmountSpent = textBoxSpent.Text;
            programList[selectedIndex].HoursRemaining = textBoxEstimatedHours.Text;
            programList[selectedIndex].ProjectStatus = comboBoxStatus.Text;
            if (programList[selectedIndex].SetValue())
            {
                SetTextBoxValues(ref programList, selectedIndex);
                UpdateListBox(ref listBoxProjects, selectedIndex);
                MessageBox.Show("Changes has been saved.", "Saved", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                listBoxProjects.Items.RemoveAt(selectedIndex);
                listBoxProjects.Items.Insert(selectedIndex, programList[selectedIndex].ProjectName);
            }
        }

        private void SetTextBoxValues(ref List<Program> programList, int selectedIndex)
        {
            textBoxProjectName.Text = programList[selectedIndex].ProjectName;
            textBoxBudget.Text = programList[selectedIndex].Budget;
            textBoxSpent.Text = programList[selectedIndex].AmountSpent;
            textBoxEstimatedHours.Text = programList[selectedIndex].HoursRemaining;
            comboBoxStatus.Text = programList[selectedIndex].ProjectStatus;

        }

        private void UpdateListBox(ref ListBox listBoxProjects, int currentIndex)
        {
            listBoxProjects.Items.RemoveAt(currentIndex);
            listBoxProjects.Items.Insert(currentIndex, programList[currentIndex].ProjectName);
        }
    }
}
