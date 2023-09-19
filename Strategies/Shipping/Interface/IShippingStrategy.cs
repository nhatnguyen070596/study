namespace study.Strategies.Shipping.Interface
{
    public interface IShippingStrategy
    {
        decimal CalculateFinalTotal(decimal orderTotal);

        ShippingMethod GetMethodShipping(int method);
    }
}