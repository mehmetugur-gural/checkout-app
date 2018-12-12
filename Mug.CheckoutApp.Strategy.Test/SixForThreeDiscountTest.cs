using Xunit;
using FluentAssertions;
using Mug.CheckoutApp.Data;

namespace Mug.CheckoutApp.Strategy.Test
{
    /// <summary>
    /// Tests for SixForThreeDiscountStrategy class.
    /// TODO : In ideal objects should be mocked and injected through the mock objects. Also these are regular unit tests with small coverage, for ensuring full code coverage these tests should be written with tdd.
    /// </summary>
    public class SixForThreeDiscountTest
    {
        [Fact]
        public void ProductEligibleForSixForThreeWhenCartCountIsSix()
        {
            //Arrange
            ProductCartItem product = new ProductCartItem()
            {
                Id = 2,
                ProductName = "Banana",
                ProductTitle = "Best Fruit in the world after big mac.",
                ProductImage = "banana.jpg",
                ProductPrice = 2,
                CartCount = 6,
                ProductDiscountOffer = new DiscountOffer() { Id = 2, DiscountType = DiscountType.SixForThree }
            };
            
            var sixForThreeStrategy = new SixForThreeDiscountStrategy();
            
            //Act
            var calculatedPrice = sixForThreeStrategy.CalculateDiscountPrice(product);
            
            //Assert
            calculatedPrice.Should().Be(6);
        }
    }
}