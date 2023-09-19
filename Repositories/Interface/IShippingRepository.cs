using System;
namespace study.Repositories.Interface
{
	public interface IShippingRepository
	{
        CheckoutModel getShipping(CheckoutModel model);
    }
}

