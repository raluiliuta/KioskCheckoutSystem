using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;

namespace KioskCheckoutSystem
{
    static class BasketProvider
    {
        private static List<string> LoadBasket()
        {
            try
            {
                string[] lines = System.IO.File.ReadAllLines(ConfigurationManager.AppSettings["pathToBasket"]);
                return lines.ToList();
            }
            catch (Exception e)
            {

            }

            return null;
        }

        public static Basket GetBasket()
        {
            var list = LoadBasket();
            return new Basket(list);
        }
    }
}
