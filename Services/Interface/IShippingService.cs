using System;
namespace study.Services.Interface
{
	public interface IShippingService
	{
        CheckoutModel getShipping(CheckoutModel model);
    }
}

