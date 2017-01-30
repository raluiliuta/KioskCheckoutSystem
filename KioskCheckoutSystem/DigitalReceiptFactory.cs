using System.Collections.Generic;
using System.Linq;

namespace KioskCheckoutSystem
{
    class DigitalReceiptFactory
    {
        private Basket _basket;
        private PriceCatalog _regularPriceCatalog;
        private PromotionManager _promotionManager;
        

        private ReceiptPriceCalculator _priceCalculator;

        public DigitalReceiptFactory(Basket basket)
        {
            _basket = basket;
            _regularPriceCatalog = PriceCatalogProvider.GetPriceCatalog();
            _promotionManager = new PromotionManager();
            _priceCalculator = new ReceiptPriceCalculator();
        }

        private Promotion SelectApplicablePromotion(string productName)
        {
            var promotionList = _promotionManager.FindApplicablePromotions(productName, _basket);

            if(promotionList == null)
            {
                return null;
            }

            //select the promotion that offers the best discount
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

            var promotionToApply = SelectApplicablePromotion(productName);

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
            if( _regularPriceCatalog == null )
            {
                return null;
            }

            var receiptItems = _basket.GetListOfBasketItems().Select(item => CreateDigitalReceiptItem(item)).ToList();

            return new DigitalReceipt(
                _priceCalculator.CalculateReceiptTotalPrice(receiptItems), 
                receiptItems);
        }       
    }
}
