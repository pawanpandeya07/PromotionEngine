using MK.PromotionEngine.BusinessLayer;
using System;

namespace MK.PromotionEngine
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                RequiredTasks task = new();
                //Gets the required input for the quantity of Products
                task.CheckoutProducts();
                // Apply Promotions to the product
                task.ApplyPromotion();
                //Display o/p 
                task.DisplayTotalPrice();
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
