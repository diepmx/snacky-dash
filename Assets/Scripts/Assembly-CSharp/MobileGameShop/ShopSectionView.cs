using TMPro;
using UnityEngine;

namespace MobileGameShop
{
	public class ShopSectionView : MonoBehaviour
	{
		[Header("UI")]
		public TextMeshProUGUI titleText;

		[Header("Layouts")]
		public GameObject bannerRoot;

		public GameObject listRoot;

		public GameObject gridRoot;

		[Header("Containers")]
		public Transform bannerContainer;

		public Transform listContainer;

		public Transform gridContainer;

		[Header("Offer Prefabs")]
		public ShopOfferTile offerTilePrefab_banner;

		public ShopOfferTile offerTilePrefab_square;

		public ShopOfferTile offerTilePrefab_banner_No_Ads;

		public GameObject sectionPanel;

		public void Bind(ShopSectionVM vm, ShopPresenter presenter)
		{
		}

		private void SetLayout(ShopSectionLayout layout)
		{
		}

		private Transform GetContainer(ShopSectionLayout layout)
		{
			return null;
		}
	}
}
