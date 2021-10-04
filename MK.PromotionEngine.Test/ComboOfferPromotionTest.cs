using Microsoft.VisualStudio.TestTools.UnitTesting;
using MK.PromotionEngine.BusinessLayer;
using MK.PromotionEngine.Models;
using System.Collections.Generic;
using System.Linq;

namespace MK.PromotionEngine.Test
{
    [TestClass]
    public class ComboOfferPromotionTest
    {
        List<Promotion> _promotions;        
        List<Checkout> _productWithOffer;
        List<Checkout> _productWithoutOffer;
        IPromotionAlgorithm _promotionAlgorithm;

        public ComboOfferPromotionTest()
        {
            _promotionAlgorithm = new ComboOfferPromotion();           
            
            _promotions = new List<Promotion>() { new Promotion() { Type = "Single", ProductCode = "A", Price = 200, Quantity = 5 },
                                                  new Promotion() { Type = "Single", ProductCode = "B", Price = 140, Quantity = 4 }, 
                                                  new Promotion() { Type = "Combo", ProductCode = "C;D", Price = 90, Quantity = 2 } 
                                                };
        }

        [TestMethod]
        public void Combo_WithOffer()
        {
            //Arrange
            _productWithOffer = new List<Checkout>() { new Checkout() { ProductCode = "C", Quantity = 1, DefaultPrice = 40 },
                                                       new Checkout() { ProductCode = "D", Quantity = 3, DefaultPrice = 35 }
                                                     };
            double expectedValue = 170;
            bool canExecute = _promotionAlgorithm.CanExecute(_productWithOffer.FirstOrDefault(), _promotions);
            if (canExecute)
            {
                //Act
                double actualValue = _promotionAlgorithm.CalculateProductPrice(_productWithOffer);
                //Assert
                Assert.AreEqual(expectedValue, actualValue);
            }

        }
        [TestMethod]
        public void Combo_WithoutOffer()
        {
            //Arrange
            _productWithoutOffer = new List<Checkout>() { new Checkout() { ProductCode = "C", Quantity = 2, DefaultPrice = 45 } };
            double expectedValue = 45;
            bool canExecute = _promotionAlgorithm.CanExecute(_productWithoutOffer.FirstOrDefault(), _promotions);
            if (canExecute)
            {
                //Act
                double actualValue = _promotionAlgorithm.CalculateProductPrice(_productWithoutOffer);
                //Assert
                Assert.AreEqual(expectedValue, actualValue);
            }
        }
    }
}
