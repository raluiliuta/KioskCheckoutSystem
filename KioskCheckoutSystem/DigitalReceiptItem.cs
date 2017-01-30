namespace KioskCheckoutSystem
{
    class DigitalReceiptItem : IConsolePrintable
    {
        public string ProductName { get; set; }
        public decimal RegularPrice { get; set; }
        public Promotion AppliedPromotion { get; set; }
        public float Quantity { get; set; }
        public decimal Discount { get; set; }

        public DigitalReceiptItem(
            string productName,
            decimal regularPrice,
            Promotion appliedPromotion,
            float quantity,
            decimal discount)
        {
            ProductName = productName;
            RegularPrice = regularPrice;
            AppliedPromotion = appliedPromotion;
            Quantity = quantity;
            Discount = discount;
        }

        public bool IsAnyPromotionApplied()
        {
            return AppliedPromotion != null;
        }

        public string ToPrintableString()
        {
            return string.Format(
                    "{0} \t {1} x \t {2:C2} \t = \t {3:C2} \n {4} \t \t {5}",
                    ProductName,
                    Quantity,
                    RegularPrice,
                    (decimal)Quantity * RegularPrice,
                    IsAnyPromotionApplied() ? AppliedPromotion.ToPrintableString() : "",
                    IsAnyPromotionApplied() ? string.Format("{0:C2}", Discount * -1) : "");
        }
    }
}
