namespace Checkout.Core.Strategies
{
	public class StandardPriceStrategy : IPricingStrategy
	{
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

			return quantity * unitPrice;
		}
	}
}
