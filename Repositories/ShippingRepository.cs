using System;
using study.Repositories.Interface;
using study.Strategies;
using study.Strategies.Shipping;
using study.Strategies.Shipping.Interface;

namespace study.Repositories
{
	public class ShippingRepository : IShippingRepository
	{
        private IShippingContext _shippingContext;

        public ShippingRepository(IShippingContext shippingContext)
		{
            _shippingContext = shippingContext;
		}

        public CheckoutModel getShipping(CheckoutModel model)
        {
            switch (model.SelectedMethod)
            {
                case 1:
                    _shippingContext.SetStrategy(new FreeShippingStrategy());
                    break;
                case 2:
                    _shippingContext.SetStrategy(new LocalShippingStrategy());
                    break;
                case 3:
                    _shippingContext.SetStrategy(new WorldwideShippingStrategy());
                    break;
            }
            model.ShippingMethods = _shippingContext.GetMethodStratergy(model.SelectedMethod);

            model.FinalTotal = _shippingContext.ExecuteStrategy(model.OrderTotal);

            return model;
        }
    }
}

