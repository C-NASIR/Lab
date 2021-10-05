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

namespace Lab2.windows
{
    /// <summary>
    /// Interaction logic for ListEntriesWindow.xaml
    /// </summary>
    public partial class ListEntriesWindow : Window
    {
        private CrosswordController crosswordController;
        public ListEntriesWindow(CrosswordController cController)
        {
            crosswordController = cController;
            InitializeComponent();
            var entries = crosswordController.GetAllWords();

            foreach (Crossword entry in entries)
                EntriesLBX.Items.Add(entry.ToString());
        }

        /// <summary>
        ///  This method closes the window 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
