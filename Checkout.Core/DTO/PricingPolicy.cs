using Checkout.Core.Strategies;

namespace Checkout.Core.DTO
{
	public sealed record PricingPolicy
	{
		public string SKU { get; }

		public int UnitPrice { get; }

		public IPricingStrategy Strategy { get; }

		public PricingPolicy(string sku, int unitPrice, IPricingStrategy strategy)
		{
			if (string.IsNullOrWhiteSpace(sku))
			{
				throw new ArgumentNullException("SKU cannot be empty", nameof(sku));
			}

			if (unitPrice < 0)
			{
				throw new ArgumentOutOfRangeException("Negative unit prices not permitted", nameof(unitPrice));
			}

			if (strategy == null)
			{
				throw new ArgumentNullException("Pricing strategy not provided", nameof(strategy));
			}

			SKU = sku;
			UnitPrice = unitPrice;
			Strategy = strategy;
		}
	}
}
