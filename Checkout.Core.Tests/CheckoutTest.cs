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

			var checkout = new CheckoutService();
			checkout.Scan("A");

			var total = checkout.GetTotalPrice();

			Assert.True(total == 50);
		}

		[Fact]
		public void GetTotal_EmptyBasket()
		{
			var checkout = new CheckoutService();

			var total = checkout.GetTotalPrice();

			Assert.True(total == 0);
		}
	}
}
