using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkout.Core.Strategies
{
	public class BundleDiscountStrategy : IPricingStrategy
	{
		private readonly int _qualifyingQuantity,
			_totalPrice;

		/// <param name="quantity">The amount of products need to qualify for the total <paramref name="price"/></param>
		/// <param name="price">The total price when <paramref name="quantity"/> requirement is met</param>
		public BundleDiscountStrategy(int quantity, int price)
		{
			if (quantity < 2)
			{
				throw new ArgumentOutOfRangeException("Qualifying quantity cannot be less than 2", nameof(quantity));
			}

			if (price <= 0)
			{
				throw new ArgumentOutOfRangeException("Total price cannot be less than 1", nameof(price));
			}

			_qualifyingQuantity = quantity;
			_totalPrice = price;
		}

		public int GetTotal(int quantity, int unitPrice)
		{
			if (quantity < 0)
			{
				throw new ArgumentOutOfRangeException("Qualifying quantity cannot be negative", nameof(quantity));
			}

			if (unitPrice < 0)
			{
				throw new ArgumentOutOfRangeException("Total price cannot be negative", nameof(unitPrice));
			}

			var bundles = quantity / _qualifyingQuantity;
			var remainder = quantity % _qualifyingQuantity;

			return _totalPrice * bundles + remainder * unitPrice;
		}
	}
}
