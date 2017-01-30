using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace KioskCheckoutSystem.Test
{
    [TestClass]
    public class BasketTest
    {
        List<string> unorderedList;
        Basket basket;

        [TestInitialize]
        public void TestInitialize()
        {
            unorderedList = new List<string>();
            unorderedList.Add("Apple");
            unorderedList.Add("Orange");
            unorderedList.Add("Orange");
            unorderedList.Add("Orange");
            unorderedList.Add("Orange");
            unorderedList.Add("Apple");
            unorderedList.Add("Apple");
            unorderedList.Add("Banana");

            basket = new Basket(unorderedList);
        }

        [TestMethod]
        public void ExistingProductIsProductInBasketTest()
        {
            Assert.IsTrue(basket.IsProductInBasket("Apple"));            
        }

        [TestMethod]
        public void MissionProductIsProductInBasketTest()
        {
            Assert.IsFalse(basket.IsProductInBasket("Onion"));
        }

        [TestMethod]
        public void GetProductQuantityTest()
        {
            Assert.AreEqual(basket.GetProductQuantity("Apple"), 3);
        }        
    }
}
