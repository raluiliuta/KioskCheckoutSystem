using System.Collections.Generic;

namespace KioskCheckoutSystem
{
    class PriceCatalog
    {
        private Dictionary<string, decimal> _regularPricesCatalog;

        public PriceCatalog(Dictionary<string, decimal> priceCatalog)
        {
            _regularPricesCatalog = priceCatalog;
        }

        public decimal GetRegularPrice(string productName)
        {
            return _regularPricesCatalog[productName];
        }
    }
}
