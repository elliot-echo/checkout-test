using Checkout.Core.Interfaces;

namespace Checkout.Core.Services
{
	public class Checkout : ICheckout
	{
		public void Scan(string item) { }

		public int GetTotalPrice() => 0;
	}
}
