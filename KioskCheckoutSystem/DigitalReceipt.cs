using System.Collections.Generic;
using System.Linq;

namespace KioskCheckoutSystem
{
    class DigitalReceipt : IConsolePrintable
    {
        private decimal _totalPrice = 0m;
        private List<DigitalReceiptItem> _items;

        public DigitalReceipt(decimal receiptTotalPrice, List<DigitalReceiptItem> receiptItems)
        {
            _totalPrice = receiptTotalPrice;
            _items = receiptItems;
        }

        public string ToPrintableString()
        {
            var stringifiedItems = string.Join("\n",
                _items.Select(item => item.ToPrintableString()));
            
            return string.Format("{1,33}GroceryCo \n\n{0}\n\n{1,33} Total Price: {2,20:C2}", stringifiedItems, "", _totalPrice);
        }
    }
}
