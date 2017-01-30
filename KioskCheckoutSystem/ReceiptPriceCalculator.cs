using System;
using System.Collections.Generic;
using System.Linq;

namespace KioskCheckoutSystem
{
    class ReceiptPriceCalculator
    {
        public decimal CalculateReceiptTotalPrice(List<DigitalReceiptItem> receiptItems)
        {
            var totalPrice = 0m;
            foreach (var item in receiptItems)
            {
                totalPrice += (item.RegularPrice * (decimal)item.Quantity) - item.Discount;
            }
            return totalPrice;
        }                

        public decimal CalculateTotalDiscount(string productName, float quantity, decimal regularPrice, Promotion promotion)
        {
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

            var timesToApplyPromotion = Math.Floor(quantity / discountedQuantity);

            return oneApplicationDiscount * (decimal)timesToApplyPromotion;
        }        
    }
}
