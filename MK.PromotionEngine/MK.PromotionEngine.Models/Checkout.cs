using System.Diagnostics.CodeAnalysis;

namespace MK.PromotionEngine.Models
{
    [ExcludeFromCodeCoverage]
    public class Checkout
    {
        /// <summary>
        /// ProductCode
        /// </summary>
        public string ProductCode { get; set; }
        /// <summary>
        /// Quantity
        /// </summary>
        public int Quantity { get; set; }
        /// <summary>
        /// FinalPrice
        /// </summary>
        public double FinalPrice { get; set; }
        /// <summary>
        /// DefaultPrice
        /// </summary>
        public double DefaultPrice { get; set; }
        /// <summary>
        /// HasOffer
        /// </summary>
        public bool HasOffer { get; set; }
        /// <summary>
        /// IsValidated
        /// </summary>
        public bool IsValidated { get; set; }
    }
}
