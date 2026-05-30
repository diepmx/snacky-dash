using System;
using System.Collections.Generic;
using UnityEngine;

namespace MobileGameShop
{
	[CreateAssetMenu(menuName = "MobileGameShop/Grant Visual Catalog", fileName = "GrantVisualCatalog")]
	public class GrantVisualCatalogSO : ScriptableObject
	{
		[Serializable]
		public class Entry
		{
			public GrantType type;

			[Tooltip("Optional: used for Item (itemId), TimedBoost (boostKey), Entitlement (entitlementKey). Leave empty for enum-only types (Coins, Booster_*).")]
			public string id;

			public Sprite icon;

			public Sprite bgIcon;

			[Tooltip("Optional: UI label override (e.g. \"Coins\", \"No Ads\").")]
			public string label;
		}

		public List<Entry> entries;

		private Dictionary<(GrantType, string), Entry> _cache;

		private void OnEnable()
		{
		}

		private void OnValidate()
		{
		}

		private void BuildCache()
		{
		}

		public bool TryGet(GrantType type, string id, out Entry entry)
		{
			entry = null;
			return false;
		}
	}
}
