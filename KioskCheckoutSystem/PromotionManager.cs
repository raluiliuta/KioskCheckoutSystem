using System.Collections.Generic;
using System.Configuration;

namespace KioskCheckoutSystem
{
    static class PromotionManager
    {
        public static PromotionCatalog GetPromotionCatalog()
        {
             return new PromotionCatalog(
                ResourceProvider.loadJsonResource<Dictionary<string, List<Promotion>>>(
                    ConfigurationManager.AppSettings["pathToPromotion"]));            
        }
    }
}