using System.Collections.Generic;
using System.Configuration;

namespace KioskCheckoutSystem
{
    static class PriceCatalogProvider
    {
        public static PriceCatalog GetPriceCatalog()
        {
            return new PriceCatalog(
                ResourceProvider.loadJsonResource<Dictionary<string, decimal>>(ConfigurationManager.AppSettings["pathToPriceCatalog"]));
        }
    }
}
