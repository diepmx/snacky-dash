using System.Collections.Generic;
using JuicedUp.Common.Economy.Public.Data;

namespace JuicedUp.Common.Economy.Public
{
	public interface IProductsProvider
	{
		IEnumerable<IProduct> GetAll();
	}
}
