using System.Collections.Generic;

namespace Voodoo.Live.Shop
{
	public class ShopSection
	{
		public int sectionIndex;

		public List<ShopProduct> products;

		public readonly string id;

		public readonly string name;

		public ShopSection(ShopSectionDTO dataTransferObject, int index, List<ShopProduct> shopProducts)
		{
		}
	}
}
