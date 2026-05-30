using System.Collections.Generic;
using Voodoo.Live;

namespace JuicedUp.Features.Shop.Internal.Loaders
{
	internal interface IVoodooTuneShopLoader
	{
		IEnumerable<ProductDTO> LoadShopSection(string shopSectionName);
	}
}
