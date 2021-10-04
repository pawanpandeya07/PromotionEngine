using MK.PromotionEngine.Models;
using System.Collections.Generic;

namespace MK.PromotionEngine.RepositoryLayer
{
    public interface IPromotionRepository
    {
        /// <summary>
        /// Get Products
        /// </summary>
        /// <returns>List<Product><see cref="List<Product>"/></returns>
        List<Product> GetProducts();

        /// <summary>
        /// Get Offers on Product
        /// </summary>
        /// <returns>List<Promotion><see cref="List<Promotion>"/></returns>
        List<Promotion> GetOffers();
    }
}
