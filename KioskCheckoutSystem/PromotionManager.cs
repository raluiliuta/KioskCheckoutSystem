using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KioskCheckoutSystem
{
    static class PromotionManager
    {
        static private Dictionary<string, List<Promotion>> allPromotions;

        public static PromotionCatalog GetPromotionCatalog()
        {
             return new PromotionCatalog(
                 ResourceProvider.loadJsonResource<Dictionary<string, List<Promotion>>>(ConfigurationManager.AppSettings["pathToPromotion"]));
             
        }
    }
}
