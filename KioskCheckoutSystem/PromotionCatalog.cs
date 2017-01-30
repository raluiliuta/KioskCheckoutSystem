using System;
using System.Collections.Generic;
using System.Linq;

namespace KioskCheckoutSystem
{
    class PromotionCatalog
    {
        private static Dictionary<string, List<Promotion>> _allPromotions;

        public PromotionCatalog(Dictionary<string, List<Promotion>> allPromotions)
        {
            _allPromotions = allPromotions;
        }

        public List<Promotion> GetActiveProductPromotions(string productName)
        {
            if (!_allPromotions.ContainsKey(productName))
            {
                return null;
            }

            DateTime currentDate = DateTime.Now;

            //return only promotions that are active
            return _allPromotions[productName].Where(promo => 
            promo.StartDate <= currentDate 
            && promo.EndDate >= currentDate).ToList();
        }      
    }
}
