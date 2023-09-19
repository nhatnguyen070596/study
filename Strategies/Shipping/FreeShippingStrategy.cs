using System;
using study.Strategies.Shipping.Interface;

namespace study.Strategies.Shipping
{
	public class FreeShippingStrategy : IShippingStrategy
    {
		public FreeShippingStrategy()
		{
		}

        public decimal CalculateFinalTotal(decimal orderTotal)
        {
            return orderTotal;
        }

        public ShippingMethod GetMethodShipping(int method)
        {
            return new ShippingMethod()
            {
                Id = 1,
                Name = "Free Shipping ($0.00)"
            };
        }
    }
}

