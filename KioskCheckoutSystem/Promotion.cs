using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KioskCheckoutSystem
{
    class Promotion : IConsolePrintable
    {
        public string Type { get; set; }
        public string Description { get; set; }
        public Dictionary<string, float> Condition { get; set; }
        public decimal PriceDiscountInfo { get; set; }

        
        public bool IsApplicable(Basket basket)
        {
            return !Condition.Any(cond => !basket.BasketItems.ContainsKey(cond.Key) || basket.BasketItems[cond.Key] < cond.Value);
        }

        //HAven't added the regular price as it may change and that would mean that all promotions must be modified as well
        //private decimal regPrice;

        public decimal GetPriceAfterPromotion(decimal initialPrice)
        {
            return PriceDiscountInfo;
        }

        public decimal GetDiscount(decimal initialPrice)
        {
            if (initialPrice < PriceDiscountInfo)
            {
                //Console.WriteLine();//notify that there is a problem with the promotion
                return 0m;
            }

            return initialPrice - PriceDiscountInfo;
        }

        public string ToPrintableString()
        {
            return Description;                
        }
    }
        
}
