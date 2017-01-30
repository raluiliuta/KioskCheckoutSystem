using System;
using System.Collections.Generic;
using System.Linq;

namespace KioskCheckoutSystem
{
    class PriceCalculator
    {
        private Basket _basket;
        private PriceCatalog _regularPriceCatalog;
        private PromotionCatalog _promotionCatalog;

        public PriceCalculator(Basket basket)
        {
            _basket = basket;
            _regularPriceCatalog = PriceCatalogProvider.GetPriceCatalog();
            _promotionCatalog = PromotionManager.GetPromotionCatalog();
        }

        private decimal CalculateTotalPrice(List<DigitalReceiptItem> receiptItems)
        {
            var totalPrice = 0m;
            foreach (var item in receiptItems)
            {
                totalPrice += (item.RegularPrice * (decimal)item.Quantity) - item.Discount;
            }
            return totalPrice;
        }

        public bool IsPromotionApplicable(Promotion promotion)
        {
            return !promotion.Condition.Any(cond =>
                !_basket.BasketItems.ContainsKey(cond.Key)
                || _basket.BasketItems[cond.Key] < cond.Value);
        }

        public Promotion FindApplicablePromotion(string productName)
        {
            //check if any promotions are define for an item
            var productPromotion = _promotionCatalog.GetProductPromotions(productName);

            if (productPromotion == null)
            {
                return null;
            }

            //select the promotion that offers the best discount
            var list = productPromotion.Where(promo => IsPromotionApplicable(promo)).ToList();

            var maxDiscount = 0m;
            Promotion promotionToApply = null;

            foreach (var promo in list)
            {
                var promoDiscount = CalculateTotalDiscount(productName, promo);
                if (maxDiscount < promoDiscount)
                {
                    maxDiscount = promoDiscount;
                    promotionToApply = promo;
                }
            }

            return promotionToApply;
        }

        private decimal CalculateTotalDiscount(string productName, Promotion promotion)
        {
            var regularPrice = _regularPriceCatalog.GetRegularPrice(productName);

            var discountedPrice = 0m;
            var discountedQuantity = 0f;

            if (promotion.Type == PromotionType.FixedDiscount)
            {
                discountedQuantity = promotion.Condition[productName];
                discountedPrice = promotion.PriceDiscountInfo;
            }
            else if (promotion.Type == PromotionType.PercentDiscount)
            {
                discountedQuantity = promotion.Condition[productName];
                discountedPrice = promotion.PriceDiscountInfo * (regularPrice * (decimal)discountedQuantity);
            }

            if (regularPrice * (decimal)discountedQuantity < discountedPrice)
            {
                //Console.WriteLine();//notify that there is a problem with the promotion
                return 0m;
            }

            var oneApplicationDiscount = regularPrice * (decimal)discountedQuantity - discountedPrice;

            var timesToApplyPromotion = Math.Floor(_basket.BasketItems[productName] / discountedQuantity);

            return oneApplicationDiscount * (decimal)timesToApplyPromotion;
        }

        private DigitalReceiptItem CreateDigitalReceiptItem(KeyValuePair<string, float> basketItem)
        {
            var productName = basketItem.Key;
            var quantityToBuy = basketItem.Value;

            var promotionToApply = FindApplicablePromotion(productName);

            var discount = 0m;

            if (promotionToApply != null)
            {
                discount = CalculateTotalDiscount(productName, promotionToApply);
            }

            //create receipt item
            return new DigitalReceiptItem(
                productName,
                _regularPriceCatalog.GetRegularPrice(productName),
                promotionToApply,
                quantityToBuy,
                discount);
        }

        public DigitalReceipt GenerateDigitalReceipt()
        {
            var receiptItems = _basket.BasketItems.Select(item => CreateDigitalReceiptItem(item)).ToList();

            return new DigitalReceipt(CalculateTotalPrice(receiptItems), receiptItems);
        }
    }
}
