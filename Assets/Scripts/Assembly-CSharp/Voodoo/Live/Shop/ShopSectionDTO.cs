using System;
using System.Collections.Generic;

namespace Voodoo.Live.Shop
{
	[Serializable]
	public class ShopSectionDTO
	{
		public string id;

		public string name;

		public List<ProductDTO> purchasable;

		public bool IsValid => false;
	}
}
