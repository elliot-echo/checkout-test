using Checkout.Core.DTO;
using System.Linq;

namespace Checkout.Core.Catalogue
{
	public class PricingCatalogue : IPricingCatalogue
	{
		private readonly Dictionary<string, PricingPolicy> _policies = new(StringComparer.OrdinalIgnoreCase);

		public PricingCatalogue(params PricingPolicy[] policies)
		{
			foreach (var policy in policies)
			{
				_policies.Add(policy.SKU, policy);
			}
		}

		public PricingPolicy GetPricingPolicy(string sku)
		{
			if (!_policies.TryGetValue(sku, out var policy))
			{
				throw new KeyNotFoundException($"The provided SKU \'{sku}\' has no registered Pricing Policy");
			}

			return policy;
		}
	}
}
