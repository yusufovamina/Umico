using System;
using System.CodeDom;
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
    /// Interaction logic for UserPage.xaml
    /// </summary>
    public partial class UserPage : Page
    {
        public UserPage()
        {
            InitializeComponent();
            LoadProducts();
        }
        private void UserLogin_CLick(object sender, RoutedEventArgs e)
        {
            LoginOrSignUp.Visibility = Visibility.Hidden;
            Login.Visibility = Visibility.Visible;

           

        }
        private void LoadProducts()
        {
            using (var db = new AppContext())
            {
                var products = db.Products.ToList();
                foreach (var product in products)
                {
                    productListView.Items.Add(product);
                }
            }
        }

        private void AddToCartButton_Click(object sender, RoutedEventArgs e)
        {
          
            Button button = (Button)sender;
            Product selectedProduct = (Product)button.DataContext;
            int totalamount=Convert.ToInt32(total.Text);
            totalamount += selectedProduct.Price;
            total.Text = totalamount.ToString();
            AddToCart(selectedProduct);
        }

        private void OrderButton_Click(object sender, RoutedEventArgs e)
        {
            string orderName = GenerateRandomString(10);
            
            List<Product> Products= new List<Product>();
            foreach (Product i in cartListView.Items) {
               Products.Add(i);
            }
           
            using (var db = new AppContext()) {
                Random random = new Random();
                Order order = new Order() {Name=orderName, Customer=CurrentUser.CurrentCustomer, Products=Products,
                    Status= db.Statuses.First(x => x.Name == "Order is being processed"),
                    PickUpPoint = db.PickUpPoints?.Find(random.Next(1, 6))
            };
               
                
                
                db.Orders.Add(order);
                db.SaveChanges();
            }
            MessageBox.Show("Succesfull operation");

        }

        static string GenerateRandomString(int length)
        {
            const string chars = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string result = "";
            Random random = new Random();

            for (int i = 0; i < length; i++)
            {
                int index = random.Next(chars.Length);
                result += chars[index];
            }

            return result;
        }

        private void AddToCart(Product product)
        {
            List <Product> products = new List <Product>();
            products.Add(product);
            cartListView.Items.Add(product);
        }

        private void Discard_Click(object sender, RoutedEventArgs e)
        { 
        cartListView.Items.Clear();
            total.Text = "0";
        }
        
        private void Login_CLick(object sender, RoutedEventArgs e)
        {
            using (var db = new AppContext())
            {
                
                var user = db.Customers
                    .FirstOrDefault(u => u.Username == Username.Text && u.Password == Password.Password);

                if (user != null)
                {
                    Login.Visibility = Visibility.Hidden;
                    CurrentUser.CurrentCustomer = user;
                }
                else
                {
                    MessageBox.Show("Try again.");
                }
            }
        }
            private void UserSignUp_CLick(object sender, RoutedEventArgs e)
        {
            LoginOrSignUp.Visibility = Visibility.Hidden;
        }

    }
}
