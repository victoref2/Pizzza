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

        private List<Toppings> selectedToppings = new List<Toppings>();

        public Custom_pizza(List<Toppings> selectedToppings, List<Toppings> availableToppings)
        {
            InitializeComponent();
            this.selectedToppings = selectedToppings;

            // Set the ItemsSource of the Toppings DataGrid
            Toppings.ItemsSource = availableToppings;

            // Set the ItemsSource of the Selected_toppings DataGrid
            Selected_toppings.ItemsSource = this.selectedToppings;
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
        private decimal CalculateCustomPizzaPrice(List<Toppings> toppings)
        {
            // Implement the pricing logic for the custom pizza based on selected toppings
            // You can calculate the price by summing the prices of selected toppings
            decimal totalPrice = 50;
            foreach (var topping in toppings)
            {
                totalPrice += + topping.ToppingPrice;
            }
            
            return totalPrice;
        }

        int Customer = 1;
            private void Button_Click(object sender, RoutedEventArgs e) 
        { 
            // Handle the "Færdig" (Finish) button click event
            if (selectedToppings.Count > 0)
            {
                // Create a custom pizza with selected toppings
                Pizza_Menu customPizza = new Pizza_Menu
                {
                    Name = "Custom Pizza : " + Customer,
                    Toppings = selectedToppings.ToList(), // Create a copy of selectedToppings
                    Price = CalculateCustomPizzaPrice(selectedToppings),
                    Description = "Customized Pizza",
                    
                };
                Customer++;
                // Add the custom pizza to the shopping cart in the main window
                MainWindow mainWindow = Application.Current.Windows.OfType<MainWindow>().FirstOrDefault();
                if (mainWindow != null)
                {
                    mainWindow.AddCustomPizzaToCart(customPizza);
                }

                this.Close(); // Close the custom pizza window
            }
            else
            {
                MessageBox.Show("Please select at least one topping.");
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

            // Handle the "Tilføj" (Add) button click event
            if (Toppings.SelectedItem is Toppings selectedToppingItem)
            {

                // Move the selected topping from "Toppings" to the selectedToppings list
                selectedToppings.Add(selectedToppingItem);

                // Refresh the "Selected_toppings" DataGrid
                Selected_toppings.Items.Refresh();

                // Your code to add the selected topping
            }
            else
            {
                MessageBox.Show("Please select a topping from the list.");
            }
            

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            // Handle the "Fjern" (Remove) button click event
            if (Selected_toppings.SelectedItem is Toppings selectedTopping)
            {
                // Remove the selected topping from the selectedToppings list
                selectedToppings.Remove(selectedTopping);

                // Refresh the "Selected_toppings" DataGrid
                Selected_toppings.Items.Refresh();
            }
        }
    }
}
