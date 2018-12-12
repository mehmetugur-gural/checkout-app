using Mug.CheckoutApp.Data;

namespace Mug.CheckoutApp.Strategy
{
    /// <summary>
    /// Calculation strategy for 3 for the price of 2 offer.
    /// TODO : Should offer redeem for once or multiple times ? (3 - 6 - 9)
    /// </summary>
    public class ThreeForTwoDiscountStrategy : IDiscount
    {
        public decimal CalculateDiscountPrice(ProductCartItem cartItem)
        {
            return cartItem.CartCount >= 3 ? 
                (cartItem.CartCount - 1) * cartItem.ProductPrice : 
                (cartItem.CartCount * cartItem.ProductPrice);
        }
    }
}