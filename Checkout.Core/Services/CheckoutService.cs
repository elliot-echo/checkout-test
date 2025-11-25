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
			_pricingCatalogue = pricingCatalogue
				?? throw new ArgumentNullException(nameof(pricingCatalogue));
		}

		public void Scan(string item)
		{
			if (string.IsNullOrWhiteSpace(item))
			{
				throw new ArgumentNullException(nameof(item));
			}

			_basket[item] = _basket.TryGetValue(item, out var quantity) ? quantity + 1 : 1;
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
