using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
