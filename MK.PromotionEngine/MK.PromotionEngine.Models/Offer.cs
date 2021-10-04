using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace MK.PromotionEngine.Models
{
    [ExcludeFromCodeCoverage]
    public class Offer
    {
        /// <summary>
        /// Checkouts
        /// </summary>
        public List<Checkout> Checkouts { get; set; }
        /// <summary>
        /// TotalPrice
        /// </summary>
        public double TotalPrice { get; set; }
    }
}
