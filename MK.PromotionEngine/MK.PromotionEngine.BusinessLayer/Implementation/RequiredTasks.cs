using MK.PromotionEngine.EndUserLayer;
using MK.PromotionEngine.Models;
using MK.PromotionEngine.RepositoryLayer;
using System;
using System.Collections.Generic;

namespace MK.PromotionEngine.BusinessLayer
{
    /// <summary>
    /// Abstraction of tasks
    /// </summary>
    public class RequiredTasks
    {
        private readonly IPromotionPresentation promotionPresentation;
        private readonly IPromotionService promotionService;
        private IPromotionRepository promotionRepository;

        List<Checkout> checkoutList;
        Offer offer;

        public RequiredTasks()
        {
            promotionPresentation = new PromotionPresentation();
            promotionService = new PromotionService();
        }
        /// <summary>
        /// CheckoutProducts
        /// </summary>
        /// <returns></returns>
        public bool CheckoutProducts()
        {
            try
            {
                checkoutList = promotionPresentation.GetUserInput();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return false;
        }
        /// <summary>
        /// ApplyPromotion
        /// </summary>
        /// <returns></returns>
        public bool ApplyPromotion()
        {
            try
            {
                offer = promotionService.ApplyPromotions(checkoutList, GetProductOffers());
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return false;
        }
        /// <summary>
        /// GetProductOffers
        /// </summary>
        /// <returns></returns>
        public List<Promotion> GetProductOffers()
        {
            try
            {
                promotionRepository = new PromotionRepository();
                return promotionRepository.GetOffers();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return new List<Promotion>();
        }
        /// <summary>
        /// DisplayTotalPrice
        /// </summary>
        /// <returns></returns>
        public bool DisplayTotalPrice()
        {
            try
            {
                if (offer.Checkouts != null)
                {
                    promotionPresentation.GetTotalPrice(offer);
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return false;
        }
        /// <summary>
        /// GetAvailableProducts
        /// </summary>
        /// <returns></returns>
        public List<Product> GetAvailableProducts()
        {
            try
            {
                promotionRepository = new PromotionRepository();
                return promotionRepository.GetProducts();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);                
            }
            return new List<Product>();

        }
    }
}
