using System.Collections.Generic;

namespace MobileGameShop
{
	public class ShopSectionVM
	{
		public object GO;

		public string SectionId;

		public string Title;

		public ShopSectionLayout Layout;

		public List<ShopOfferVM> Offers;

		public ShopSectionSO Source;

		public bool _shouldShowSectionTitle;
	}
}
