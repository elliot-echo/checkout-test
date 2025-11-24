using System;
using Checkout.Core.Catalogue;
using Checkout.Core.Interfaces;

namespace Checkout.Core.Services
{
	public class CheckoutService : ICheckout
	{
		private readonly Dictionary<string, int> _basket = new(StringComparer.OrdinalIgnoreCase);

		private readonly IPricingCatalogue _pricingCatalogue;

		public CheckoutService(IPricingCatalogue pricingCatalogue)
		{
			_pricingCatalogue = pricingCatalogue;
		}

		public void Scan(string item)
		{
			if (!_basket.ContainsKey(item))
			{
				_basket.Add(item, 1);
			}
			else
			{
				_basket[item]++;
			}
		}

		public int GetTotalPrice()
		{
			var total = 0;

			foreach (var item in _basket)
			{
				var policy = _pricingCatalogue.GetPricingPolicy(item.Key);
				total += policy.Strategy.GetTotal(item.Value, policy.UnitPrice);
			}

			return total;
		}
	}
}
