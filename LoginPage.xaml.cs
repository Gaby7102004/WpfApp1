using System;
using System.Windows.Controls;
using System.Data;
using System.Data.SqlClient;
using WpfApp1;
using System.Windows.Controls.Primitives;
using System.Windows.Markup;
using System.Windows;
using System.Runtime.Remoting.Messaging;
using System.Configuration;

namespace WpfApp_TAKE_1
{
    /// <summary>
    /// Interaction logic for MainPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        //readonly string[] imgs = new string[] { "/Images/tesla-model-y.jpg", "/Images/Test/Plane0 (1).jpg", "/Images/Test/Plane0 (2).jpg", "/Images/Test/Plane0 (3).jpg", "/Images/Test/Plane0 (4).jpg", "/Images/Test/Plane0 (5).jpg" };

        //readonly string[] caption = new string[] { "My Closeup",
        //    "Waterfall, isn't it beautiful",
        //    "Near the waterfall",
        //    "Again Waterfall from different angle",
        //    "Relaxing in my home",
        //    "Enjoying at one of the tourist spot" };

        //int selected = 0;


        //Asigning the sql servers connection and command 2 atributes
        SqlConnection conn = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        SqlDataReader reader;


        public LoginPage()
        {
            InitializeComponent();


            //Connect to the database
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString.ToString();
            //ShowImage(imgs[0], selected);

            //System.Windows.Threading.DispatcherTimer dispatcherTimer = new();
            //dispatcherTimer.Tick += DispatcherTimer_Tick;
            //dispatcherTimer.Interval = new TimeSpan(0, 0, 3);
            //dispatcherTimer.Start();
        }


        //Check user credentials
        private bool VerifyUser(string username, string password)
        {

            conn.Open();
            cmd.Connection = conn;
            cmd.CommandText = "select Status from [User] where username='" + username + "' and password='" + password + "'";
            reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                if (Convert.ToBoolean(reader["Status"]) == true)
                    return true;

                else
                    return false;


            }
            else
                return false;
        }

        private void LogInButton_Click(object sender, RoutedEventArgs e)
        {
            if(conn.State == System.Data.ConnectionState.Open)
                conn.Close();

            if (VerifyUser(txtUsername.Text, txtPassword.Password))
                MessageBox.Show("Login Succesfully", "Congrats", MessageBoxButton.OK, MessageBoxImage.Information);
            
            else
                MessageBox.Show("Username or Password is incorrect", "Error", MessageBoxButton.OK, MessageBoxImage.Information);

        }





        //private void DispatcherTimer_Tick(object sender, EventArgs e)
        //{
        //    if (selected == 0)
        //    {
        //        selected = imgs.Length - 1;
        //        ShowImage(imgs[selected], selected);
        //    }
        //    else
        //    {
        //        selected--; ShowImage(imgs[selected], selected);
        //    }
        //}


        //private void ShowImage(string img, int i)
        //{

        //    BitmapImage b1 = new();
        //    b1.BeginInit();
        //    b1.UriSource = new Uri(img, UriKind.Relative);
        //    b1.EndInit();
        //    image1.Stretch = Stretch.Fill;
        //    image1.Source = b1;
        //    label1.Content = caption[i];

        //}

        ////Next Button Click
        //private void Button_Click(object sender, RoutedEventArgs e)
        //{



        //    if (selected == 0)
        //    {
        //        selected = imgs.Length - 1;
        //        ShowImage(imgs[selected], selected);
        //    }
        //    else
        //    {
        //        selected--; ShowImage(imgs[selected], selected);
        //    }

        //}
        ////Previous Button Click
        //private void Button_Click_2(object sender, RoutedEventArgs e)
        //{
        //    if (selected == imgs.Length - 1)
        //    {
        //        selected = 0;
        //        ShowImage(imgs[selected], selected);
        //    }
        //    else
        //    {
        //        selected++; ShowImage(imgs[selected], selected);
        //    }
        //}
        //< db oeffnen >




        //</ db oeffnen >

    }
}
