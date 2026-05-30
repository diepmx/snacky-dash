using System.Collections.Generic;

namespace JuicedUp.Common.Economy.Public.Data
{
	public interface IProduct
	{
		IBundle Bundle { get; }

		string ProductId { get; }

		List<string> Tags { get; }
	}
}
