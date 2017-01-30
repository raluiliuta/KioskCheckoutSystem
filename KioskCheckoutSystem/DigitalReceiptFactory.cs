using System.Collections.Generic;
using System.Linq;

namespace KioskCheckoutSystem
{
    class DigitalReceiptFactory
    {
        private Basket _basket;
        private PriceCatalog _regularPriceCatalog;
        private PromotionCatalog _promotionCatalog;

        private ReceiptPriceCalculator _priceCalculator;

        public DigitalReceiptFactory(Basket basket)
        {
            _basket = basket;
            _regularPriceCatalog = PriceCatalogProvider.GetPriceCatalog();
            _promotionCatalog = PromotionManager.GetPromotionCatalog();
            _priceCalculator = new ReceiptPriceCalculator();
        }

        private bool IsPromotionApplicable(Promotion promotion)
        {
            return !promotion.Condition.Any(cond =>
                !_basket.IsProductInBasket(cond.Key)
                || _basket.GetProductQuantity(cond.Key) < cond.Value);
        }

        public Promotion FindApplicablePromotion(string productName)
        {
            //check if any promotions are define for an item
            var productPromotion = _promotionCatalog.GetActiveProductPromotions(productName);

            if (productPromotion == null)
            {
                return null;
            }

            //select the promotion that offers the best discount
            var promotionList = productPromotion.Where(promo => IsPromotionApplicable(promo)).ToList();

            var maxDiscount = 0m;
            Promotion promotionToApply = null;

            foreach (var promo in promotionList)
            {
                var promoDiscount = _priceCalculator.CalculateTotalDiscount(
                    productName,
                    _basket.GetProductQuantity(productName),
                    _regularPriceCatalog.GetRegularPrice(productName),
                    promo);

                if (maxDiscount < promoDiscount)
                {
                    maxDiscount = promoDiscount;
                    promotionToApply = promo;
                }
            }

            return promotionToApply;          
        }

        private DigitalReceiptItem CreateDigitalReceiptItem(BasketItem basketItem)
        {
            var productName = basketItem.ProductName;
            var quantityToBuy = basketItem.Quantity;

            var promotionToApply = FindApplicablePromotion(productName);

            var discount = 0m;

            if (promotionToApply != null)
            {
                discount = _priceCalculator.CalculateTotalDiscount(
                    productName, 
                    _basket.GetProductQuantity(productName), 
                    _regularPriceCatalog.GetRegularPrice(productName), 
                    promotionToApply);
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
            var receiptItems = _basket.GetListOfBasketItems().Select(item => CreateDigitalReceiptItem(item)).ToList();

            return new DigitalReceipt(
                _priceCalculator.CalculateReceiptTotalPrice(receiptItems), 
                receiptItems);
        }       
    }
}
