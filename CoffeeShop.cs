using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop
{
    //Custom Exception#1 To Handle Invalid Orders
    public class InvalidOrder : Exception
    {
        public InvalidOrder(string message) : base(message) { }
    }

    //Custom Exception#2 To Handle Payment Faliure
    public class PaymentFailed : Exception
    {
        public PaymentFailed(string message) : base(message) { }
    }

    //Field Encapsulation
    //menu and order are private fields that are not accessible outside the class
    //This ensures controlled access to these fields through methods
    public class CoffeeShop : InterfaceCoffeeShop
    {
        private List<MenuItem> menu;
        private List<OrderItem> order;

        //Method Extraction: InitializeMenu method
        //This method initializes the menu items, keeping the logic separate and reusable
        public CoffeeShop()
        {
            menu = InitializeMenu();
            order = new List<OrderItem>();
        }

        //Method to initialize the menu with predefined items
        private List<MenuItem> InitializeMenu()
        {
            return new List<MenuItem>
        {
            new MenuItem("Espresso", 7.0),
            new MenuItem("Latte", 4.9),
            new MenuItem("Cappuccino", 3.5)
        };
        }

        //Renaming -> DisplayMenu
        //Renamed this method to make its purpose clear and intuitive. It displays the coffee menu
        public void DisplayMenu()
        {
            Console.WriteLine("\n---- Coffee Menu ----");
            foreach (var item in menu)
            {
                Console.WriteLine($"{item.Name} - ${item.Price}");
            }
        }

        //Renaming -> TakeOrder
        //Renamed this method to make it more descriptive. This method takes customer orders, 
        //parsing the input and adding items to the order
        public void TakeOrder()
        {
            order.Clear();
            Console.WriteLine("\nEnter the coffee name and quantity:");

            while (true)
            {
                try
                {
                    string input = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(input)) break;

                    var parts = input.Split(' ');

                    //Here exception is handled for InvalidOrder
                    if (parts.Length < 2 || !int.TryParse(parts[1], out int quantity) || quantity <= 0)
                    {
                        throw new InvalidOrder("Invalid input. Please use the format 'CoffeeName Quantity' with a positive quantity.");
                    }

                    string coffeeName = parts[0];
                    var menuItem = menu.Find(item => item.Name.Equals(coffeeName, StringComparison.OrdinalIgnoreCase));
                    if (menuItem == null)
                    {
                        throw new InvalidOrder($"The item '{coffeeName}' is not available on the menu.");
                    }

                    order.Add(new OrderItem(menuItem, quantity));
                    Console.WriteLine($"{quantity} x {coffeeName} added to the order.");
                }
                catch (InvalidOrder ex)
                {
                    Console.WriteLine($"Order Error: {ex.Message}");
                }
            }
        }

        //Renaming -> ProcessPayment
        //Renamed this method to clearly describe its purpose of processing payment for the order
        public void ProcessPayment()
        {
            Console.WriteLine("\n---- Order Summary ----");
            double total = 0;

            //Calculate the total cost of the order
            foreach (var item in order)
            {
                double itemTotal = item.Quantity * item.MenuItem.Price;
                Console.WriteLine($"{item.Quantity} x {item.MenuItem.Name} @ ${item.MenuItem.Price} = ${itemTotal}");
                total += itemTotal;
            }

            Console.WriteLine($"\nTotal Amount: ${total}");
            Console.Write("Enter payment amount: ");

            //handle the exceptions related to payment
            try
            {
                if (!double.TryParse(Console.ReadLine(), out double payment) || payment <= 0)
                {
                    throw new PaymentFailed("Invalid payment amount entered. Please enter a positive number.");
                }

                if (payment < total)
                {
                    throw new PaymentFailed("Insufficient payment amount. Please enter an amount equal to or greater than the total.");
                }

                Console.WriteLine($"Payment successful! Change: ${payment - total}");
            }
            catch (PaymentFailed ex)
            {
                Console.WriteLine($"Payment Error: {ex.Message}");
            }
        }
    }
}
