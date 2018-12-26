using FluentAssertions;
using Mug.CheckoutApp.Data;
using Xunit;

namespace Mug.CheckoutApp.Strategy.Test
{
    /// <summary>
    /// Tests for ThreeForTwoDiscountStrategy class.
    /// TODO : In ideal objects should be mocked and injected through the mock objects. Also these are regular unit tests with small coverage, for ensuring full code coverage these tests should be written with tdd.
    /// </summary>
    public class ThreeForTwoDiscountTest
    {
        [Fact]
        public void ProductEligibleForThreeForTwoWhenCartCountIsThree()
        {
            //Arrange
            ProductCartItem product = new ProductCartItem()
            {
                Id = 1,
                ProductName = "Apple",
                ProductTitle = "Troublemaker since Adam & Eve.",
                ProductImage = "apple.jpg",
                ProductPrice = 1,
                CartCount = 3,
                ProductDiscountOffer = new DiscountOffer() { Id = 1, DiscountType = DiscountType.ThreeForTwo }
            };
            
            var threeForTwoStrategy = new ThreeForTwoDiscountStrategy();
            
            //Act
            var calculatedPrice = threeForTwoStrategy.CalculateDiscountPrice(product);
            
            //Assert
            calculatedPrice.Should().Be(2);
        }
    }
}