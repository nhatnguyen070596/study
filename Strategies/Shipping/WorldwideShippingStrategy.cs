using System;
using study.Strategies.Shipping.Interface;

namespace study.Strategies.Shipping
{
	public class WorldwideShippingStrategy : IShippingStrategy
    {
		public WorldwideShippingStrategy()
		{
		}

        public decimal CalculateFinalTotal(decimal orderTotal)
        {
            return orderTotal + 50;
        }

        public ShippingMethod GetMethodShipping(int method)
        {
            return new ShippingMethod()
            {
                Id = 3,
                    Name = "Worldwide Shipping ($50.00)"
            };
        }
    }
}

