using System.Collections.Generic;

namespace Voodoo.Live
{
	public sealed class PriceDTO
	{
		public string type;

		public string appleProductId;

		public string androidProductId;

		public string productId;

		public string currencyType;

		public float amount;

		public List<string> tags;

		public string FinalProductId => null;

		public bool IsValid => false;

		public IPrice Consume()
		{
			return null;
		}
	}
}
