using Microsoft.VisualStudio.TestTools.UnitTesting;
using MK.PromotionEngine.BusinessLayer;
using MK.PromotionEngine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MK.PromotionEngine.Test
{
    [TestClass]
    public class PromotionServiceTest
    {
        List<Promotion> _promotions;

        IPromotionService promotionService;

        public PromotionServiceTest()
        {
            promotionService = new PromotionService();
            _promotions = new List<Promotion>() { new Promotion() { Type = "Single", ProductCode = "A", Price = 10, Quantity = 1 }, 
                                                  new Promotion() { Type = "Single", ProductCode = "B", Price = 20, Quantity = 2 }, 
                                                  new Promotion() { Type = "Combo", ProductCode = "C;D", Price = 30, Quantity = 3 } };
        }

        
        [TestMethod]
        public void WithoutOffer()
        {
            //Arrange
            List<Checkout> order = new () 
            { 
                new Checkout() { ProductCode = "A", Quantity = 1, DefaultPrice = 50 }, 
                new Checkout() { ProductCode = "B", Quantity = 2, DefaultPrice = 40 }, 
                new Checkout() { ProductCode = "C", Quantity = 3, DefaultPrice = 30 } };
            double expectedValue = 60;
            //Act
            double actualValue = promotionService.ApplyPromotions(order, _promotions).TotalPrice;
            //Assert
            Assert.AreEqual(expectedValue, actualValue);
        }
        [TestMethod]
        public void TwoOffers_Combo()
        {
            List<Checkout> orderCart = new () 
            { 
                new Checkout() { ProductCode = "A", Quantity = 3, DefaultPrice = 50 }, 
                new Checkout() { ProductCode = "B", Quantity = 5, DefaultPrice = 30 }, 
                new Checkout() { ProductCode = "C", Quantity = 1, DefaultPrice = 20 }, 
                new Checkout() { ProductCode = "D", Quantity = 1, DefaultPrice = 15 } 
            };
            double expectedValue = 130;
            double actualValue = promotionService.ApplyPromotions(orderCart, _promotions).TotalPrice;
            Assert.AreEqual(expectedValue, actualValue);
        }
        [TestMethod]
        public void TwoOffers_Single()
        {
            List<Checkout> order = new () 
            { 
                new Checkout() { ProductCode = "A", Quantity = 5, DefaultPrice = 50 },
                new Checkout() { ProductCode = "B", Quantity = 5, DefaultPrice = 30 }, 
                new Checkout() { ProductCode = "C", Quantity = 1, DefaultPrice = 20 } 
            };
            double expectedValue = 140;
            double actualValue = promotionService.ApplyPromotions(order, _promotions).TotalPrice;
            Assert.AreEqual(expectedValue, actualValue);
        }

    }
}
