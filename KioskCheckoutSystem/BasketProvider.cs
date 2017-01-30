using System.Collections.Generic;
using System.Configuration;


namespace KioskCheckoutSystem
{
    static class BasketProvider
    {
        private static List<string> LoadBasket()
        {
            return ResourceProvider.ReadLinesFromFile(ConfigurationManager.AppSettings["pathToBasket"]);            
        }

        public static Basket GetBasket()
        {
            var list = LoadBasket();

            if(list != null)
            {
                return new Basket(list);
            }
            else
            {
                return null;
            }
            
        }
    }
}
