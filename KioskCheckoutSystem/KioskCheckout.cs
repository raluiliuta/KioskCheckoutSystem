using System;

namespace KioskCheckoutSystem
{
    class KioskCheckout
    {
        static void Main(string[] args)
        {
            var basketProvider = new BasketProvider();

            var basket = args.Length > 0 ?
                basketProvider.GetBasket(args[0])
                : basketProvider.GetBasket();

            var kioskCheckoutService = new KioskCheckoutService(basket);
            Console.WriteLine(kioskCheckoutService.GetReceipt());
        }
    }
}