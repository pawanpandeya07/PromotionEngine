using MK.PromotionEngine.Models;
using System.Collections.Generic;

namespace MK.PromotionEngine.EndUserLayer
{
    public interface IPromotionPresentation
    {
        /// <summary>
        /// GetUserInput
        /// </summary>
        /// <returns>List<Checkout><see cref="List<Checkout>"/></returns>
        List<Checkout> GetUserInput();

        /// <summary>
        /// Get TotalPrice
        /// </summary>
        /// <param name="offer"></param>
        /// <returns>bool</returns>
        bool GetTotalPrice(Offer offer);
    }
}
