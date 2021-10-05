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
using Lab2.Controllers;
using Lab2.Model;
using Lab2.Helpers;

namespace Lab2.windows
{
    /// <summary>
    /// Interaction logic for UpdateEntryWindow.xaml
    /// </summary>
    public partial class UpdateEntryWindow : Window
    {
        private CrosswordController crosswordController;
        private Crossword crossword;
        public UpdateEntryWindow(CrosswordController cController, int id)
        {
            crosswordController = cController;
            InitializeComponent();
            crossword = crosswordController.GetCrossword(id);
            ClueTBX.Text = crossword.Clue;
            AnswerTBX.Text = crossword.Answer;
            DifficultCMB.SelectedIndex = DifficultyHelper.GetDifficultyIndex(crossword.Difficulty);
        }


        /// <summary>
        /// This method is a click handler that updates the entry
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UpdateBTN_Click(object sender, RoutedEventArgs e)
        {
            if (ClueTBX.Text.Length < 3 || AnswerTBX.Text.Length < 3)
            {
                MessageBox.Show("Your Clue and Answer length should be at least 3 characters");
            }
            else
            {
                crossword.Clue = ClueTBX.Text;
                crossword.Answer = AnswerTBX.Text;
                crossword.Difficulty = DifficultyHelper.GetDifficulty(DifficultCMB.SelectedIndex);
                crosswordController.UpdateCrossword(crossword);
                this.Close();
            }
        }
    }
}
