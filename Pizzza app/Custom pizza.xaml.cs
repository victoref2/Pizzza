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
    /// Interaction logic for Custom_pizza.xaml
    /// </summary>
    public partial class Custom_pizza : Window
    {
        // Add properties to store customization options, e.g., selectedToppings

        private List<Toppings> selectedToppings;

        public Custom_pizza(List<Toppings> selectedToppings)
        {
            InitializeComponent();
            this.selectedToppings = selectedToppings;

            // You can now use 'this.selectedToppings' in this window to access the selected pizza's toppings.
        }

        // Handle the customization and create the custom pizza
        private void CustomizeButton_Click(object sender, RoutedEventArgs e)
        {
            // Create a new Pizza_Menu instance with selected customization
            Pizza_Menu customPizza = new Pizza_Menu
            {

            };

            // Add the custom pizza to the pizzaItems list in the main window
            MainWindow mainWindow = Application.Current.Windows.OfType<MainWindow>().FirstOrDefault();
            if (mainWindow != null)
            {
                mainWindow.AddCustomPizzaToMenu(customPizza);
            }

            this.Close(); // Close the custom pizza window
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void DataGrid_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
             
            

        }
    }
}
