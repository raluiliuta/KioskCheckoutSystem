using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KioskCheckoutSystem
{
    class PromotionCatalog
    {
        static Dictionary<string, List<Promotion>> _allPromotions;

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
