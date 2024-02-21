using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
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
    /// Interaction logic for Card.xaml
    /// </summary>
    public partial class Card : Page
    {
        public Card()
        {
            InitializeComponent();
        }
        private void Close_CLick(object sender, RoutedEventArgs e)
        {
           Content = null;
        }
        private void AddCard_Click(object sender, RoutedEventArgs e)
        {
        }
    }
}
