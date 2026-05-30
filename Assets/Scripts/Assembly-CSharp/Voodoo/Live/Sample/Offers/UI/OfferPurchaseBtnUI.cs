using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Voodoo.Live.Sample.Offers.UI
{
	public class OfferPurchaseBtnUI : MonoBehaviour
	{
		[Header("References")]
		[SerializeField]
		private TextMeshProUGUI _priceTxt;

		[SerializeField]
		private TextMeshProUGUI _oldPriceTxt;

		[SerializeField]
		private TextMeshProUGUI _virtualCurrencyTxt;

		[SerializeField]
		private Button _purchaseBtn;

		[SerializeField]
		private GameObject _iapGO;

		[SerializeField]
		private GameObject _virtualCurrencyGO;

		[SerializeField]
		private GameObject _rewardedVideoGO;

		public void Setup(IPrice price, Action btnClicked)
		{
		}

		public void RemoveAllListeners()
		{
		}
	}
}
