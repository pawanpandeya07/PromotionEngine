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
            _promotions = new () 
            { 
                new Promotion() { Type = "Single", ProductCode = "A", Price = 130, Quantity = 3 },
                new Promotion() { Type = "Single", ProductCode = "B", Price = 45, Quantity = 2 },
                new Promotion() { Type = "Combo", ProductCode = "C;D", Price = 30, Quantity = 3 }
            };
        }

        //Scenario A
        //1 * A 50
        //1 * B 30
        //1 * C 20
        //Total 100
        [TestMethod]
        public void WithoutOffer()
        {
            //Arrange
            List<Checkout> order = new () 
            { 
                new Checkout() { ProductCode = "A", Quantity = 1, DefaultPrice = 50 },
                new Checkout() { ProductCode = "B", Quantity = 1, DefaultPrice = 30 },
                new Checkout() { ProductCode = "C", Quantity = 1, DefaultPrice = 20 } };
            double expectedValue = 100;
            //Act
            double actualValue = promotionService.ApplyPromotions(order, _promotions).TotalPrice;
            //Assert
            Assert.AreEqual(expectedValue, actualValue);
        }
        //Scenario B
        //5 * A 130 + 2*50
        //5 * B 45 + 45 + 30
        //1 * C 28
        //Total 370

        [TestMethod]
        public void TwoOffers_Single()
        {
            List<Checkout> order = new () 
            { 
                new Checkout() { ProductCode = "A", Quantity = 5, DefaultPrice = 50 },
                new Checkout() { ProductCode = "B", Quantity = 5, DefaultPrice = 30 },
                new Checkout() { ProductCode = "C", Quantity = 1, DefaultPrice = 20 } 
            };
            double expectedValue = 370;
            double actualValue = promotionService.ApplyPromotions(order, _promotions).TotalPrice;
            Assert.AreEqual(expectedValue, actualValue);
        }
        //Scenario C
        //3 * A 130
        //5 * B 45 + 45 + 1 * 30
        //1 * C -
        //1 * D 30
        //Total 280
        [TestMethod]
        public void TwoOffers_Combo()
        {
            List<Checkout> orderCart = new()
            {
                new Checkout() { ProductCode = "A", Quantity = 3, DefaultPrice = 50 },
                new Checkout() { ProductCode = "B", Quantity = 5, DefaultPrice = 30 },
                new Checkout() { ProductCode = "C", Quantity = 1, DefaultPrice = 20 },
                new Checkout() { ProductCode = "D", Quantity = 1, DefaultPrice = 15 }
            };
            double expectedValue = 280;
            double actualValue = promotionService.ApplyPromotions(orderCart, _promotions).TotalPrice;
            Assert.AreEqual(expectedValue, actualValue);
        }

    }
}
