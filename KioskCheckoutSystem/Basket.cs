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

        public bool IsProductInBasket(string productName)
        {
            return BasketItems.ContainsKey(productName);
        }

        public float GetProductQuantity(string productName)
        {
            if(BasketItems.ContainsKey(productName))
            {
                return BasketItems[productName];
            }

            return 0f;
        }

        public List<BasketItem> GetListOfBasketItems()
        {
            return BasketItems.Select(item => new BasketItem(item.Key, item.Value)).ToList();
        }
    }
}
