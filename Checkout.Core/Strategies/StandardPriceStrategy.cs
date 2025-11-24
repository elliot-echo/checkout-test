namespace Checkout.Core.Strategies
{
	public class StandardPriceStrategy : IPricingStrategy
	{
		public int GetTotal(int quantity, int unitPrice) => quantity * unitPrice;
	}
}
