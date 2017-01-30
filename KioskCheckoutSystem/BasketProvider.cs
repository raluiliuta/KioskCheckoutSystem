using System.Collections.Generic;
using System.Configuration;


namespace KioskCheckoutSystem
{
    class BasketProvider
    {
        private string _pathToBasket = ConfigurationManager.AppSettings["pathToBasket"];

        private List<string> LoadBasket()
        {
            return ResourceProvider.ReadLinesFromFile(_pathToBasket);            
        }

        public Basket GetBasket()
        {
            var list = LoadBasket();
            return list != null ? new Basket(list) : null;                        
        }

        public Basket GetBasket(string pathToBasket)
        {
            _pathToBasket = pathToBasket;
            return GetBasket();
        }

    }
}
