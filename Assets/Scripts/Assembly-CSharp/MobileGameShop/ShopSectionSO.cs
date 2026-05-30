using System.Collections.Generic;
using UnityEngine;

namespace MobileGameShop
{
	[CreateAssetMenu(menuName = "MobileGameShop/Shop Section", fileName = "ShopSection")]
	public class ShopSectionSO : ScriptableObject
	{
		[Header("Identity")]
		public string sectionId;

		[Header("UI")]
		public string title;

		public ShopSectionLayout layout;

		[Header("Offers")]
		public List<ShopOfferSO> offers;

		public bool shouldShowSectionTitle;
	}
}
