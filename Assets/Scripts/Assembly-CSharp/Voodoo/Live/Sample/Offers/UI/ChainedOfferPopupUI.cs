using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Voodoo.Live.Offers;

namespace Voodoo.Live.Sample.Offers.UI
{
	public class ChainedOfferPopupUI : FeaturePopup
	{
		[Header("Prefabs")]
		[SerializeField]
		private OfferGroupItemUI _offerItemPrefab;

		[Header("References")]
		[SerializeField]
		private Transform _offersContainer;

		[SerializeField]
		private GameObject _loadingScreen;

		[SerializeField]
		private Button _closeBtn;

		[SerializeField]
		private TextMeshProUGUI _titleTxt;

		private ChainedOffer _chainedOffer;

		private List<OfferGroupItemUI> _offerItems;

		private OfferGroupItemUI _currentOfferItem;

		public override void Show()
		{
		}

		private void Setup()
		{
		}

		private void PurchaseClicked(Product product)
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
