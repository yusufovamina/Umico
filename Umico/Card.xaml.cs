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
            using(AppContext db=new AppContext()){

                var card = db.Cards.Where(x=>x.Number==CardNumbBox.Text && x.CVV==Convert.ToInt32(CVVbox.Text) && x.YY== Convert.ToInt32(YYbox.Text) && x.MM== Convert.ToInt32(MMbox.Text)).FirstOrDefault();
            if( card != null)
                {
                    MessageBox.Show("Card was added!");
                    CurrentUser.CurrentCustomer.Card = card;
                    db.SaveChanges();
                }
                else
                {
                    MessageBox.Show("Wrong values");
                }
            }
        }
    }
}
