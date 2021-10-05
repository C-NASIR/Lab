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
using Lab2.database;
using Lab2.Controllers;
using Lab2.Model;
using System.Configuration;
using Lab2.windows;

namespace Lab2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // defining items used all 
        private static string connectionSring = ConfigurationManager.ConnectionStrings["MYSQLDB"].ConnectionString;
        private static DatabaseModel dbModel = new DatabaseModel(connectionSring);
        private  CrosswordController crosswordController = new CrosswordController(dbModel);

        public MainWindow()
        {
            InitializeComponent();
        }

        // This method handles when the user wants to list entries
        private void List_ItemsBTN_Click(object sender, RoutedEventArgs e)
        {
            ListEntriesWindow listEntriesWindow = new ListEntriesWindow(crosswordController);
            listEntriesWindow.Show();
        }
        // This method handles when the user wants to add entries
        private void Add_ItemBTN_Click(object sender, RoutedEventArgs e)
        {
            AddEntryWindow addEntryWindow = new AddEntryWindow(crosswordController);
            addEntryWindow.Show();
        }

        // This method handles when the user wants to update entry
        private void Update_ItemBTN_Click(object sender, RoutedEventArgs e)
        {
            UpdateSelectorWindow updateSelectorWindow = new UpdateSelectorWindow(crosswordController);
            updateSelectorWindow.Show();
        }

        // This method handles when the user wants to delete an entry 
        private void Delete_ItemBTN_Click(object sender, RoutedEventArgs e)
        {
            DeleteEntryWindow deleteEntryWindow = new DeleteEntryWindow(crosswordController);
            deleteEntryWindow.Show();
        }

        /// <summary>
        /// This button handles the exit 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
