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
                    "\t{0,-20}{1,10}x{2,10:C2} = {3,15:C2}{4}",
                    ProductName,
                    Quantity,
                    RegularPrice,
                    (decimal)Quantity * RegularPrice,
                    IsAnyPromotionApplied() ? 
                    string.Format(
                        "\n\t {0,-43}{1,15:C2}", 
                        AppliedPromotion.ToPrintableString(), 
                        Discount * -1) 
                    : "");      
        }
    }
}
