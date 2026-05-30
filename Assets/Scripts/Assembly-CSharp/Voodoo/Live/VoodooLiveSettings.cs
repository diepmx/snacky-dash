using UnityEngine;
using Voodoo.Live.Offers;
using Voodoo.Live.Shop;

namespace Voodoo.Live
{
	[CreateAssetMenu(fileName = "VoodooLiveSettings", menuName = "VoodooLive/VoodooLive Settings")]
	public class VoodooLiveSettings : ScriptableObject
	{
		public const string version = "4.1.0";

		[Header("Settings")]
		public bool isOfferEnabled;

		public bool isShopEnabled;

		[Header("Configs")]
		[SerializeField]
		private OffersConfigSO _offersConfig;

		[SerializeField]
		private ShopConfigSO _shopConfig;

		[Header("Services")]
		[SerializeField]
		private bool _purchasingService;

		[Header("Random Rewards")]
		public DrawMode drawMode;

		private const string TAG = "VOODOOLIVE_SETTINGS_CONFIG";

		private static VoodooLiveSettings _instance;

		public OffersConfigSO OffersConfig => null;

		public ShopConfigSO ShopConfig => null;

		public static VoodooLiveSettings Load()
		{
			return null;
		}
	}
}
