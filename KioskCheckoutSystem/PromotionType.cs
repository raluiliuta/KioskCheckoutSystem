using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KioskCheckoutSystem
{
    /// <summary>
    /// Type of promotion
    /// </summary>
    public enum PromotionType
    {
        /// <summary>
        /// Defines a new price for a quantity 
        /// </summary>
        /// <remarks>
        /// Ex: 2 Apples at 3$
        /// Ex: 1 Orange at 1$
        /// </remarks>
        FixedDiscount,
        /// <summary>
        /// Defines a percentage reduction of the regular price
        /// </summary>
        ///<remarks>
        ///Ex: Buy 1 get 1 free is actually a 50% reduction if buying 2 items
        ///</remarks> 
        PercentDiscount       
    }
}
