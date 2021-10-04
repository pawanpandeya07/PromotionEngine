using MK.PromotionEngine.Common;
using MK.PromotionEngine.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MK.PromotionEngine.BusinessLayer
{
    public class ComboOfferPromotion : IPromotionAlgorithm
    {
        private Promotion promotion;
        private Checkout checkout;
        private List<Checkout> productCheckouts;

        /// <summary>
        /// CalculateProductPrice
        /// </summary>
        /// <param name="productCheckoutList"></param>
        /// <returns></returns>
        public double CalculateProductPrice(List<Checkout> productCheckoutList)
        {
            productCheckouts = new List<Checkout>();
            double finalPrice = 0;

            try
            {
                string[] str = promotion.ProductCode.Split(';').ToArray();
                foreach (Checkout item in productCheckoutList)
                {
                    if (str.Contains(item.ProductCode))
                    {
                        productCheckouts.Add(item);
                        item.IsValidated = true;
                    }
                }

                int firstQuantity = 0, secondQuantity = 0;               
                if (productCheckouts.Count > 1)
                {
                    firstQuantity = productCheckouts[0].Quantity;
                    secondQuantity = productCheckouts[1].Quantity;
                }

                if (firstQuantity == 0 || secondQuantity == 0)
                {
                    return checkout.DefaultPrice;

                }

                finalPrice = CalculateFinalPrice(finalPrice, firstQuantity, secondQuantity);
            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message);
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
            promotion = promotions.Where(s => s.ProductCode.Split(';').Contains(checkout.ProductCode)).FirstOrDefault();
            if (promotion != null && !productCheckout.IsValidated && promotion.Type == PromotionType.Combo)
            {
                return true;
            }
            return false;
        }

        #region Private Methods
        private double CalculateFinalPrice(double finalPrice, int firstQuantity, int secondQuantity)
        {
            if (firstQuantity == secondQuantity)
            {
                finalPrice = promotion.Price * firstQuantity;
            }
            else if (firstQuantity > secondQuantity)
            {
                int additionalItems = firstQuantity - secondQuantity;
                finalPrice = (checkout.DefaultPrice * additionalItems) + (promotion.Price * secondQuantity);
            }
            else if (firstQuantity < secondQuantity)
            {
                int additionalItems = secondQuantity - firstQuantity;
                finalPrice = (checkout.DefaultPrice * additionalItems) + (promotion.Price * firstQuantity);
            }

            return finalPrice;
        }
        #endregion
    }
}
