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

namespace Umico
{
    /// <summary>
    /// Interaction logic for ProfilePage.xaml
    /// </summary>
    public partial class ProfilePage : Page
    {
        public List<Order> UserOrders { get; set; }

        public ProfilePage()
        {
            InitializeComponent();
            DataContext = this;
            LoadUserOrders();
            namelbl.Text = CurrentUser.CurrentCustomer.Name;
            surnamelbl.Text = CurrentUser.CurrentCustomer.Surname;
            agelbl.Text = CurrentUser.CurrentCustomer.Age.ToString();
        }
        private void Back_CLick(object sender, RoutedEventArgs e)
        {
            if (NavigationService.CanGoBack)
            {
                NavigationService.GoBack();
            }
        }

        private void LoadUserOrders()
        {
            using (var db = new AppContext()) 
            {
                db.Products.ToList();  db.Statuses.ToList(); db.PickUpPoints.ToList();
                UserOrders = db.Orders.Where(o => o.Customer.Equals(CurrentUser.CurrentCustomer)).ToList();
                DataGridTextColumn orderName = new DataGridTextColumn();
                orderName.Header = "Order Name";
                orderName.Binding = new Binding("Name");
                OrdersGrid.Columns.Add(orderName);

                DataGridTextColumn productName = new DataGridTextColumn();
                productName.Header = "Product Name";
                productName.Binding = new Binding("ProductItem.Name");
                OrdersGrid.Columns.Add(productName);


                DataGridTextColumn productPrice = new DataGridTextColumn();
                productPrice.Header = "Product price";
                productPrice.Binding = new Binding("ProductItem.Price");
                OrdersGrid.Columns.Add(productPrice);

                DataGridTextColumn status = new DataGridTextColumn();
                status.Header = "Order's Status";
                status.Binding = new Binding("Status.Name");
                OrdersGrid.Columns.Add(status);

                DataGridTextColumn pickup = new DataGridTextColumn();
                pickup.Header = "Pick-up point";
                pickup.Binding = new Binding("PickUpPoint.Location");
                OrdersGrid.Columns.Add(pickup);

                OrdersGrid.ItemsSource = UserOrders;


            }
        }
    }

}

