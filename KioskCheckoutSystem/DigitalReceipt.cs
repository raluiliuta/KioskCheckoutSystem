using System.Collections.Generic;
using System.Linq;

namespace KioskCheckoutSystem
{
    class DigitalReceipt : IConsolePrintable
    {
        private decimal totalPrice = 0m;
        List<DigitalReceiptItem> items;

        public decimal TotalPrice
        {
            get
            {
                return totalPrice;
            }

            private set
            {
                totalPrice = value;
            }
        }       

        private void CalculateTotalPrice()
        {
            items.ForEach(item => TotalPrice += item.GetTotalPrice());
        }

        public DigitalReceipt(Dictionary<string, decimal> regPrices, Dictionary<string, List<Promotion>> promotions, Dictionary<string, float> basket )
        {
            items = basket.Select(item => new DigitalReceiptItem
            {
                ProductName = item.Key,
                RegularPrice = regPrices[item.Key],
                AppliedPromotion = promotions.ContainsKey(item.Key) ? promotions[item.Key].ElementAt(0) : null,
                Quantity = item.Value
            }).ToList();

            CalculateTotalPrice();
        }

        public string ToPrintableString()
        {
            var stringifiedItems = string.Join("\n",
                items.Select(item => item.ToPrintableString()));
            return string.Format("{0}\n\n \t \t Total Price: \t {1:C2}", stringifiedItems, TotalPrice);
        }
    }
}
