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
using System.Windows.Shapes;

namespace Pizzza_app
{
    /// <summary>
    /// Interaction logic for Checkout_page.xaml
    /// </summary>
    public partial class Checkout_page : Window
    {
            private List<MenuItem> ShopcartItems;
            

        public Checkout_page(List<CartItem> shopCartItems, decimal fullPrice)
        {
            InitializeComponent();
            Price.Text = fullPrice.ToString();
            this.ShopcartItems = shopCartItems.Select(cartItem => cartItem.MenuItem).ToList();
            Checkout_grid.ItemsSource = ShopcartItems;
        }

        private void Price_TextChanged(object sender, TextChangedEventArgs e)
            {

            }

            private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
            {

            }
    }
}
