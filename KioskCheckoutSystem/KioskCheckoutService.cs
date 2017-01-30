using System;

namespace KioskCheckoutSystem
{
    class KioskCheckoutService
    {
        static void Main(string[] args)
        {            
            var regPrices = PriceCatalogProvider.loadRegularPrices();
            var promo = PromotionManager.loadPromotions();
            var basket = BasketProvider.GetBasket();        

            //create the receipt
            var digitalReceipt = new DigitalReceipt(regPrices, promo, basket.BasketItems);
            Console.Write(digitalReceipt.ToPrintableString());
        }   
    }
}
