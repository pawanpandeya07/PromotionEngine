using MK.PromotionEngine.Common;
using MK.PromotionEngine.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MK.PromotionEngine.BusinessLayer
{
    public class AdditionalItemOfferPromotion : IPromotionAlgorithm
    {
        private Promotion promotion;
        private Checkout checkout;
        public AdditionalItemOfferPromotion()
        {
            promotion = new Promotion();
            checkout = new Checkout();
        }
        public double CalculateProductPrice(List<Checkout> productCheckoutList)
        {
            double finalPrice = 0;
            try
            {
                int totalEligibleItems = checkout.Quantity / promotion.Quantity;
                int remainingItems = checkout.Quantity % promotion.Quantity;
                finalPrice = promotion.Price * totalEligibleItems + remainingItems * (checkout.DefaultPrice);

            }
            catch (ArithmeticException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return finalPrice;
        }
        /// <summary>
        /// CanExecute
        /// </summary>
        /// <param name="productCheckout"></param>
        /// <param name="promotions"></param>
        /// <returns></returns>
        public bool CanExecute(Checkout productCheckout, List<Promotion> promotions)
        {
            checkout = productCheckout;
            promotion = promotions.Where(s => s.ProductCode == productCheckout.ProductCode).FirstOrDefault();
            if (promotion != null && promotion.Type == PromotionType.Single)
            {
                productCheckout.IsValidated = true;
                return true;
            }
            return false;
        }
    }
}
