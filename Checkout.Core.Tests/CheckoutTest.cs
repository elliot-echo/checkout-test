using Checkout.Core.Catalogue;
using Checkout.Core.DTO;
using Checkout.Core.Services;
using Checkout.Core.Strategies;

namespace Checkout.Core.Tests
{
	public class CheckoutTest
	{
		[Fact]
		public void GetTotal_MultipleDifferentItems_OfferCombination_RandomOrder()
		{
			var bundleAPolicy = new PricingPolicy("A", 50, new BundleDiscountStrategy(3, 130));
			var bundleBPolicy = new PricingPolicy("B", 30, new BundleDiscountStrategy(2, 45));

			var standardPrice = new StandardPriceStrategy();
			var singleCPolicy = new PricingPolicy("C", 20, standardPrice);
			var singleDPolicy = new PricingPolicy("D", 15, standardPrice);

			var catalogue = new PricingCatalogue(bundleAPolicy, bundleBPolicy, singleCPolicy, singleDPolicy);

			var checkout = new CheckoutService(catalogue);

			//build the sequence of transactions
			var transactions = new List<Action>();
			//three A's for 130
			transactions.Add(() => checkout.Scan("A"));
			transactions.Add(() => checkout.Scan("A"));
			transactions.Add(() => checkout.Scan("A"));

			//two B's for 45 plus one for 30, 75 in total
			transactions.Add(() => checkout.Scan("B"));
			transactions.Add(() => checkout.Scan("B"));
			transactions.Add(() => checkout.Scan("B"));

			//two C's for 20, 40 in total
			transactions.Add(() => checkout.Scan("C"));
			transactions.Add(() => checkout.Scan("C"));

			//three D'c for 15, 45 in total
			transactions.Add(() => checkout.Scan("D"));
			transactions.Add(() => checkout.Scan("D"));
			transactions.Add(() => checkout.Scan("D"));

			//randomise it
			var rng = new Random();
			for (var i = transactions.Count - 1; i > 0; i--)
			{
				var j = rng.Next(0, i + 1);
				(transactions[i], transactions[j]) = (transactions[j], transactions[i]);
			}

			//execute in random order to test consistency
			transactions.ForEach(t => t());

			var total = checkout.GetTotalPrice();

			Assert.Equal(290, total);
		}

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
			var bundleAPolicy = new PricingPolicy("A", 50, new BundleDiscountStrategy(3, 130));
			var catalogue = new PricingCatalogue(bundleAPolicy);

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

		[Fact]
		public void BuildCatalogue_InvalidStrategy()
		{
			Assert.Throws<ArgumentOutOfRangeException>(() => new BundleDiscountStrategy(-1, 130));
			Assert.Throws<ArgumentOutOfRangeException>(() => new BundleDiscountStrategy(3, 0));

			var strategy = new StandardPriceStrategy();
			Assert.Throws<ArgumentOutOfRangeException>(() => strategy.GetTotal(-1, 5));
			Assert.Throws<ArgumentOutOfRangeException>(() => strategy.GetTotal(1, -1));
		}

		[Fact]
		public void BuildCatalogue_InvalidPolicies()
		{
			var strategy = new BundleDiscountStrategy(3, 130);
			Assert.Throws<ArgumentNullException>(() => new PricingPolicy(null, 50, strategy));
			Assert.Throws<ArgumentOutOfRangeException>(() => new PricingPolicy("A", -1, strategy));
			Assert.Throws<ArgumentNullException>(() => new PricingPolicy("A", 50, null!));
		}
	}
}
