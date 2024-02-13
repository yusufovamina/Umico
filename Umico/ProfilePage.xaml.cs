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
        
        public ProfilePage()
        {
            InitializeComponent();
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
        }
}
