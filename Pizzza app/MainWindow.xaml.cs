using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace Pizzza_app
{
    public class CartItem
    {
        public MenuItem MenuItem { get; }
        public int Quantity { get; set; }

        public CartItem(MenuItem menuItem, int quantity = 1)
        {
            MenuItem = menuItem;
            Quantity = quantity;
        }
    }

    public abstract class MenuItem
    {
        public int Number { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
    }

    public class Pizza_Menu : MenuItem
    {
        public List<Toppings> Toppings { get; set; }
        public string Description { get; set; }
        public string ToppingsString
        {
            get
            {
                if (Toppings != null)
                {
                    return string.Join(", ", Toppings.Select(t => t.Topping));
                }
                return string.Empty;
            }
        }
    }


    public class Toppings : Pizza_Menu
    {
        
        public string Topping { get; set; }
        public int ToppingPrice { get; set; }

        
    }

    public class Drink_Menu : MenuItem
    {
        // Additional properties specific to drinks can be added here
    }

    public class Extra_Menu : MenuItem
    {
        // Additional properties specific to extras can be added here
    }

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Pizza_Menu> pizzaItems = new List<Pizza_Menu>();
        private List<Drink_Menu> drinkItems = new List<Drink_Menu>();
        private List<Extra_Menu> extraItems = new List<Extra_Menu>();
        public List<Toppings> ToppingsList = new List<Toppings>();

        public ObservableCollection<CartItem> cartItems = new ObservableCollection<CartItem>();

        List<Toppings> availableToppings = new List<Toppings>
        {
        new Toppings { Topping = "Pepperoni", ToppingPrice = 12 },//0
        new Toppings { Topping = "Mushrooms", ToppingPrice = 14 },//1
        new Toppings { Topping = "Sausage", ToppingPrice = 10 },//2
        new Toppings { Topping = "Gouda", ToppingPrice = 10 },//3
        new Toppings { Topping = "Cheddar", ToppingPrice = 14 },//4
        new Toppings { Topping = "Cheese", ToppingPrice = 12 },//5
        new Toppings { Topping = "Basil", ToppingPrice = 8 },//6
        new Toppings { Topping = "Mozzarela", ToppingPrice = 8 },//7
        new Toppings { Topping = "Tomato", ToppingPrice = 6 },//8
        new Toppings { Topping = "BBQ Sauce", ToppingPrice = 10 },//9
        new Toppings { Topping = "Crab", ToppingPrice = 10 },//10
        new Toppings { Topping = "Onions", ToppingPrice = 10 },//11
        new Toppings { Topping = "Red Onion", ToppingPrice = 10 },//12
        new Toppings { Topping =  "Bacon", ToppingPrice = 16 },//13
        new Toppings { Topping =  "Chicken", ToppingPrice = 10 },//14
        new Toppings { Topping =  "Pork", ToppingPrice = 10 },//15
        new Toppings { Topping = "ham", ToppingPrice = 10 },//16
        new Toppings { Topping = "pineapple", ToppingPrice = 12 },//17
        new Toppings { Topping = "Chili and more", ToppingPrice = 24 }, //18
        new Toppings { Topping = "Goat meat", ToppingPrice = 10 }, //19
        new Toppings { Topping = "Feta", ToppingPrice = 16 },//20
        new Toppings { Topping = "Spinach", ToppingPrice = 10 },//21
        new Toppings { Topping = "Pesto", ToppingPrice = 16 },//22
        new Toppings { Topping = "olives", ToppingPrice = 16 }, //23
        new Toppings { Topping = "Artichoke", ToppingPrice = 10 }, //24
        new Toppings { Topping = "Moar sauce", ToppingPrice = 12 } // 25
        // Add more toppings as needed
        };

        public MainWindow()
        {
            InitializeComponent();

            pizzaItems.Add(new Pizza_Menu { Number = 1, Name = "Pepperoni Pizza", Toppings = new List<Toppings> { availableToppings[5], availableToppings[0] }, Price = 69.99M, Description = "Classic Pepperoni Pizza" });
            pizzaItems.Add(new Pizza_Menu { Number = 2, Name = "Margherita Pizza", Toppings = new List<Toppings> { availableToppings[5], availableToppings[7] }, Price = 60M, Description = "Traditional Margherita Pizza" });
            pizzaItems.Add(new Pizza_Menu { Number = 3, Name = "Vegetarian Pizza", Toppings = new List<Toppings> { availableToppings[5], availableToppings[1], availableToppings[8] }, Price = 100M, Description = "Veggie-Loaded Pizza" });
            pizzaItems.Add(new Pizza_Menu { Number = 4, Name = "Meat Lovers Pizza", Toppings = new List<Toppings> { availableToppings[5], availableToppings[0], availableToppings[15], availableToppings[16], availableToppings[2] }, Price = 100M, Description = "For the Meat Lovers" });
            pizzaItems.Add(new Pizza_Menu { Number = 5, Name = "BBQ Chicken Pizza", Toppings = new List<Toppings> { availableToppings[5], availableToppings[14], availableToppings[9] }, Price = 80M, Description = "Tangy BBQ Chicken Pizza" });
            pizzaItems.Add(new Pizza_Menu { Number = 6, Name = "Supreme Pizza", Toppings = new List<Toppings> { availableToppings[5], availableToppings[0], availableToppings[2], availableToppings[16] }, Price = 80M, Description = "Loaded Supreme Pizza" });
            pizzaItems.Add(new Pizza_Menu { Number = 7, Name = "Hawaiian Pizza", Toppings = new List<Toppings> { availableToppings[5], availableToppings[16], availableToppings[17], availableToppings[3] }, Price = 79.99M, Description = "Sweet and Savory Hawaiian Pizza" });
            pizzaItems.Add(new Pizza_Menu { Number = 8, Name = "Four Cheese Pizza", Toppings = new List<Toppings> { availableToppings[5], availableToppings[20], availableToppings[7] }, Price = 80m, Description = "A Cheesy Delight" });
            pizzaItems.Add(new Pizza_Menu { Number = 9, Name = "Mushroom Truffle Pizza", Toppings = new List<Toppings> { availableToppings[5], availableToppings[0] }, Price = 80M, Description = "Elegant Mushroom and Truffle Pizza" });
            pizzaItems.Add(new Pizza_Menu { Number = 10, Name = "Sausage and Pepper Pizza", Toppings = new List<Toppings> { availableToppings[5], availableToppings[2] }, Price = 75M, Description = "Classic Combo" });
            pizzaItems.Add(new Pizza_Menu { Number = 11, Name = "Buffalo Chicken Pizza", Toppings = new List<Toppings> { availableToppings[5], availableToppings[15] }, Price = 80M, Description = "Spicy Buffalo Chicken Pizza" });
            pizzaItems.Add(new Pizza_Menu { Number = 12, Name = "Pesto Veggie Pizza", Toppings = new List<Toppings> { availableToppings[5], availableToppings[22] }, Price = 70M, Description = "Fresh and Flavorful" });
            pizzaItems.Add(new Pizza_Menu { Number = 13, Name = "Barbecue Bacon Pizza", Toppings = new List<Toppings> { availableToppings[5], availableToppings[9], availableToppings[13] }, Price = 70M, Description = "Sweet and Savory Combo" });
            pizzaItems.Add(new Pizza_Menu { Number = 14, Name = "Artichoke and Olive Pizza", Toppings = new List<Toppings> { availableToppings[5], availableToppings[23], availableToppings[24] }, Price = 70M, Description = "Mediterranean Flavors" });
            pizzaItems.Add(new Pizza_Menu { Number = 15, Name = "Spinach and Feta Pizza", Toppings = new List<Toppings> { availableToppings[5], availableToppings[21], availableToppings[20] }, Price = 65M, Description = "Greek Inspired Pizza" });
            pizzaItems.Add(new Pizza_Menu { Number = 16, Name = "Bacon Pizza", Toppings = new List<Toppings> { availableToppings[5], availableToppings[13] }, Price = 90M, Description = "Morning Delight" });
            pizzaItems.Add(new Pizza_Menu { Number = 17, Name = "BBQ Pork Pizza", Toppings = new List<Toppings> { availableToppings[5], availableToppings[15], availableToppings[9] }, Price = 85M, Description = "Hearty BBQ Pork Pizza" });
            pizzaItems.Add(new Pizza_Menu { Number = 18, Name = "Pepper and Onion Pizza", Toppings = new List<Toppings> { availableToppings[5], availableToppings[11], availableToppings[12], availableToppings[0] }, Price = 80M, Description = "Simple and Delicious" });
            pizzaItems.Add(new Pizza_Menu { Number = 19, Name = "Seafood Supreme Pizza", Toppings = new List<Toppings> { availableToppings[5], availableToppings[10], availableToppings[19] }, Price = 90M, Description = "Seafood Lover's Delight" });
            pizzaItems.Add(new Pizza_Menu { Number = 20, Name = "DEMO-MAN", Toppings =new List<Toppings> { availableToppings[18] }, Price = 110m, Description ="if you want to die"});
            drinkItems.Add(new Drink_Menu { Number = 1, Name = "Soda", Price = 12M });
            drinkItems.Add(new Drink_Menu { Number = 2, Name = "Lemonade", Price = 5.99M });
            drinkItems.Add(new Drink_Menu { Number = 3, Name = "Iced Tea", Price = 6.49M });
            drinkItems.Add(new Drink_Menu { Number = 4, Name = "Orange Juice", Price = 12.99M });
            drinkItems.Add(new Drink_Menu { Number = 5, Name = "Coca-Cola", Price = 14.99M });
            drinkItems.Add(new Drink_Menu { Number = 6, Name = "Sprite", Price = 14.99M });
            extraItems.Add(new Extra_Menu { Number = 1, Name = "Garlic Bread", Price = 9.99M });
            extraItems.Add(new Extra_Menu { Number = 2, Name = "Pomfritter small", Price = 14.99M });
            extraItems.Add(new Extra_Menu { Number = 3, Name = "Pomfirtter Stor", Price = 29.99M });
            extraItems.Add(new Extra_Menu { Number = 4, Name = "Mozzarella Sticks", Price = 9.99M });
            extraItems.Add(new Extra_Menu { Number = 5, Name = "Salad", Price = 10.49M });
            extraItems.Add(new Extra_Menu { Number = 6, Name = "Chicken Wings", Price = 19.99M });
            extraItems.Add(new Extra_Menu { Number = 7, Name = "Onion Rings", Price = 14.99M });
            ComboBoxItem pizzaType = new ComboBoxItem { Content = "Select Menu Type" };
            ComboBoxItem pizzaItem = new ComboBoxItem { Content = "Pizza" };
            ComboBoxItem drinkItem = new ComboBoxItem { Content = "Drink" };
            ComboBoxItem extraItem = new ComboBoxItem { Content = "Extra" };
            Selection.Items.Add(pizzaType);
            Selection.Items.Add(pizzaItem);
            Selection.Items.Add(drinkItem);
            Selection.Items.Add(extraItem);


            Selection.SelectedIndex = 0;
            CartItemsGrid.ItemsSource = cartItems;
        }


        public void AddCustomPizzaToMenu(Pizza_Menu customPizza)
        {
            // Add the custom pizza to the pizzaItems list
            pizzaItems.Add(customPizza);

            // Refresh the menu selection
            MenuSelect.Items.Refresh();
        }

        public void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        public void AddCustomPizzaToCart(Pizza_Menu customPizza)
        {
            // Create a CartItem instance for the custom pizza
            CartItem cartItem = new CartItem(customPizza);

            // Add the custom pizza to the cartItems collection
            cartItems.Add(cartItem);

            // Refresh the cart display or any related UI elements here
            CartItemsGrid.Items.Refresh();
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem selectedType = Selection.SelectedItem as ComboBoxItem;
            string menuType = selectedType.Content.ToString();

            if (menuType == "Pizza" && MenuSelect.ItemsSource != pizzaItems)
            {
                MenuSelect.ItemsSource = pizzaItems;

                // Define the columns for Pizza menu with Toppings and Description
                MenuSelect.Columns.Clear();
                MenuSelect.Columns.Add(new DataGridTextColumn { Header = "Number", Binding = new Binding("Number") });
                MenuSelect.Columns.Add(new DataGridTextColumn { Header = "Name", Binding = new Binding("Name") });
                MenuSelect.Columns.Add(new DataGridTextColumn { Header = "Price", Binding = new Binding("Price") });
                MenuSelect.Columns.Add(new DataGridTextColumn { Header = "Toppings", Binding = new Binding("ToppingsString") });
                MenuSelect.Columns.Add(new DataGridTextColumn { Header = "Description", Binding = new Binding("Description") });
            }
            else if (menuType == "Drink" && MenuSelect.ItemsSource != drinkItems)
            {
                MenuSelect.ItemsSource = drinkItems;

                // Define the columns for Drink menu
                MenuSelect.Columns.Clear();
                MenuSelect.Columns.Add(new DataGridTextColumn { Header = "Number", Binding = new Binding("Number") });
                MenuSelect.Columns.Add(new DataGridTextColumn { Header = "Name", Binding = new Binding("Name") });
                MenuSelect.Columns.Add(new DataGridTextColumn { Header = "Price", Binding = new Binding("Price") });
            }
            else if (menuType == "Extra" && MenuSelect.ItemsSource != extraItems)
            {
                MenuSelect.ItemsSource = extraItems;

                // Define the columns for Extra menu
                MenuSelect.Columns.Clear();
                MenuSelect.Columns.Add(new DataGridTextColumn { Header = "Number", Binding = new Binding("Number") });
                MenuSelect.Columns.Add(new DataGridTextColumn { Header = "Name", Binding = new Binding("Name") });
                MenuSelect.Columns.Add(new DataGridTextColumn { Header = "Price", Binding = new Binding("Price") });
            }


        }

        private void Button_Click(object sender, RoutedEventArgs e)
         {
            if (CartItemsGrid.SelectedItem is CartItem selectedItem)
            {
                cartItems.Remove(selectedItem);
                CalculateTotalPrice(); // Update total price after item is removed
                                       // Optionally, update the cart display or any related UI elements here
            }
        }


        
        private decimal CalculateTotalPrice()
        {

            decimal totalPrice = 0;

            foreach (CartItem cartItem in cartItems)
            {
                totalPrice += cartItem.MenuItem.Price * cartItem.Quantity;
            }

            return totalPrice;
        }




        public void Buy_check_out_Click(object sender, RoutedEventArgs e)
        {
            List<CartItem> ShopCartItems = cartItems.ToList();
            decimal fullPrice = CalculateTotalPrice();
            Checkout_page checkoutPage = new Checkout_page(ShopCartItems, fullPrice);
            checkoutPage.Show();
        }

        private void ADD_Click(object sender, RoutedEventArgs e)
        {

            if (MenuSelect.SelectedItem != null && MenuSelect.SelectedItem is MenuItem selectedItem)
    {
        CartItem cartItem = new CartItem(selectedItem); // Create a CartItem instance
        cartItems.Add(cartItem); // Add the item to the cartItems collection
        CartItemsGrid.Items.Refresh();
        // Optionally, update the cart display or any related UI elements here
    }

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (MenuSelect.SelectedItem is Pizza_Menu selectedPizza)
            {
                // Create an instance of the Custom_pizza window and pass the availableToppings list
                Custom_pizza customPizzaWindow = new Custom_pizza(selectedPizza.Toppings, availableToppings);

                // Show the window
                customPizzaWindow.ShowDialog();
            }
            else
            {
                MessageBox.Show("Please select a pizza from the menu.");
            }
        }

    }
}
