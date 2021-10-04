using Microsoft.Extensions.Configuration;
using MK.PromotionEngine.Common;
using MK.PromotionEngine.Models;
using System;
using System.Collections.Generic;
using System.IO;

namespace MK.PromotionEngine.RepositoryLayer
{
    public class PromotionRepository : IPromotionRepository
    {
        private readonly IConfiguration configuration;
        public PromotionRepository()
        {
            try
            {
                var builder = new ConfigurationBuilder().SetBasePath("C:\\Users\\pawan\\Source\\Repos\\PromotionEngine\\MK.PromotionEngine\\MK.PromotionEngine.RepositoryLayer\\")
                    .AddJsonFile(Constants.DataBase, false);

                configuration = builder.Build();
            }
            
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message); 
            }
        }
        /// <summary>
        /// Get Offers
        /// </summary>
        /// <returns></returns>
        public List<Promotion> GetOffers()
        {
            List<Promotion> promotionList = new ();
            foreach (var item in configuration.GetSection(Constants.Promotions).GetChildren())
            {
                Promotion promotion = new ();
                configuration.GetSection(item.Path).Bind(promotion);
                promotionList.Add(promotion);
            }
            return promotionList;
        }
        /// <summary>
        /// GetProducts
        /// </summary>
        /// <returns></returns>
        public List<Product> GetProducts()
        {
            List<Product> productList = new ();

            foreach (var item in configuration.GetSection(Constants.Products).GetChildren())
            {
                Product product = new ();
                configuration.GetSection(item.Path).Bind(product);
                productList.Add(product);
            }
            return productList;
        }
    }
}
