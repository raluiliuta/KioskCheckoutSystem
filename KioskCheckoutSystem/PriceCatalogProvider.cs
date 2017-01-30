using System.Collections.Generic;
using System.Configuration;

namespace KioskCheckoutSystem
{
    static class PriceCatalogProvider
    {
        public static PriceCatalog GetPriceCatalog()
        {
            var loadedCatalog = ResourceProvider.LoadJsonResource<Dictionary<string, decimal>>(ConfigurationManager.AppSettings["pathToPriceCatalog"]);

            return loadedCatalog == null ? null : new PriceCatalog(loadedCatalog);
        }
    }
}
