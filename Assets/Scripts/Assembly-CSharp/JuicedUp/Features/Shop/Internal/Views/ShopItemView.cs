using System;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace JuicedUp.Features.Shop.Internal.Views
{
	public class ShopItemView : MonoBehaviour
	{
		[SerializeField]
		private Button _buyButton;

		[SerializeField]
		private TextMeshProUGUI _buyPriceText;

		private string _productId;

		public event Action<string> BuyButtonClicked
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		private void Awake()
		{
		}

		private void OnDestroy()
		{
		}

		public void Initialize(string productId)
		{
		}

		public void SetPriceTitle(string localizedPrice)
		{
		}

		private void OnBuyButtonClicked()
		{
		}
	}
}
