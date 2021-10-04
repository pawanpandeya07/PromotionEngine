using System.Diagnostics.CodeAnalysis;

namespace MK.PromotionEngine.Models
{
    [ExcludeFromCodeCoverage]
    public class Product
    {
        /// <summary>
        /// ProductId
        /// </summary>
        public int ProductId { get; set; }
        /// <summary>
        /// ProductCode
        /// </summary>
        public string ProductCode { get; set; }
        /// <summary>
        /// ProductName
        /// </summary>
        public string ProductName { get; set; }
        /// <summary>
        /// Description
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Price
        /// </summary>
        public double Price { get; set; }
    }
}
