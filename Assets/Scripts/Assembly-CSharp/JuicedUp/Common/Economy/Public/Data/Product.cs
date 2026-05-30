using System.Collections.Generic;

namespace JuicedUp.Common.Economy.Public.Data
{
	public class Product : IProduct
	{
		public IBundle Bundle { get; }

		public string ProductId { get; }

		public List<string> Tags { get; }

		public Product(IBundle bundle, string productId, List<string> tags)
		{
		}
	}
}
