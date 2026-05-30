using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace MobileGameShop
{
	public class ShopOfferTile : MonoBehaviour
	{
		[Header("UI")]
		public TextMeshProUGUI titleText;

		public TextMeshProUGUI descText;

		public TextMeshProUGUI priceText;

		public TextMeshProUGUI badgeText;

		public Image iconImage;

		public Image backgroundImage;

		public Button buyButton;

		private string _offerId;

		public void Bind(ShopOfferVM vm, ShopPresenter presenter)
		{
		}
	}
}
