using MK.PromotionEngine.Models;
using System.Collections.Generic;

namespace MK.PromotionEngine.BusinessLayer
{
    public interface IPromotionAlgorithm
    {
        /// <summary>
        /// Can Execute
        /// </summary>
        /// <param name="product"></param>
        /// <param name="promotions"></param>
        /// <returns>bool</returns>
        bool CanExecute(Checkout productCheckout, List<Promotion> promotions);

        /// <summary>
        /// Calculate ProductPrice
        /// </summary>
        /// <param name="productCheckoutList"></param>
        /// <returns>double</returns>
        double CalculateProductPrice(List<Checkout> productCheckoutList);
    }
}
