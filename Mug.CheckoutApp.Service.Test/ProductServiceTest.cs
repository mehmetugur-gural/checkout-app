using System.Linq;
using Xunit;
using FluentAssertions;

namespace Mug.CheckoutApp.Service.Test
{
    /// <summary>
    /// Tests for ProductService class.
    /// TODO : In ideal objects should be mocked and injected through the mock objects. Also these are regular unit tests with small coverage, for ensuring full code coverage these tests should be written with tdd.
    /// </summary>
    public class ProductServiceTest
    {
        [Fact]
        public void ProductsShouldBePopulated()
        {
            //Arrange
            var productService = new ProductService();
            
            //Act
            var productList = productService.PopulateProductCartItems();
            
            //Assert
            productList.Should().NotBeEmpty();
        }
        
        [Fact]
        public void ProductsIdsShouldBeUnique()
        {
            //Arrange
            var productService = new ProductService();
            
            //Act
            var productList = productService.PopulateProductCartItems();
            
            //Assert
            productList.Should().OnlyHaveUniqueItems(x => x.Id);
        }
        
        [Fact]
        public void FirstProductShouldHaveEligibleForDiscount()
        {
            //Arrange
            var productService = new ProductService();
            
            //Act
            var product = productService.PopulateProductCartItems().FirstOrDefault();
            
            //Assert
            product.ProductDiscountOffer.Should().NotBeNull();
        }
    }
}