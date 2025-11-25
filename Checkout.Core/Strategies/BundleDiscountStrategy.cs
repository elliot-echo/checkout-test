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
				throw new ArgumentOutOfRangeException(nameof(quantity), "Qualifying quantity cannot be less than 2");
			}

			if (price <= 0)
			{
				throw new ArgumentOutOfRangeException(nameof(price), "Total price cannot be less than 1");
			}

			_qualifyingQuantity = quantity;
			_totalPrice = price;
		}

		public int GetTotal(int quantity, int unitPrice)
		{
			if (quantity < 0)
			{
				throw new ArgumentOutOfRangeException(nameof(quantity), "Qualifying quantity cannot be negative");
			}

			if (unitPrice < 0)
			{
				throw new ArgumentOutOfRangeException(nameof(unitPrice), "Total price cannot be negative");
			}

			var bundles = quantity / _qualifyingQuantity;
			var remainder = quantity % _qualifyingQuantity;

			return _totalPrice * bundles + remainder * unitPrice;
		}
	}
}
