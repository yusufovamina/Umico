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
using System.Windows.Controls.Primitives;
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
        {
            using(var db=new AppContext())
            {
            var order= db.Orders.Where(o=>o.Name==OrdersNames.SelectedValue).First();
                order.Status = db.Statuses.Where(s=>s.Name== StatusBox.SelectedValue).First();
                db.SaveChanges();
            }
        }

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
                List<Status> statuses= db.Statuses.ToList();
                StatusBox.Items.Clear();
                foreach(Status st in statuses)
                {
                    StatusBox.Items.Add(st.Name);
                }
                
                db.Customers.ToList();
                db.PickUpPoints.ToList();
                var c1 = db.Orders.Where(o => o.Name == OrdersNames.SelectedValue.ToString()).ToList();
                CustomerName.Text = c1[0].Customer.Name;
                CustomerSurname.Text = c1[0].Customer.Surname;
                PickUpPoint.Text = c1[0].PickUpPoint.Location;
                StatusBox.SelectedValue = c1[0].Status.Name;
                if (c1[0].PickUpPoint.Id % 3 == 0)
                {
                    
                    BitmapImage sourse1 = new BitmapImage(new Uri(@"C:\Users\Admin\source\repos\Umico\Umico\images\Screenshot 2024-02-16 112512.png"));
                    ImagePlace.Source = sourse1;
                }
                else if (c1[0].PickUpPoint.Id%3 == 1)
                {
                    BitmapImage sourse2 = new BitmapImage(new Uri(@"C:\Users\Admin\source\repos\Umico\Umico\images\Screenshot 2024-02-16 112603.png"));
                    ImagePlace.Source = sourse2;

                }
                else
                {
                    BitmapImage sourse3 = new BitmapImage(new Uri(@"C:\Users\Admin\source\repos\Umico\Umico\images\Screenshot 2024-02-16 112603.png"));
                    ImagePlace.Source = sourse3;
                }
            }
        } 
    }
}
