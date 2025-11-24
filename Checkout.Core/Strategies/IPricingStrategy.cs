namespace Checkout.Core.Strategies
{
	/// <summary>
	/// Behaviour for calculating the total price of the given quantity of a product
	/// </summary>
	public interface IPricingStrategy
	{
		int GetTotal(int quantity, int unitPrice);
	}
}
