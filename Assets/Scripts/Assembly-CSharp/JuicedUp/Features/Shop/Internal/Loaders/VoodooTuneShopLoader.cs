using System.Collections.Generic;
using Voodoo.Live;
using Voodoo.Live.Shop;

namespace JuicedUp.Features.Shop.Internal.Loaders
{
	internal class VoodooTuneShopLoader : IVoodooTuneShopLoader
	{
		public IEnumerable<ProductDTO> LoadShopSection(string shopSectionName)
		{
			return null;
		}

		private static GameShopDTO TryDeserializeShopPayload(string payload)
		{
			return null;
		}

		private static IEnumerable<ProductDTO> FilterValidProducts(List<ProductDTO> source)
		{
			return null;
		}
	}
}
