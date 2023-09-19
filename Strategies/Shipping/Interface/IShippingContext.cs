using System;
using study.Repositories.Interface;

namespace study.Strategies.Shipping.Interface
{
	public interface  IShippingContext
	{
        void SetStrategy(IShippingStrategy strategy);

        decimal ExecuteStrategy(decimal orderTotal);

        ShippingMethod GetMethodStratergy(int method);
    }
}

