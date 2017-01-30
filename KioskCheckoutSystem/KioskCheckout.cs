using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KioskCheckoutSystem
{
    class KioskCheckout
    {

        static void Main(string[] args)
        {
            var basket = BasketProvider.GetBasket();
            var kioskCheckoutService = new KioskCheckoutService(basket);

            Console.WriteLine(kioskCheckoutService.GetReceipt());            
        }

    }
}
