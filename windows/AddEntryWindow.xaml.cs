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
using System.Windows.Shapes;
using Lab2.Model;
using Lab2.Controllers;
using Lab2.Helpers;

namespace Lab2.windows
{
    /// <summary>
    /// Interaction logic for AddEntryWindow.xaml
    /// </summary>
    public partial class AddEntryWindow : Window
    {
        private CrosswordController crosswordController;
        public AddEntryWindow(CrosswordController cController)
        {
            crosswordController = cController;
            InitializeComponent();
        }

        /// <summary>
        /// This method adds the item to the controller
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddBTN_Click(object sender, RoutedEventArgs e)
        {
            if(ClueTBX.Text.Length < 3 || AnswerTBX.Text.Length < 3)
            {
                MessageBox.Show("Your Clue and Answer length should be at least 3 characters");
            }else
            {
                crosswordController.AddCrossword(ClueTBX.Text, AnswerTBX.Text, DifficultyHelper.GetDifficulty(DifficultCMB.SelectedIndex));
                this.Close();
            }
        }
    }
}
