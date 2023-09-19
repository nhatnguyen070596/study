using System;
namespace study.Models
{
	public class CheckoutModel
	{
        public int SelectedMethod { get; set; }
        public decimal OrderTotal { get; set; }
        public decimal FinalTotal { get; set; }

        public ShippingMethod? ShippingMethods { get; set; }
    }

    public class ShippingMethod
    {
        public int Id { get; set; }
        public string? Name { get; set; }
    }
}

