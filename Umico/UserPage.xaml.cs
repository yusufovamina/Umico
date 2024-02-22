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
                var PickUps= db.PickUpPoints.ToList();
                foreach(var point in PickUps)
                {
                    PickUpBox.Items.Add(point.Location);
                }

            }
        }

        private void AddToCartButton_Click(object sender, RoutedEventArgs e)
        {
          
            Button button = (Button)sender;
            Product selectedProduct = (Product)button.DataContext;
            
            
            AddToCart(selectedProduct);
        }

        private void PaymentMetodChoice_CLick(object sender, RoutedEventArgs e)
        {
            using (var db = new AppContext())
            {
                if (Cash.IsChecked == true && Product.Content != null)
                {
                     var product = db.Products.Where(p => p.Name == Product.Content).FirstOrDefault();
                    Amount.Content = product.Price;

                    TotalLbl.Visibility= Visibility.Visible;
                    Amount.Visibility = Visibility.Visible;
                
                }
                if(Card.IsChecked == true) 
                {
                    CardFrame.Content = new Card();
                }
            
            }
        }

        private void OrderButton_Click(object sender, RoutedEventArgs e)
        {
            string orderName = GenerateRandomString(10);
          
            
           
            using (var db = new AppContext()) {
                db.Orders.ToList();
                db.Cards.ToList();
                db.Products.ToList();
                var product=db.Products.Where(p=>p.Name==Product.Content).FirstOrDefault();

                Order order1 = new Order()
                {
                    Name = orderName,
                    Customer = db.Customers.FirstOrDefault(x => x.Equals(CurrentUser.CurrentCustomer)),
                    ProductItem = db.Products.FirstOrDefault(p => p.Equals(product)),
                    Status = db.Statuses.FirstOrDefault(x => x.Name == "Order is being processed"),
                    PickUpPoint = db.PickUpPoints?.FirstOrDefault(p => p.Location == PickUpBox.SelectedValue)
                };

                CurrentUser.CurrentCustomer.Card.Balance = CurrentUser.CurrentCustomer.Card.Balance - (float)product.Price;
                var card = db.Cards.Where(c => c == CurrentUser.CurrentCustomer.Card).FirstOrDefault();
                card.Balance = card.Balance - (float)product.Price;
                db.Orders.Add(order1);
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
            Product.Content = product.Name;
        }

        private void Discard_Click(object sender, RoutedEventArgs e)
        {
            Product.Content = "";
            PickUpBox.SelectedItem = null;
            Cash.IsChecked = false;
            Card.IsChecked = false;
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
            SignUp.Visibility = Visibility.Visible;
            
        }

        private void SignUp_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new AppContext())
            {
                Customer c1 = new Customer() { Name = NewName.Text, Surname = NewSurname.Text, Age = Convert.ToInt32(Age.Text), Username = NewUsername.Text, Password = NewPassword.Password };
                db.Customers.Add(c1);
                db.SaveChanges();
                MessageBox.Show("Succesfull operation");
                CurrentUser.CurrentCustomer = c1;
            }
            SignUp.Visibility = Visibility.Hidden;
        }

    }
}
