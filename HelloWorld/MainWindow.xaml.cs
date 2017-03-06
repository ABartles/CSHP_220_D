<<<<<<< HEAD
﻿// Andrew Bartles
// CSHP 220

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

namespace HelloWorld
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            uxSubmit.IsEnabled = false;
        }


        // ----  ----

        bool uxName_hasContent = false;
        bool uxPassword_hasContent = false;


        // ---- Event Handlers ----

        private void uxSubmit_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Submitting password:" + uxPassword.Text);
        }

        private void uxName_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(string.IsNullOrEmpty(uxName.Text))
            {
                uxName_hasContent = false;
                enable_uxSubmit();
            }
            else
            {
                uxName_hasContent = true;
                enable_uxSubmit();
            }
        }

        private void uxPassword_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(uxPassword.Text))
            {
                uxPassword_hasContent = false;
                enable_uxSubmit();
            }
            else
            {
                uxPassword_hasContent = true;
                enable_uxSubmit();
            }
        }


        // ---- Custom Methods ----

        // Enable Submit Button
        private void enable_uxSubmit()
        {
            if(uxName_hasContent == true && uxPassword_hasContent == true)
            {
                uxSubmit.IsEnabled = true;
            }
            else
            {
                uxSubmit.IsEnabled = false;
            }
        }

    // END of MainWindow
    }
}
=======
﻿// Andrew Bartles
// CSHP 220

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

namespace HelloWorld
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            uxSubmit.IsEnabled = false;
        }


        // ----  ----

        bool uxName_hasContent = false;
        bool uxPassword_hasContent = false;


        // ---- Event Handlers ----

        private void uxSubmit_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Submitting password:" + uxPassword.Text);
        }

        private void uxName_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(string.IsNullOrEmpty(uxName.Text))
            {
                uxName_hasContent = false;
                enable_uxSubmit();
            }
            else
            {
                uxName_hasContent = true;
                enable_uxSubmit();
            }
        }

        private void uxPassword_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(uxPassword.Text))
            {
                uxPassword_hasContent = false;
                enable_uxSubmit();
            }
            else
            {
                uxPassword_hasContent = true;
                enable_uxSubmit();
            }
        }


        // ---- Custom Methods ----

        // Enable Submit Button
        private void enable_uxSubmit()
        {
            if(uxName_hasContent == true && uxPassword_hasContent == true)
            {
                uxSubmit.IsEnabled = true;
            }
            else
            {
                uxSubmit.IsEnabled = false;
            }
        }

    // END of MainWindow
    }
}
>>>>>>> 911c0c11191f37dbe807c2bbc5c1180686407004
