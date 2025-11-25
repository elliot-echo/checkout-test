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
				throw new ArgumentNullException(nameof(sku));
			}

			if (unitPrice < 0)
			{
				throw new ArgumentOutOfRangeException(nameof(unitPrice), "Negative unit prices not permitted");
			}

			ArgumentNullException.ThrowIfNull(strategy);

			SKU = sku;
			UnitPrice = unitPrice;
			Strategy = strategy;
		}
	}
}
