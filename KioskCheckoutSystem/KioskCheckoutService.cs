using System;

namespace KioskCheckoutSystem
{
    class KioskCheckoutService
    {
        static void Main(string[] args)
        {            
            var basket = BasketProvider.GetBasket();
            var priceCalculator = new PriceCalculator(basket);        

            //create the receipt
            var digitalReceipt = priceCalculator.GenerateDigitalReceipt();
            Console.Write(digitalReceipt.ToPrintableString());
        }   
    }
}
