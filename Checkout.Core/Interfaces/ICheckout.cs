namespace Checkout.Core.Interfaces
{
	public interface ICheckout
	{
		/// <summary>
		/// Identifies and adds <paramref name="item"/> to the current basket
		/// </summary>
		void Scan(string item);

		/// <summary>
		/// Returns the final price of the items in the basket, with price modifiers applied, if any
		/// </summary>
		int GetTotalPrice();
	}
}
