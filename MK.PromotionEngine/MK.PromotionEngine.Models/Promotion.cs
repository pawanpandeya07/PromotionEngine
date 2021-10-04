using System.Diagnostics.CodeAnalysis;

namespace MK.PromotionEngine.Models
{
    [ExcludeFromCodeCoverage]
    public class Promotion
    {
        /// <summary>
        /// PromotionId
        /// </summary>
        public int PromotionId { get; set; }
        /// <summary>
        /// Quantity
        /// </summary>
        public int Quantity { get; set; }
        /// <summary>
        /// Type 
        /// </summary>
        public string Type { get; set; }
        /// <summary>
        /// ProductCode
        /// </summary>
        public string ProductCode { get; set; }
        /// <summary>
        /// Price
        /// </summary>
        public double Price { get; set; }
    }
}
