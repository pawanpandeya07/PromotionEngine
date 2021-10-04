using MK.PromotionEngine.Models;
using System.Collections.Generic;

namespace MK.PromotionEngine.BusinessLayer
{
    public interface IPromotionService
    {
        /// <summary>
        /// Apply Promotions based on available offers
        /// </summary>
        /// <param name="checkoutList"></param>
        /// <param name="promotions"></param>
        /// <returns></returns>
        Offer ApplyPromotions(List<Checkout> checkoutList, List<Promotion> promotions);
    }
}
