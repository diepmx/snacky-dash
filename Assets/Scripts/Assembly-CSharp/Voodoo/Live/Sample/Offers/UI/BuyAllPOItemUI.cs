using System;
using UnityEngine;
using Voodoo.Live.Offers;

namespace Voodoo.Live.Sample.Offers.UI
{
	public class BuyAllPOItemUI : MonoBehaviour
	{
		[Header("Prefabs")]
		[SerializeField]
		private OfferPopupItemUI _offerPopupItemUIPrefab;

		[Header("References")]
		[SerializeField]
		private Transform _itemsContainer;

		[SerializeField]
		private OfferPurchaseBtnUI _purchaseBtnUI;

		public string offerId;

		public void Setup(BuyAllFeatureGroup buyallOffer, Action onPurchase)
		{
		}
	}
}
