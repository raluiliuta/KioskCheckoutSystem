using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KioskCheckoutSystem
{
    static class PriceCatalogProvider
    {
        //static string ;

        static public Dictionary<string, decimal> loadRegularPrices()
        {
            return ResourceProvider.loadJsonResource<Dictionary<string, decimal>>(ConfigurationManager.AppSettings["pathToPriceCatalog"]);
        }
    }
}
