using System;
using System.Text.Json;
using Confluent.Kafka;
using study.Services.Interface;
using study.Strategies.Shipping;
using study.Strategies.Shipping.Context;
using study.Strategies.Shipping.Interface;

namespace study.Services
{
	public class ShippingService : IShippingService
	{
        private IShippingContext _shippingContext;
        public ShippingService(IShippingContext shippingContext)
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
            LogHelper.Writelog(LogKafka.Topic2Name, JsonSerializer.Serialize(model),LogType.LogInfo);

            return model;
        }
    }
}

