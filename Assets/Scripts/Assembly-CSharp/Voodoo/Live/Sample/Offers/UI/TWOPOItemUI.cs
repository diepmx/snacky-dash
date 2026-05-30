using System;
using TMPro;
using UnityEngine;

namespace Voodoo.Live.Sample.Offers.UI
{
	public class TWOPOItemUI : MonoBehaviour
	{
		[Header("Prefabs")]
		[SerializeField]
		private OfferPopupItemUI _offerPopupItemUIPrefab;

		[Header("References")]
		[SerializeField]
		private Transform _itemsContainer;

		[SerializeField]
		private TextMeshProUGUI _titleTXT;

		[SerializeField]
		private OfferPurchaseBtnUI _purchaseBtnUI;

		public string offerId;

		public void Setup(Product product, Action onPurchase)
		{
		}
	}
}
