using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Voodoo.Live.Shop;

namespace Voodoo.Live.Sample.Shop.UI
{
	public class ButtonProductUI : MonoBehaviour
	{
		[SerializeField]
		private Button _button;

		[SerializeField]
		private GameObject _iapGO;

		[SerializeField]
		private GameObject _adsGO;

		[SerializeField]
		private GameObject _softGO;

		[SerializeField]
		private TextMeshProUGUI _iapTxt;

		[SerializeField]
		private TextMeshProUGUI _adsTxt;

		[SerializeField]
		private TextMeshProUGUI _softTxt;

		private ShopProduct _shopProduct;

		public void Init(ShopProduct shopProduct)
		{
		}

		private void PurchaseProduct()
		{
		}
	}
}
