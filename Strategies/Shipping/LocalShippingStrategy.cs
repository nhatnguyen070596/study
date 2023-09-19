using System;
using study.Repositories.Interface;
using study.Strategies.Shipping.Interface;

namespace study.Strategies.Shipping
{
	public class LocalShippingStrategy : IShippingStrategy
    {
		public LocalShippingStrategy()
		{
		}
        public decimal CalculateFinalTotal(decimal orderTotal)
        {
            return orderTotal + 10;
        }

        public ShippingMethod GetMethodShipping(int method)
        {
            return new ShippingMethod()
            {
                Id = 2,
                Name = "Local Shipping ($10.00)"
            };
        }
    }
}

