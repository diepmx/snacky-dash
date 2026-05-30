using System.Collections.Generic;
using UnityEngine;

namespace MobileGameShop
{
	[CreateAssetMenu(menuName = "MobileGameShop/Shop Catalog", fileName = "ShopCatalog")]
	public class ShopCatalogSO : ScriptableObject
	{
		public List<ShopSectionSO> sections;
	}
}
