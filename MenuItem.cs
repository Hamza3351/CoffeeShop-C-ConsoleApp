using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop
{
    //Field Encapsulation
    //The MenuItem class encapsulates the details of each menu item, ensuring that 
    //these fields are read-only and can't be modified after initialization
    public class MenuItem
    {
        public string Name { get; }
        public double Price { get; }

        //Constructor to initialize a MenuItem object
        public MenuItem(string name, double price)
        {
            Name = name;
            Price = price;
        }
    }
}
