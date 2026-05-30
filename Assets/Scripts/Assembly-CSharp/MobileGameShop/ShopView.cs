using System.Collections.Generic;
using UnityEngine;

namespace MobileGameShop
{
	public class ShopView : MonoBehaviour
	{
		[Header("Root")]
		public Transform contentRoot;

		[Header("Prefabs")]
		public ShopSectionView sectionPrefab;

		[Header("Optional")]
		public GameObject restoreButtonRoot;

		private readonly List<GameObject> _spawned;

		public void Render(List<ShopSectionVM> sections, ShopPresenter presenter)
		{
		}

		private void Clear()
		{
		}
	}
}
