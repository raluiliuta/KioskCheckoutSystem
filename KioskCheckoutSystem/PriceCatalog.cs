using System;
using System.Collections.Generic;

namespace KioskCheckoutSystem
{
    class PriceCatalog
    {
        private Dictionary<string, decimal> _regularPricesCatalog;

        public PriceCatalog(Dictionary<string, decimal> priceCatalog)
        {
            if(priceCatalog == null)
            {
                throw new ArgumentNullException();
            }
            _regularPricesCatalog = priceCatalog;
        }

        public decimal GetRegularPrice(string productName)
        {
            if (_regularPricesCatalog.ContainsKey(productName))
            {
                return _regularPricesCatalog[productName];
            }

            throw new Exception("Product should be added to the catalog");
        }
    }
}
