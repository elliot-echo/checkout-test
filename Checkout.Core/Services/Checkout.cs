using Checkout.Core.Interfaces;

namespace Checkout.Core
{
	public class Checkout : ICheckout
	{
		public void Scan(string item) { }

		public int GetTotalPrice() => 0;
	}
}
