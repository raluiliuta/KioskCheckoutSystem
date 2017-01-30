using System.Collections.Generic;
using System.Linq;

namespace KioskCheckoutSystem
{
    public class Basket
    {
        private Dictionary<string, float> BasketItems { get; set; }

        public Basket(List<string> unorderedItemList)
        {
            BasketItems = new Dictionary<string, float>();

            if (unorderedItemList == null)
            {
                return;
            }          

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
            if(IsProductInBasket(productName))
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
