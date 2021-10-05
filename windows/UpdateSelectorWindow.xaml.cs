﻿using System;
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

namespace Lab2.windows
{
    /// <summary>
    /// Interaction logic for UpdateSelectorWindow.xaml
    /// </summary>
    public partial class UpdateSelectorWindow : Window
    {
        private CrosswordController crosswordController;
        public UpdateSelectorWindow(CrosswordController cController)
        {
            crosswordController = cController;
            InitializeComponent();
        }

        /// <summary>
        /// This method is an event handler that calls update
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UpdateBTN_Click(object sender, RoutedEventArgs e)
        {
            int chosenID = 0;
            bool success = int.TryParse(IdTBX.Text, out chosenID);
            if (!success)
            {
                MessageBox.Show("Please enter a valid id number");
            }
            else
            {
                var word = crosswordController.GetCrossword(chosenID);
                if(word != null)
                {
                    UpdateEntryWindow updateEntryWindow = new UpdateEntryWindow(crosswordController, chosenID);
                    updateEntryWindow.ShowDialog();
                    this.Close();
                } else
                {
                    MessageBox.Show("Sorry, There is no word with the given ID. Enter valid ID");
                }
            }
        }
    }
}
