using Checkout.Core.DTO;
using System.Linq;

namespace Checkout.Core.Catalogue
{
	public class PricingCatalogue : IPricingCatalogue
	{
		private readonly Dictionary<string, PricingPolicy> _policies = new();

		public PricingCatalogue(params PricingPolicy[] policies)
		{
			foreach (var policy in policies)
			{
				_policies.Add(policy.SKU, policy);
			}
		}

		public PricingPolicy GetPricingPolicy(string sku) => _policies[sku];
	}
}
