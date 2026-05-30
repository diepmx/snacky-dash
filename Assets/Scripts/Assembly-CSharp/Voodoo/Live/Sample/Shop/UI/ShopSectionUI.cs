using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Voodoo.Live.Sample.Utils;
using Voodoo.Live.Shop;
using Voodoo.Live.Shop.UI;
using Voodoo.Live.Utils;

namespace Voodoo.Live.Sample.Shop.UI
{
	public class ShopSectionUI : MonoBehaviour, IShopSection
	{
		[SerializeField]
		private TextMeshProUGUI _sectionTitleTxt;

		[SerializeField]
		private Transform _productsContainer;

		[SerializeField]
		private ProductUI _productSingleUIPrefab;

		[SerializeField]
		private ProductUI _productBundleUIPrefab;

		[SerializeField]
		private UIGradient _gradient;

		[Header("Gradients")]
		[SerializeField]
		private TMP_ColorGradient _goldGradient;

		[SerializeField]
		private TMP_ColorGradient _blueGradient;

		[SerializeField]
		private TMP_ColorGradient _greenGradient;

		private List<ProductUI> _products;

		public void Init(ShopSection shopSection, Action showLoadingScreen, GameShop gameShop, RectTransform rectTransform, SpriteDictionarySO spriteDictionarySo)
		{
		}

		private void OnEnable()
		{
		}
	}
}
