namespace Mug.CheckoutApp.Data
{
    /// <summary>
    /// Discount types for defining discount strategies. For testing purposes, in real life this should be coming from database or configuration.
    /// </summary>
    public enum DiscountType
    {
        ThreeForTwo = 0,
        SixForThree = 1,
        FiftyOff = 2
    }
}