namespace Mug.CheckoutApp.Data
{
    /// <summary>
    /// Fields for product cart
    /// </summary>
    public class ProductCartItem
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string ProductTitle { get; set; }
        public string ProductImage { get; set; }
        public decimal ProductPrice { get; set; }
        //TODO: In an ideal implementation, this field should not be in here and must have an own dto.
        public decimal ProductDiscountCalculatedPrice { get; set; }
        public DiscountOffer ProductDiscountOffer { get; set; }
        public int CartCount { get; set; }        
    }
}