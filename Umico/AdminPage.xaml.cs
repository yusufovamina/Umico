using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
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

namespace Umico
{
    /// <summary>
    /// Interaction logic for AdminPage.xaml
    /// </summary>
    public partial class AdminPage : Page
    {
        public AdminPage()
        {
            DataContext = this;
            InitializeComponent();
            LoadOrderNames();
        }



        public void LoadOrderNames()
        {
            using (var dbContext = new AppContext())
            {
                var names = dbContext.Orders.Select(order => order.Name).ToList();
                foreach (var name in names)
                {
                    OrdersNames.Items.Add(name);
                }

            }
        }

        private void SaveEduts_CLick(object sender, RoutedEventArgs e)
        { }

            private void AdminLogin_CLick(object sender, RoutedEventArgs e)
        {
            if (Username.Text != "admin" && Password.Password != "admin")
            {
                MessageBox.Show("Incorrect username or password. Try again!");
            }
            else if (Username.Text == "admin" && Password.Password == "admin")
            {
                Login.Visibility = Visibility.Hidden;
            }
        }

        private void OrdersNames_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            using (var db = new AppContext()) {
                db.Customers.ToList();
                db.PickUpPoints.ToList();
                var c1 = db.Orders.Where(o => o.Name == OrdersNames.SelectedValue.ToString()).ToList();
                CustomerName.Text = c1[0].Customer.Name;
                CustomerSurname.Text = c1[0].Customer.Surname;
                PickUpPoint.Text = c1[0].PickUpPoint.Location;
                if (c1[0].PickUpPoint.Id % 3 == 0)
                {
                    BitmapImage sourse = new BitmapImage(new Uri(@"C:\Users\Yusuf_hm12\source\repos\Umico\Umico\Screenshot2024-02-16112512.png", UriKind.Relative));
                    ImagePlace.Source = sourse;
                }
                else if (c1[0].PickUpPoint.Id%3 == 1)
                {
                    BitmapImage sourse = new BitmapImage(new Uri(@"C:\Users\Yusuf_hm12\source\repos\Umico\Umico\Screenshot 2024-02-16 112530.png", UriKind.Relative));
                    ImagePlace.Source = sourse;

                }
                else
                {
                    BitmapImage sourse = new BitmapImage(new Uri(@"C:\Users\Yusuf_hm12\source\repos\Umico\Umico\Screenshot 2024-02-16 112603.png", UriKind.Relative));
                    ImagePlace.Source = sourse;
                }
            }
        } 
    }
}
