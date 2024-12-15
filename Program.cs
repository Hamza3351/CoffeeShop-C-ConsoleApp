using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop
{
    class Program
    {
        static void Main(string[] args)
        {
            //Signature Change -> Use of Interface for Polymorphism
            //The program now uses interface, allowing flexibility if multiple implementations of coffee shop logic are needed
            InterfaceCoffeeShop coffeeShop = new CoffeeShop();

            //Method Extraction -> The program uses a loop to handle multiple customers
            //This ensures that the application can handle several customers in sequence until they choose to quit
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Welcome to the Coffee Shop!");

                //Display the menu and take the order
                coffeeShop.DisplayMenu();
                coffeeShop.TakeOrder();
                coffeeShop.ProcessPayment();

                Console.WriteLine("\nThank you for visiting!");
                Console.WriteLine("Press 'N' to stop serving customers or any other key to continue.");
                string input = Console.ReadLine();

                //Loop Continuation or Exit
                //This gives the user an option to either continue serving more customers or exit the program
                if (input.Equals("N", StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("Goodbye!");
                    break;
                }
            }
        }
    }
}
