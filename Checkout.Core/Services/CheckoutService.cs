using System;
using Checkout.Core.Interfaces;

namespace Checkout.Core.Services
{
	public class CheckoutService : ICheckout
	{
		private readonly Dictionary<string, int> _basket = new(StringComparer.OrdinalIgnoreCase);

		public void Scan(string item)
		{
			if (!_basket.ContainsKey(item))
			{
				_basket.Add(item, 1);
			}
			else
			{
				_basket[item]++;
			}
		}

		public int GetTotalPrice() => _basket.Values.Sum();//since the price is an integer, the min price of an item is bound to be 1; then the most naive execution without knowing prices is to return the total quantity
	}
}
