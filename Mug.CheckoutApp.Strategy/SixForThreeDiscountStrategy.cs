using Mug.CheckoutApp.Data;

namespace Mug.CheckoutApp.Strategy
{
    /// <summary>
    /// Calculation strategy for 6 for the price of 3 offer.
    /// TODO : Should offer redeem for once or multiple times ? (6 - 12 - 18)
    /// </summary>
    public class SixForThreeDiscountStrategy : IDiscount
    {
        public decimal CalculateDiscountPrice(ProductCartItem cartItem)
        {
            return cartItem.CartCount >= 6 ? 
                (cartItem.CartCount - 3) * cartItem.ProductPrice : 
                (cartItem.CartCount * cartItem.ProductPrice);
        }
    }
}