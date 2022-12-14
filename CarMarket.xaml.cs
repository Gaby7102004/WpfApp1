using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Data;
using System.Data.SqlClient;
using static System.Net.Mime.MediaTypeNames;
using WpfApp1;
using System.Windows.Markup;
using System.Configuration;

namespace WpfApp1
{


    
    // Interaction logic for MainWindow.xaml
    public partial class CarMarket : Page
    {


        //the cars list with all of their informations (name, details, images locations and the onckick function for the popup window
        readonly List<CarsMarket> items = new List<CarsMarket>()
            {
                new CarsMarket() { Name = "CHEVROLET Equinox", Description = "Nice cars", Car =    "E:\\WpfApp TAKE 1\\Images\\chevrolet-equinox.jpg", Buy ="Buy_Mercedes" },
                new CarsMarket() { Name = "CHEVROLET Silverado", Description = "Nice cars x2", Car = "E:\\WpfApp TAKE 1\\Images\\chevrolet-silverado.jpg" },
                new CarsMarket() { Name = "FORD F", Description = "Nice cars x2", Car =  "E:\\WpfApp TAKE 1\\Images\\ford-f.jpg" },
                new CarsMarket() { Name = "FORD Escape", Description = "Nice cars x2", Car =  "E:\\WpfApp TAKE 1\\Images\\ford-escape.jpg" },
                new CarsMarket() { Name = "FORD Explorer", Description = "Nice cars x2", Car =  "E:\\WpfApp TAKE 1\\Images\\ford-explorer.jpg" },
                new CarsMarket() { Name = "GMC Sierra", Description = "Nice cars x2", Car =  "E:\\WpfApp TAKE 1\\Images\\gmc-sierra.jpg" },
                new CarsMarket() { Name = "HONDA Accord", Description = "Nice cars x2", Car =  "E:\\WpfApp TAKE 1\\Images\\honda-accord.jpg" },
                new CarsMarket() { Name = "HONDA Civic", Description = "Nice cars", Car =    "E:\\WpfApp TAKE 1\\Images\\honda-civic.jpg" },
                new CarsMarket() { Name = "HONDA CR-V", Description = "Nice cars x2", Car = "E:\\WpfApp TAKE 1\\Images\\honda-cr-v.jpg" },
                new CarsMarket() { Name = "HONDA Pilot", Description = "Nice cars x2", Car =  "E:\\WpfApp TAKE 1\\Images\\honda-pilot.jpg" },
                new CarsMarket() { Name = "HUYNDAI Tucson", Description = "Nice cars x2", Car =  "E:\\WpfApp TAKE 1\\Images\\hyundai-tucson.jpg" },
                new CarsMarket() { Name = "JEEP Grand", Description = "Nice cars", Car =    "E:\\WpfApp TAKE 1\\Images\\jeep-grand.jpg" },
                new CarsMarket() { Name = "JEEP Wrangler", Description = "Nice cars x2", Car =  "E:\\WpfApp TAKE 1\\Images\\jeep-wrangler.jpg" },
                new CarsMarket() { Name = "MAZDA CX-5", Description = "Nice cars x2", Car =  "E:\\WpfApp TAKE 1\\Images\\mazda-cx-5.jpg" },
                new CarsMarket() { Name = "NISSAN Rogue", Description = "Nice cars x2", Car =  "E:\\WpfApp TAKE 1\\Images\\nissan-rogue.jpg" },
                new CarsMarket() { Name = "RAM Pickup", Description = "Nice cars x2", Car =  "E:\\WpfApp TAKE 1\\Images\\ram-pickup.jpg" },
                new CarsMarket() { Name = "SUBARU Forester", Description = "Nice cars x2", Car =  "E:\\WpfApp TAKE 1\\Images\\subaru-forester.jpg" },
                new CarsMarket() { Name = "SUBARU Outback", Description = "Nice cars x2", Car =  "E:\\WpfApp TAKE 1\\Images\\subaru-outback.jpg" },
                new CarsMarket() { Name = "TESLA Model-Y", Description = "Nice cars x2", Car =  "E:\\WpfApp TAKE 1\\Images\\tesla-model-y.jpg" },
                new CarsMarket() { Name = "TOYOTA 4-Runner", Description = "Nice cars x2", Car =  "E:\\WpfApp TAKE 1\\Images\\toyota-4runner.jpg" },
                new CarsMarket() { Name = "TOYOTA Camry", Description = "Nice cars x2", Car =  "E:\\WpfApp TAKE 1\\Images\\toyota-camry.jpg" },
                new CarsMarket() { Name = "TOYOTA Corolla", Description = "Nice cars x2", Car = "E:\\WpfApp TAKE 1\\Images\\toyota-corolla.jpg" },
                new CarsMarket() { Name = "TOYOTA Highlander", Description = "Nice cars", Car =    "E:\\WpfApp TAKE 1\\Images\\toyota-highlander.jpg" },
                new CarsMarket() { Name = "TOYOTA RAV-4", Description = "Nice cars x2", Car = "E:\\WpfApp TAKE 1\\Images\\toyota-rav4.jpg" },
                new CarsMarket() { Name = "TOYOTA Tacoma", Description = "Nice cars x2", Car =  "E:\\WpfApp TAKE 1\\Images\\toyota-tacoma.jpg" }
            };


