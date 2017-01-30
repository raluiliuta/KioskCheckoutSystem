using System.Collections.Generic;

namespace KioskCheckoutSystem
{
    class PromotionCatalog
    {
        private static Dictionary<string, List<Promotion>> _allPromotions;

        public PromotionCatalog(Dictionary<string, List<Promotion>> allPromotions)
        {
            _allPromotions = allPromotions;
        }

        public List<Promotion> GetProductPromotions(string productName)
        {
            if (!_allPromotions.ContainsKey(productName))
            {
                return null;
            }

            return _allPromotions[productName];
        }        
    }
}
