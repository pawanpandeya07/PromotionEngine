using MK.PromotionEngine.Models;
using MK.PromotionEngine.RepositoryLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MK.PromotionEngine.EndUserLayer
{
    public class PromotionPresentation : IPromotionPresentation
    {
        readonly PromotionRepository promotionRepository;
        public PromotionPresentation()
        {
            promotionRepository = new PromotionRepository();
        }
        /// <summary>
        /// GetTotalPrice
        /// </summary>
        /// <param name="offer"></param>
        /// <returns></returns>
        public bool GetTotalPrice(Offer offer)
        {
            Console.WriteLine("Final Price..........................");
            Console.WriteLine("Code" + "-" + "Quantity" + " - " + "FinalPrice" + " - " + "HasOffer");
            foreach (var item in offer.Checkouts)
            {
                Console.WriteLine(item.ProductCode + "       " + item.Quantity + "        " + item.FinalPrice + "           " + item.HasOffer);
            }
            Console.WriteLine("Total Price : " + offer.TotalPrice);
            return true;
        }
        /// <summary>
        /// GetUserInput
        /// </summary>
        /// <returns></returns>
        public List<Checkout> GetUserInput()
        {
            List<Checkout> checkoutList = new();
            List<Product> productList = GetProducts();

            Console.WriteLine("Inputs");
            try
            {
                foreach (var item in productList)
                {
                    Console.WriteLine("Input quantity of " + item.ProductCode);
                    int quantity = Convert.ToInt32(Console.ReadLine());

                    checkoutList.Add(new Checkout()
                    {
                        ProductCode = item.ProductCode,
                        Quantity = quantity,
                        DefaultPrice = item.Price
                    });
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine("Error in User Entry: " + ex.Message);
            }
            return checkoutList;
        }
        
        #region Private Methods

        /// <summary>
        /// Get All Products
        /// </summary>
        /// <returns>List<Product></returns>
        private List<Product> GetProducts()
        {
            return promotionRepository.GetProducts();
        }
        #endregion
    }
}
