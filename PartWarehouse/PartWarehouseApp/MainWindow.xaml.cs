
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
using PartRepository;
using PartWarehouseApp.Models;
using System.ComponentModel;

namespace PartWarehouseApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            LoadParts();
        }

        private Models.PartModel selectedPart;
        private GridViewColumnHeader listViewSortCol = null;
        private ListSortDirection newDirection;


        // ==== Click Handlers - Start ====
        // ====
        private void uxFileNew_Click(object sender, RoutedEventArgs e)
        {
            var window = new PartWindow();

            if (window.ShowDialog() == true)
            {
                var uiPartModel = window.Part;

                var repositoryPartModel = uiPartModel.ToRepositoryModel();

                App.PartRepository.Add(repositoryPartModel);

                LoadParts();

            }
        }

        private void uxFileChange_Click(object sender, RoutedEventArgs e)
        {

            var window = new PartWindow();
            window.Part = selectedPart;

            if (window.ShowDialog() == true)
            {
                App.PartRepository.Update(window.Part.ToRepositoryModel());
                LoadParts();
            }

        }

        private void uxFileDelete_Click(object sender, RoutedEventArgs e)
        {
            App.PartRepository.Remove(selectedPart.Id);
            selectedPart = null;
            LoadParts();
        }

        private void uxPartList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedPart = (Models.PartModel)uxPartList.SelectedValue;
        }

        private void uxFileDelete_Loaded(object sender, RoutedEventArgs e) // handels file menu & context menu
        {
            uxFileDelete.IsEnabled = (selectedPart != null);
            uxContextFileDelete.IsEnabled = (selectedPart != null);
        }

        private void uxFileChange_Loaded(object sender, RoutedEventArgs e)
        {
            uxFileChange.IsEnabled = (selectedPart != null);
            uxContextFileChange.IsEnabled = uxFileChange.IsEnabled;
        }
        // ====
        // ==== Click Handlers - End ====


        //==== Load List - Start ====
        // ====
        private void LoadParts()
        {
            var parts = App.PartRepository.GetAll();

            uxPartList.ItemsSource = parts.Select(t => PartWarehouseApp.Models.PartModel.ToModel(t)).ToList();

        }
        // ====
        //==== Load List - End ====


        //==== Column Sort - Start ====
        // ====
        private void uxColumnHeader_Click(object sender, RoutedEventArgs e)
        {
            GridViewColumnHeader column = sender as GridViewColumnHeader;
            string sortBy = column.Tag.ToString();

            if (listViewSortCol != null)
            {
                uxPartList.Items.SortDescriptions.Clear();
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

            uxPartList.Items.SortDescriptions.Add(new SortDescription(sortBy, newDirection));

        }
        // ====
        //==== Column Sort - End ====

    }
}
