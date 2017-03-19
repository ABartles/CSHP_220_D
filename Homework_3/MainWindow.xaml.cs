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
using System.ComponentModel;

namespace Homework_3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            var users = new List<Models.User>();

            users.Add(new Models.User { Name = "Dave", Password = "1DavePwd" });
            users.Add(new Models.User { Name = "Steve", Password = "2StevePwd" });
            users.Add(new Models.User { Name = "Lisa", Password = "3LisaPwd" });
            users.Add(new Models.User { Name = "Dave", Password = "4DavePwd" });

            uxList.ItemsSource = users;
        }

        private GridViewColumnHeader listViewSortCol = null;
        private ListSortDirection newDirection;

        private void uxColumnHeader_Click(object sender, RoutedEventArgs e)
        {
            GridViewColumnHeader column = sender as GridViewColumnHeader;
            string sortBy = column.Tag.ToString();
            
            if (listViewSortCol != null)
            {
                uxList.Items.SortDescriptions.Clear();  
            }           
            
            // If direction undefined or descending set to ascending, else set to descending
            if (newDirection != ListSortDirection.Descending && newDirection != ListSortDirection.Ascending)
            {
                newDirection = ListSortDirection.Ascending;
            }
            else if (newDirection == ListSortDirection.Descending)
            {
                newDirection = ListSortDirection.Ascending;
            }
            else if (listViewSortCol == column)
            {
                newDirection = ListSortDirection.Descending;
            }


            listViewSortCol = column;

            uxList.Items.SortDescriptions.Add(new SortDescription(sortBy, newDirection));

        }


    }
}
