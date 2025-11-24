using Checkout.Core.DTO;

namespace Checkout.Core.Catalogue
{
	/// <summary>
	/// Container of <see cref="PricingPolicy"/>
	/// </summary>
	public interface IPricingCatalogue
	{
		/// <summary>
		/// Lookup method for obtaining a valid <see cref="PricingPolicy"/> for a product
		/// </summary>
		PricingPolicy GetPricingPolicy(string sku);
	}
}
