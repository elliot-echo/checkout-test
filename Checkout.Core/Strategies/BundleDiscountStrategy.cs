using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkout.Core.Strategies
{
	public class BundleDiscountStrategy : IPricingStrategy
	{
		public int GetTotal(int quantity, int unitPrice) => quantity * unitPrice;
	}
}
