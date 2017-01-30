using System;

namespace KioskCheckoutSystem
{
    class KioskCheckoutService
    {
        static void Main(string[] args)
        {
            var basket = BasketProvider.GetBasket();
            var digitalReceiptFactory = new DigitalReceiptFactory(basket);

            //create the receipt
            var digitalReceipt = digitalReceiptFactory.GenerateDigitalReceipt();
            Console.Write(digitalReceipt.ToPrintableString());
        }
    }
}
