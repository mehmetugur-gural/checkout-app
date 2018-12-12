using System.Collections.Generic;
using Mug.CheckoutApp.Data;
using Mug.CheckoutApp.Strategy;

namespace Mug.CheckoutApp.Service
{
    /// <summary>
    /// Main calculation logic service for product cart items.
    /// TODO : This logic needs injection to strategies layer to decouple dependencies.
    /// </summary>
    public class DiscountCalculationService
    {
        /// <summary>
        /// Discount calculator operation for cart items.
        /// </summary>
        /// <param name="cartItemList">Items in cart</param>
        /// <returns>A new list of <see cref="ProductCartItem"/></returns>
        public List<ProductCartItem> CalculateDiscountsForProducts(List<ProductCartItem> cartItemList)
        {
            List<ProductCartItem> discountCalculatedProductList = new List<ProductCartItem>();
            
            foreach (var cartItem in cartItemList)
            {
                if (cartItem.ProductDiscountOffer != null)
                {
                    //TODO : Should be done with reflection to prevent modifying in every discount type.
                    switch (cartItem.ProductDiscountOffer.DiscountType)
                    {
                        case DiscountType.ThreeForTwo:
                            cartItem.ProductDiscountCalculatedPrice = new ThreeForTwoDiscountStrategy().CalculateDiscountPrice(cartItem);
                            break;
                        case DiscountType.SixForThree:
                            cartItem.ProductDiscountCalculatedPrice = new SixForThreeDiscountStrategy().CalculateDiscountPrice(cartItem);
                            break;
                    }
                }
                else
                {
                    cartItem.ProductDiscountCalculatedPrice = (cartItem.ProductPrice * cartItem.CartCount);
                }
                
                discountCalculatedProductList.Add(cartItem);
            }

            return discountCalculatedProductList;
        }
    }
}