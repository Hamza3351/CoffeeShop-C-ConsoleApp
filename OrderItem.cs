using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop
{
    //Field Encapsulation
    //The OrderItem class encapsulates a menu item and its quantity in the order, preventing external 
    //modification of these properties
    public class OrderItem
    {
        public MenuItem MenuItem { get; }
        public int Quantity { get; }

        //Constructor to initialize an order item with the associated menu item and quantity
        public OrderItem(MenuItem menuItem, int quantity)
        {
            MenuItem = menuItem;
            Quantity = quantity;
        }
    }
}
