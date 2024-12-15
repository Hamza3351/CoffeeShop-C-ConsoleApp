using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop
{
    //Interface Extraction
    //Extracted the CoffeeShop operations into an interface to allow flexibility
    //in case of multiple implementations or for testing purposes
    public interface InterfaceCoffeeShop
    {
        void DisplayMenu();
        void TakeOrder();
        void ProcessPayment();
    }
}
