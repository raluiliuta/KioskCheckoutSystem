using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;

namespace KioskCheckoutSystem
{
    class PromotionManager
    {
        private PromotionCatalog _promotionCatalog;

        public PromotionManager()
        {
            _promotionCatalog = GetPromotionCatalog();
        }

        public List<Promotion> FindApplicablePromotions(string productName, Basket basket)
        {
            //check if any promotions are define for an item
            var productPromotion = GetActiveProductPromotions(productName);

            if (productPromotion == null)
            {
                return null;
            }
            
            return productPromotion.Where(promo => IsPromotionApplicable(promo, basket)).ToList();            
        }

        public List<Promotion> GetActiveProductPromotions(string productName)
        {
            DateTime currentDate = DateTime.Now;

            //return only promotions that are active
            return _promotionCatalog.GetProductPromotions(productName).Where(promo =>
            promo.StartDate <= currentDate
            && promo.EndDate >= currentDate).ToList();
        }

        private bool IsPromotionApplicable(Promotion promotion, Basket basket)
        {
            return !promotion.Condition.Any(cond =>
                !basket.IsProductInBasket(cond.Key)
                || basket.GetProductQuantity(cond.Key) < cond.Value);
        }

        private PromotionCatalog GetPromotionCatalog()
        {
             return new PromotionCatalog(
                ResourceProvider.LoadJsonResource<Dictionary<string, List<Promotion>>>(
                    ConfigurationManager.AppSettings["pathToPromotion"]));            
        }
    }
}