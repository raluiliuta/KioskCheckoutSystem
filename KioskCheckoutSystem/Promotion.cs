using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KioskCheckoutSystem
{
    class Promotion : IConsolePrintable
    {
        [JsonProperty("promotionType", Required = Required.Always)]
        [JsonConverter(typeof(StringEnumConverter))]
        public PromotionType Type { get; set; }

        public string Description { get; set; }
        public Dictionary<string, float> Condition { get; set; }
        public decimal PriceDiscountInfo { get; set; }              

        public string ToPrintableString()
        {

            var stringifiedConditions = "";

            if (Type == PromotionType.FixedDiscount)
            {
                stringifiedConditions = string.Join(
                    " ", 
                    Condition.Select(item => string.Format("{0}", item.Value)));
                stringifiedConditions = string.Format("{0} @ {1:C2}", stringifiedConditions, PriceDiscountInfo);
            }           

            return string.Format("{0} {1}", Description, stringifiedConditions);                
        }
    }        
}