        // The car images for the slideshow
        readonly string[] imgs = new string[]
        {   "/Images/chevrolet-equinox.jpg",
            "/Images/chevrolet-silverado.jpg",
            "/Images/ford-escape.jpg",
            "/Images/ford-explorer.jpg",
            "/Images/ford-f.jpg",
            "/Images/honda-accord.jpg",
            "/Images/honda-civic.jpg",
            "/Images/honda-cr-v.jpg",
            "/Images/honda-pilot.jpg",
            "/Images/hyundai-tucson.jpg",
            "/Images/jeep-grand.jpg",
            "/Images/jeep-wrangler.jpg",
            "/Images/nissan-rogue.jpg",
            "/Images/ram-pickup.jpg",
            "/Images/subaru-forester.jpg",
            "/Images/subaru-outback.jpg",
            "/Images/mazda-cx-5.jpg",
            "/Images/mazda-cx-5.jpg",
            "/Images/tesla-model-y.jpg",
            "/Images/toyota-4runner.jpg",
            "/Images/toyota-camry.jpg",
            "/Images/toyota-corolla.jpg",
            "/Images/toyota-highlander.jpg",
            "/Images/toyota-rav4.jpg",
            "/Images/toyota-tacoma.jpg", };


        

        /// <summary>
        /// THE MAINWINDOW
        /// Everything that goes in here updates instantly on startup in the mainwindow and app
        /// </summary>
        public CarMarket()
        {
            InitializeComponent();

            

            //asign the cars details to the list
            lbTodoList.ItemsSource = items;



            //begin the slideshow
            ShowImage(imgs[0], selected);



            //create a new timer and add the time between changes for the slideshow
            System.Windows.Threading.DispatcherTimer dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
            dispatcherTimer.Tick += DispatcherTimer_Tick;
            dispatcherTimer.Interval = new TimeSpan(0, 0, 3);
            dispatcherTimer.Start();

            

        }



        // changes the window when you order the car
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            FormPage window = new FormPage();
            this.Content = window;
        }



        //popup window
        private void Buy_Mercedes(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            popupGrid.Visibility = Visibility.Visible;
            Labeliul.Content = items[0].Description;
        }



        //intervl between images shown
        private void DispatcherTimer_Tick(object sender, EventArgs e)
        {
            if (selected == 0)
            {
                selected = imgs.Length - 1;
                ShowImage(imgs[selected], selected);
            }
            else
            {
                selected--; ShowImage(imgs[selected], selected);
            }
        }



        // SLIDESHOW function

        // variable for the slideshow
        int selected = 0;

        private void ShowImage(string img, int i)
        {
            
            BitmapImage b1 = new BitmapImage();
            b1.BeginInit();
            b1.UriSource = new Uri(img, UriKind.Relative);
            b1.EndInit();
            SlideShow.Stretch = Stretch.Uniform;
            SlideShow.Source = b1;

        }

       
    }

    
}
