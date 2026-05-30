using System;
using Voodoo.Live.Analytics;
using Voodoo.Live.Shop.UI;

namespace Voodoo.Live.Shop
{
	public class ShopManager : ReloadableClient, IShopClient, IReloadableClient, IClient, IDisposable
	{
		private const string ShopDataFileName = "voodoolive_local_shop_cache.json";

		public const string ShopDataPath = "VoodooLive/voodoolive_local_shop_cache.json";

		private const string TAG = "ShopManager";

		private GameShop _gameShop;

		private Inventory _inventory;

		private IGameShop _shopDisplay;

		private bool _isCacheBuildData;

		private ShopEventsTracker _tracker;

		private VoodooLiveSettings _settings;

		protected override string ClientName => null;

		protected override string ConfigStatusEventName => null;

		public GameShop GameShop => null;

		public ShopEventsTracker EventsTracker => null;

		public ShopManager(IBlackboard blackboard)
		{
		}

		public void Init(Inventory inventory, IGameShop shopDisplay = null)
		{
		}

		private void SubscribeToShopEvents()
		{
		}

		private void OnShopOpened()
		{
		}

		private void OnShopClosed()
		{
		}

		protected override void ProcessPayload()
		{
		}

		public ShopProduct GetProductByIapId(string iapId)
		{
			return null;
		}

		protected override void DisposeSubclass()
		{
		}
	}
}
