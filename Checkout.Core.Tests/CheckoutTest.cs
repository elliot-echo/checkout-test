using Checkout.Core.Catalogue;
using Checkout.Core.DTO;
using Checkout.Core.Services;
using Checkout.Core.Strategies;

namespace Checkout.Core.Tests
{
	public class CheckoutTest
	{
		[Fact]
		public void GetTotal_SingleItem_NoOffers()
		{
			var plainAPolicy = new PricingPolicy("A", 50, new StandardPriceStrategy());
			var catalogue = new PricingCatalogue(plainAPolicy);

			var checkout = new CheckoutService(catalogue);
			checkout.Scan("A");

			var total = checkout.GetTotalPrice();

			Assert.Equal(50, total);
		}

		[Fact]
		public void GetTotal_MultipleIdenticalItems_BundleOffer()
		{
			var plainAPolicy = new PricingPolicy("A", 50, new BundleDiscountStrategy(3, 130));
			var catalogue = new PricingCatalogue(plainAPolicy);

			var checkout = new CheckoutService(catalogue);
			checkout.Scan("A");
			checkout.Scan("A");
			checkout.Scan("A");

			var total = checkout.GetTotalPrice();

			Assert.Equal(130, total);
		}

		[Fact]
		public void GetTotal_EmptyBasket()
		{
			var catalogue = new PricingCatalogue();
			var checkout = new CheckoutService(catalogue);

			var total = checkout.GetTotalPrice();

			Assert.Equal(0, total);
		}
	}
}
