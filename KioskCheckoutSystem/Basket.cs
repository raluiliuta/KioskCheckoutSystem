using System.Collections.Generic;
using System.Linq;

namespace KioskCheckoutSystem
{
    class Basket
    {
        public Dictionary<string, float> BasketItems { get; set; }

        public Basket(List<string> unorderedItemList)
        {
            BasketItems = new Dictionary<string, float>();

            foreach (var productName in unorderedItemList)
            {
                if (BasketItems.ContainsKey(productName))
                {
                    BasketItems[productName]++;
                }
                else
                {
                    BasketItems.Add(productName, 1);
                }
            }
        }
    }
}
