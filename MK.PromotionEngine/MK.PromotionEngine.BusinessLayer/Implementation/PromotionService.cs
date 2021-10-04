using MK.PromotionEngine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MK.PromotionEngine.BusinessLayer
{
    public class PromotionService : IPromotionService
    {
        /// <summary>
        /// ApplyPromotions
        /// </summary>
        /// <param name="checkoutList"></param>
        /// <param name="promotionList"></param>
        /// <returns></returns>
        public Offer ApplyPromotions(List<Checkout> checkoutList, List<Promotion> promotionList)
        {
            Offer offer = new ();
            
            List<IPromotionAlgorithm> strategies = new ();
            strategies.Add(new AdditionalItemOfferPromotion());
            strategies.Add(new ComboOfferPromotion());

            try
            {
                foreach (Checkout item in checkoutList)
                {
                    if (item.Quantity > 0)
                    {
                        foreach (var strategy in strategies)
                        {
                            if (strategy.CanExecute(item, promotionList))
                            {
                                item.HasOffer = true;
                                item.FinalPrice = strategy.CalculateProductPrice(checkoutList);
                                offer.TotalPrice += item.FinalPrice;
                                break;
                            }
                        }
                    }
                }
                offer.Checkouts = checkoutList;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return offer;
        }
    }
}
