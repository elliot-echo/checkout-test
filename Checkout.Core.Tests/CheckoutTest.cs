using Checkout.Core.Services;

namespace Checkout.Core.Tests
{
	public class CheckoutTest
	{
		[Fact]
		public void GetTotal_SingleItem_NoOffers()
		{
			var checkout = new CheckoutService();
			checkout.Scan("0");

			var total = checkout.GetTotalPrice();

			Assert.True(total > 0);
		}
	}
}
