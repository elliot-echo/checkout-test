using System;
using System.Collections.Generic;
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
			_qualifyingQuantity = quantity;
			_totalPrice = price;
		}

		public int GetTotal(int quantity, int unitPrice)
		{
			var bundles = quantity / _qualifyingQuantity;
			var remainder = quantity % _qualifyingQuantity;

			return _totalPrice * bundles + remainder * unitPrice;
		}
	}
}
