namespace Checkout.Core.Strategies
{
	public class StandardPriceStrategy : IPricingStrategy
	{
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

			return quantity * unitPrice;
		}
	}
}
