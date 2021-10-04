using Microsoft.VisualStudio.TestTools.UnitTesting;
using MK.PromotionEngine.BusinessLayer;
using MK.PromotionEngine.Models;
using System.Collections.Generic;

namespace MK.PromotionEngine.Tests
{
    [TestClass]
    public class AdditionalItemOfferPromotionTests
    {
        List<Promotion> _promotions;
        Checkout _productWithOffer;
        Checkout _productWithoutOffer;
        Checkout _productWithOfferExtra;
        IPromotionAlgorithm _promotionAlgorithm;

        public AdditionalItemOfferPromotionTests()
        {            
            _promotionAlgorithm = new AdditionalItemOfferPromotion();
            _promotions = new List<Promotion>() 
                { new Promotion() { Type = "Single", ProductCode = "A", Price = 150, Quantity = 3 },
                  new Promotion() { Type = "Single", ProductCode = "B", Price = 50, Quantity = 2 }, 
                  new Promotion() { Type = "Combo", ProductCode = "C;D", Price = 20, Quantity = 5 }
                };

        }

        [TestMethod]
        public void AdditionalItemOfferPromotion_WithOffer()
        {
            //Arrange
            _productWithOffer = new Checkout() { ProductCode = "A", Quantity = 6, DefaultPrice = 30 };
            List<Checkout> order = new ();
            order.Add(_productWithOffer);
            double expectedValue = 300;
            bool canExecute = _promotionAlgorithm.CanExecute(_productWithOffer, _promotions);
            if (canExecute)
            {
                //Act
                double actualValue = _promotionAlgorithm.CalculateProductPrice(order);
                //Assert
                Assert.AreEqual(expectedValue, actualValue);
            }
        }
        [TestMethod]
        public void AdditionalItemOfferPromotion_WithoutOffer()
        {
            //Arrange
            _productWithoutOffer = new Checkout() { ProductCode = "A", Quantity = 3, DefaultPrice = 70 };
            List<Checkout> order = new();
            order.Add(_productWithoutOffer);
            double expectedValue = 150;
            bool canExecute = _promotionAlgorithm.CanExecute(_productWithoutOffer, _promotions);
            if (canExecute)
            {
                //Act
                double actualValue = _promotionAlgorithm.CalculateProductPrice(order);
                //Assert
                Assert.AreEqual(expectedValue, actualValue);
            }

        }
        [TestMethod]
        public void AdditionalItemOfferPromotion_WithOffer_ExtraItems()
        {
            //Arrange
            _productWithOfferExtra = new Checkout() { ProductCode = "A", Quantity = 5, DefaultPrice = 50 };
            List<Checkout> order = new ();
            order.Add(_productWithOfferExtra);
            double expectedValue = 250;
            bool canExecute = _promotionAlgorithm.CanExecute(_productWithOfferExtra, _promotions);
            if (canExecute)
            {
                //Act
                double actualValue = _promotionAlgorithm.CalculateProductPrice(order);
                //Assert
                Assert.AreEqual(expectedValue, actualValue);
            }

        }        
    }
}
