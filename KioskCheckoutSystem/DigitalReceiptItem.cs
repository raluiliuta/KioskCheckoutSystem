namespace KioskCheckoutSystem
{
    class DigitalReceiptItem : IConsolePrintable
    {
        public string ProductName { get; set; }
        public decimal RegularPrice { get; set; }
        public Promotion AppliedPromotion { get; set; }
        public float Quantity { get; set; }

        public bool IsAnyPromotionApplied()
        {
            return AppliedPromotion != null;
        }

        public decimal GetCurrentPrice()
        {            
            return IsAnyPromotionApplied() 
                ? AppliedPromotion.GetPriceAfterPromotion(RegularPrice)
                : RegularPrice;
        }

        public decimal GetCurrentDiscount()
        {
            if (IsAnyPromotionApplied())
            {
                return AppliedPromotion.GetDiscount(RegularPrice) * (decimal)Quantity * -1m;
            }

            return 0m;
        }

        public decimal GetTotalPrice()
        {
            return GetCurrentPrice() * (decimal) Quantity;
        }

        public string ToPrintableString()
        {
            return string.Format(
                    "{0} \t {1} x \t {2:C2} \t = \t {3:C2} \n {4} \t \t {5}",
                    ProductName,
                    Quantity,
                    RegularPrice,
                    (decimal)(Quantity) * RegularPrice,
                    IsAnyPromotionApplied() ? AppliedPromotion.ToPrintableString() : "",
                    IsAnyPromotionApplied() ? string.Format("{0:C2}",GetCurrentDiscount()) : "");            
        }
    }
}
