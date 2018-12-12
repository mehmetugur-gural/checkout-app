using Mug.CheckoutApp.Data;

namespace Mug.CheckoutApp.Strategy
{
    public interface IDiscount
    {
        decimal CalculateDiscountPrice(ProductCartItem cartItem);
    }
}
