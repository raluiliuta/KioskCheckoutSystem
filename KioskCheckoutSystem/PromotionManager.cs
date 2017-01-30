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

        public static Dictionary<string, List<Promotion>> loadPromotions()
        {
            allPromotions = ResourceProvider.loadJsonResource<Dictionary<string, List<Promotion>>>(ConfigurationManager.AppSettings["pathToPromotion"]);
            return allPromotions;
        }

        public static Promotion GetApplicablePromotions(string productName, Basket basket)
        {
            if( !allPromotions.ContainsKey(productName) )
            {
                return null;
            }

            var promotionsToCkeck = allPromotions[productName];

            var list = promotionsToCkeck.Where(promo => promo.IsApplicable(basket)).ToList();

            decimal minDiscount = 0m;

            for(var i = 0; i<= list.Count; i++)
            {

            }

            return null;
        }


    }
}
