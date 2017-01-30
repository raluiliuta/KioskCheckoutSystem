using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KioskCheckoutSystem
{
    static class BasketProvider
    {
        static public List<string> loadBasket()
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

        static public Basket GetBasket()
        {
            var list = loadBasket();
            return new Basket(list);
        }
    }
}
