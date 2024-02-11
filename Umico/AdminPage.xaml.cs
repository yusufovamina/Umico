using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
                var c1 = db.Orders.Where(o => o.Name == OrdersNames.SelectedValue.ToString()).ToList();
                CustomerName.Text = c1[0].Customer.Name;
    } } }
}
