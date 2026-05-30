using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Voodoo.Live.Offers;

namespace Voodoo.Live.Sample.Offers.UI
{
	public class TwoThreePOPopupUI : FeaturePopup
	{
		[Header("Prefabs")]
		[SerializeField]
		private TWOPOItemUI _twoPOItemUIPrefab;

		[SerializeField]
		private BuyAllPOItemUI _buyAllPOItemUIPrefab;

		[Header("References")]
		[SerializeField]
		private GameObject _loadingScreen;

		[SerializeField]
		private Transform _itemsContainer;

		[SerializeField]
		private Button _closeBtn;

		private BuyAllFeatureGroup _groupOffer;

		private List<TWOPOItemUI> _twoItems;

		public override void Show()
		{
		}

		private void Setup(IFeature offer)
		{
		}

		private void InitFeatures()
		{
		}

		private void InitBuyAll()
		{
		}

		private void PurchaseClicked(Product product)
		{
		}

		private void PurchaseAllClicked()
		{
		}

		private void DisplayLoadingScreen(bool display)
		{
		}

		public override void Hide()
		{
		}

		public override void OnStatusChanged(string status, IFeature feature)
		{
		}
	}
}
