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
using PartWarehouseApp.Models;

namespace PartWarehouseApp
{
    /// <summary>
    /// Interaction logic for PartWindow.xaml
    /// </summary>
    public partial class PartWindow : Window
    {
        public PartWindow()
        {
            InitializeComponent();

            ShowInTaskbar = false;
        }

        // ==== Properties ====
        // ====
        public PartModel Part { get; set; }

        // ==== Click Handlers ====
        // ====
        private void uxSubmit_Click(object sender, RoutedEventArgs e)
        {
            Part = new PartModel();

            Part.Id = Convert.ToInt16(uxPartID.Text);
            Part.Description = uxDescription.Text;
            Part.UnitPrice = Convert.ToDecimal(uxUnitPrice.Text);
            Part.QtyOnHand = Convert.ToInt16(uxQtyOnHand.Text);
            Part.CreatedDate = DateTime.Now;
            Part.StockValue = Convert.ToDecimal(uxStockValue.Text);

            DialogResult = true;
            Close();
        }

        private void uxCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (Part != null)
            {
                uxSubmit.Content = "Update";
            }
            else
            {
                Part = new PartModel();
                Part.CreatedDate = DateTime.Now;
            }

            uxGrid.DataContext = Part;
        }

        private void uxSelectAll_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb = (sender as TextBox);

            if (tb != null)

            {

                tb.SelectAll();

            }
        }
    }
}

