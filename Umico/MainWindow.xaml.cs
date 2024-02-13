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
using System.IO;

namespace Umico
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public static class CurrentUser
    {
        public static Customer CurrentCustomer { get; set; }
    }
    public partial class MainWindow : Window
    {
        static Customer CurrentCustomer = new Customer();
        public MainWindow()
        {
            InitializeComponent();
            FillDb();
        }

        private void FillDb()
        {
            using (AppContext db = new AppContext())
            {
              
                Customer customer1 = new Customer() { Name = "Afruz", Surname = "Quliyeva", Age = 21, Username = "afruz21", Password = "lalala12" };
                Customer customer2 = new Customer() { Name = "Farid", Surname = "Salayev", Age = 19, Username = "salayev", Password = "12345678" };
                Customer customer3 = new Customer() { Name = "Alina", Surname = "Mirzoyeva", Age = 17, Username = "alina111", Password = "2007alina" };
                Customer customer4 = new Customer() { Name = "Rustam", Surname = "Veliyev", Age = 24, Username = "veliyevrustam", Password = "000111222" };
                Customer customer5 = new Customer() { Name = "Leyla", Surname = "Dadasheva", Age = 24, Username = "leyla_d", Password = "87654321" };
                Customer customer6 = new Customer() { Name = "Zaur", Surname = "Tagizade", Age = 24, Username = "zaur01", Password = "24242424" };
                Customer customer7 = new Customer() { Name = "David", Surname = "Abdullayev", Age = 24, Username = "abd_david", Password = "daviddavid" };

                byte[] imageBytes = File.ReadAllBytes("C:\\Users\\Admin\\source\\repos\\Umico\\Umico\\tomatoes.png");
                byte[] imageBytes2 = File.ReadAllBytes("C:\\Users\\Admin\\source\\repos\\Umico\\Umico\\salmon.png");
                byte[] imageBytes3 = File.ReadAllBytes("C:\\Users\\Admin\\source\\repos\\Umico\\Umico\\spagetti.png");
                byte[] imageBytes4 = File.ReadAllBytes("C:\\Users\\Admin\\source\\repos\\Umico\\Umico\\ayran.png");
                byte[] imageBytes5 = File.ReadAllBytes("C:\\Users\\Admin\\source\\repos\\Umico\\Umico\\chocolate.png");
                byte[] imageBytes6 = File.ReadAllBytes("C:\\Users\\Admin\\source\\repos\\Umico\\Umico\\sprite.png");
                byte[] imageBytes7 = File.ReadAllBytes("C:\\Users\\Admin\\source\\repos\\Umico\\Umico\\bread.png");

                Product p1 = new Product() { Name = "Tomato", Price = 3 , Image=imageBytes};
                Product p2 = new Product() { Name = "Salmon", Price = 15, Image=imageBytes2 };
                Product p3 = new Product() { Name = "Spagetti", Price = 3, Image= imageBytes3 };
                Product p4 = new Product() { Name = "Ayran", Price = 2,Image= imageBytes4 };
                Product p5 = new Product() { Name = "Chocolate", Price = 1, Image=imageBytes5 };
                Product p6 = new Product() { Name = "Sprite", Price = 1, Image = imageBytes6 };
                Product p7 = new Product() { Name = "Bread", Price = 1, Image= imageBytes7 };
                Product p8 = new Product() { Name = "Chicken", Price = 6 };
                Product p9 = new Product() { Name = "Pineapple", Price = 4 };
                Product p10 = new Product() { Name = "Orange juice", Price = 3 };
                Product p11 = new Product() { Name = "Snickers cake", Price = 9 };
                Product p12 = new Product() { Name = "Butter", Price = 12 };
                Product p13 = new Product() { Name = "Carrot", Price = 5 };


                Status status1 = new Status() { Name = "Order is being processed" };
                Status status2 = new Status() { Name = "Order was accepted" };
                Status status3 = new Status() { Name = "Order was cancelled" };
                Status status4 = new Status() { Name = "Order was delivered to Pick-Up point" };
                Status status5 = new Status() { Name = "Order completed" };


                PickUpPoint pickup1 = new PickUpPoint() { Name = "PickUp 1", Location = "Nizami street 31" };
                PickUpPoint pickup2 = new PickUpPoint() { Name = "PickUp 2", Location = "Ataturk prospekt 105 " };
                PickUpPoint pickup3 = new PickUpPoint() { Name = "PickUp 3", Location = "Dilara Aliyeva street 78" };
                PickUpPoint pickup4 = new PickUpPoint() { Name = "PickUp 4", Location = "Fizuli street 26" };

                Order o1=new Order() { Name="Y45C3X09A2", Customer=customer1, PickUpPoint=pickup1, Products=new List<Product>() { p1,p2,p3}, Status=status1 };
                db.PickUpPoints.AddRange(pickup1, pickup2, pickup3, pickup4);
                db.Statuses.AddRange(status1,status2,status3,status4,status5);
                //db.Products.AddRange(p1,p2,p3,p4,p5,p6,p7,p8,p9,p10,p11,p12,p13);
                 db.Customers.AddRange(customer1, customer2, customer3, customer4,customer5,customer6,customer7);
                // db.Orders.Add(o1);
                //db.Products.Add(p1);\
               //db.Products.AddRange( p2, p3);
                db.SaveChanges();

            }

        }

        private void ProfileButton_CLick(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new ProfilePage();
        }

        private void UserEnter_CLick(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new UserPage();
        }
        private void AdminEnter_CLick(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new AdminPage();
        }

        private void MainFrame_Navigated(object sender, NavigationEventArgs e)
        {

        }
    }
}
