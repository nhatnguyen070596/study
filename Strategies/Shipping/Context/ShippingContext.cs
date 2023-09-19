using System;
using study.Repositories.Interface;
using study.Strategies.Shipping.Interface;

namespace study.Strategies.Shipping.Context
{
	public class ShippingContext : IShippingContext
    {
        private IShippingStrategy _strategy;
        public ShippingContext()
		{

		}
        public ShippingContext(IShippingStrategy strategy)
        {
            this._strategy = strategy;
        }

        public void SetStrategy(IShippingStrategy strategy)
        {
            this._strategy = strategy;
        }

        public decimal ExecuteStrategy(decimal orderTotal)
        {
            return this._strategy.CalculateFinalTotal(orderTotal);
        }

        public ShippingMethod GetMethodStratergy(int method)
        {
            return this._strategy.GetMethodShipping(method);
        }
    }
}

