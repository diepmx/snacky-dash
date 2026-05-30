using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Voodoo.Live.Shop;
using Voodoo.Live.Shop.UI;
using Voodoo.Live.Utils;

namespace Voodoo.Live.Sample.Shop.UI
{
	public class GameShopUI : GameShopBase
	{
		[SerializeField]
		private Transform _sectionsContainer;

		[SerializeField]
		private ShopSectionUI _shopSectionUIPrefab;

		[SerializeField]
		private TextMeshProUGUI _shopNameTxt;

		[SerializeField]
		private GameObject _loadingScreen;

		[SerializeField]
		private GameObject _shopGO;

		[SerializeField]
		private Button _closeBtn;

		[SerializeField]
		private RectTransform _scrollViewRect;

		[SerializeField]
		private SpriteDictionarySO _spriteDictionary;

		private GameShop _gameShop;

		private void Start()
		{
		}

		public override void Init()
		{
		}

		public void ShowLoadingScreen()
		{
		}

		public void HideLoadingScreen(bool success)
		{
		}

		public override void OpenShop(string sourceId, string sourceName)
		{
		}

		private void CloseShop()
		{
		}
	}
}
