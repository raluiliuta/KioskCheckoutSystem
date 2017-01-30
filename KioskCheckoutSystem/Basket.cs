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

            for (var i = 0; i < unorderedItemList.Count; i++)
            {
                string poductName = unorderedItemList.ElementAt(i);

                if (BasketItems.ContainsKey(poductName))
                {
                    BasketItems[poductName]++;
                }
                else
                {
                    BasketItems.Add(poductName, 1);
                }
            }
        }


    }
}
