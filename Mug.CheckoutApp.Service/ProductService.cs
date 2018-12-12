using System.Collections.Generic;
using Mug.CheckoutApp.Data;

namespace Mug.CheckoutApp.Service
{
    /// <summary>
    /// Populate the products for cart.
    /// TODO : In normal these should be came from db with a repository pattern preferably and should be in its own model.
    /// </summary>
    public class ProductService
    {
        public List<ProductCartItem> PopulateProductCartItems()
        {
            List<ProductCartItem> productList = new List<ProductCartItem>();
            
            ProductCartItem product1 = new ProductCartItem()
            {
                Id = 1,
                ProductName = "Apple",
                ProductTitle = "Troublemaker since Adam & Eve.",
                ProductImage = "apple.jpg",
                ProductPrice = 1,
                ProductDiscountOffer = new DiscountOffer() { Id = 1, DiscountType = DiscountType.ThreeForTwo }
            };
            
            ProductCartItem product2 = new ProductCartItem()
            {
                Id = 2,
                ProductName = "Banana",
                ProductTitle = "Best Fruit in the world after big mac.",
                ProductImage = "banana.jpg",
                ProductPrice = 2,
                ProductDiscountOffer = new DiscountOffer() { Id = 2, DiscountType = DiscountType.SixForThree }
            };
            
            ProductCartItem product3 = new ProductCartItem()
            {
                Id = 3,
                ProductName = "Peach",
                ProductTitle = "This is funny.",
                ProductImage = "peach.png",
                ProductPrice = 3
            };
            
            productList.Add(product1);
            productList.Add(product2);
            productList.Add(product3);

            return productList;
        }
    }
}