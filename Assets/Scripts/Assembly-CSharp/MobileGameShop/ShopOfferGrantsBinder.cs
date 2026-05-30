using System.Collections.Generic;
using UnityEngine;

namespace MobileGameShop
{
	public class ShopOfferGrantsBinder : MonoBehaviour
	{
		[Header("References")]
		public Transform grantsRoot;

		public GrantPillView grantPillPrefab;

		[Header("Data")]
		public GrantVisualCatalogSO visuals;

		[Header("Options")]
		public bool showEntitlements;

		public int maxGrants;

		private readonly List<GameObject> _spawned;

		public void Bind(ShopOfferSO offer)
		{
		}

		public void Clear()
		{
		}
	}
}
