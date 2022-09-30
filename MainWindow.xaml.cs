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

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Main.Content = new Home();
            
        }

        private void ListViewItem_MouseEnter(object sender, MouseEventArgs e)
        {
            //Set tooltip visibility 

            if (ToggleButton.IsChecked == true)
            {
                ToolTip_Home.Visibility = Visibility.Collapsed;
                ToolTip_Support.Visibility = Visibility.Collapsed;
                ToolTip_Rental.Visibility = Visibility.Collapsed;
                ToolTip_Settings.Visibility = Visibility.Collapsed;
                ToolTip_Cars.Visibility = Visibility.Collapsed;
            }

            else
            {
                ToolTip_Home.Visibility = Visibility.Visible;
                ToolTip_Support.Visibility = Visibility.Visible;
                ToolTip_Rental.Visibility = Visibility.Visible;
                ToolTip_Settings.Visibility = Visibility.Visible;
                ToolTip_Cars.Visibility = Visibility.Visible;
            }
        }

        private void ToggleButton_Unchecked(object sender, RoutedEventArgs e)
        {
            //Here i make the background image fade 

            Main.Opacity = 1;
        }

        private void ToggleButton_Checked(object sender, RoutedEventArgs e)
        {
            //Same here

            Main.Opacity = 0.3;
        }

        private void Background_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            ToggleButton.IsChecked = false;
        }


        // Hopefully I manage to make the navigation work

        private void Support_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Main.Content = new Support();
        }

        private void CarMarket_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Main.Content = new CarMarket();
        }

        private void Settings_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Main.Content = new Settings();
        }

        private void FormPage_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Main.Content = new FormPage();
        }
        
        private void Home_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {

            Main.Content = new Home();

        }

        
    }
}
