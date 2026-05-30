using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Voodoo.Live.Analytics;
using Voodoo.Live.Debugger;
using Voodoo.Live.Diagnostics;
using Voodoo.Live.Offers;
using Voodoo.Live.Offers.Campaigns;
using Voodoo.Live.Shop;
using Voodoo.Live.Shop.UI;

namespace Voodoo.Live
{
	public static class VoodooLive
	{
		public const string VoodooLiveFolderName = "VoodooLive/";

		public const string VoodooLiveDataFileName = "VoodooLive_Global";

		public const string VoodooLiveDataPath = "VoodooLive/VoodooLive_Global";

		private static FeatureClient _featureClient;

		private static IOperatorFactory _operatorFactory;

		private static IDecoratorFactory<IFeature> _decoratorFactory;

		private static IBlackboard _blackboard;

		private static Inventory _inventory;

		private static VoodooLiveSettings _settings;

		private static VoodooLiveDebuggerManager _voodooLiveDebuggerManager;

		private static VoodooLiveDiagnostics _diagnostic;

		private static ShopManager _shopManager;

		private static IGameShop _shopDisplay;

		private static bool _isInitialized;

		private static bool _disposed;

		private static IVoodooLiveBridge _bridge;

		private static SourceEventsTracker _sourceEventsTracker;

		public static ShopManager ShopManager => null;

		public static FeatureClient FeatureClient => null;

		public static VoodooLiveSettings Settings => null;

		public static VoodooLiveDebuggerManager VoodooLiveDebuggerManager => null;

		public static IBlackboard GlobalBlackboard => null;

		public static IFeatureQueue Queue => null;

		public static SourceEventsTracker SourceEventsTracker => null;

		public static IInventory Inventory => null;

		public static bool IsInitialized => false;

		public static bool IsDisposed => false;

		private static event Action OnVoodooLiveInitialized
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

		private static event Action offersReloaded
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

		private static event Action shopReloaded
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

		static VoodooLive()
		{
		}

		private static void SetupServices()
		{
		}

		public static void SubscribeOnInitFinishedEvent(Action onInitFinished)
		{
		}

		public static void UnSubscribeOnInitFinishedEvent(Action onInitFinished)
		{
		}

		public static void SubscribeOnOffersReload(Action callback)
		{
		}

		public static void UnSubscribeOnOffersReload(Action callback)
		{
		}

		public static void SubscribeOnShopReload(Action callback)
		{
		}

		public static void UnSubscribeOnShopReload(Action callback)
		{
		}

		public static void Initialize(IVoodooLiveBridge bridge, IOperatorFactory operatorFactory, IDecoratorFactory<IFeature> decoratorFactory, IFeatureQueue featureQueue, IGameShop shopDisplay = null, IDateTimeProvider dateTimeProvider = null)
		{
		}

		private static void InitializeShop()
		{
		}

		private static void OnShopReloaded()
		{
		}

		private static void InitializeOffers(IFeatureQueue featureQueue, IOperatorFactory operatorFactory, IDecoratorFactory<IFeature> decoratorFactory)
		{
		}

		private static void OnOfferReloaded()
		{
		}

		public static void LinkConditionFactories(IOperatorFactory operatorFactory, IDecoratorFactory<IFeature> decoratorFactory)
		{
		}

		public static void LinkBridge(IVoodooLiveBridge bridge)
		{
		}

		private static void OnTransactionComplete(TransactionReceipt receipt, bool isSuccess)
		{
		}

		public static void RetrieveTransaction()
		{
		}

		private static void OnTransactionStartedForRefresh()
		{
		}

		private static void OnTransactionCompletedForRefresh(TransactionReceipt receipt, bool isSuccess)
		{
		}

		public static void Reload()
		{
		}

		public static void Dispose()
		{
		}

		public static void Trigger(string trigger)
		{
		}

		public static void ForceShow(IFeature feature, string sourceType = null, string sourceValue = null)
		{
		}

		public static List<IFeature> GetActiveFeatures()
		{
			return null;
		}

		public static List<IFeature> GetInvalidFeatures()
		{
			return null;
		}

		public static IFeature GetFeatureById(string id)
		{
			return null;
		}

		public static List<Campaign> GetCampaigns()
		{
			return null;
		}

		public static bool ShouldDisplayBadge(IFeature feature)
		{
			return false;
		}

		public static void ResetCampaigns()
		{
		}

		public static void ResetFeatures()
		{
		}

		public static void ValidateFeatures()
		{
		}

		public static FeatureFactory GetFeatureFactory()
		{
			return null;
		}

		public static bool IsNonConsumable(IPrice price)
		{
			return false;
		}

		public static Item GetItemById(string id)
		{
			return null;
		}

		public static Item GetItemByName(string name)
		{
			return null;
		}

		public static bool HasItem(string id)
		{
			return false;
		}

		public static bool HasItemByName(string name)
		{
			return false;
		}

		public static bool HasItemQuantity(string id, int amount)
		{
			return false;
		}

		public static bool IsItemOwned(string id)
		{
			return false;
		}

		public static bool IsItemOwnedByName(string name)
		{
			return false;
		}

		public static bool IsItemNonConsumable(Item item)
		{
			return false;
		}

		public static bool IsItemNonConsumable(string itemName)
		{
			return false;
		}

		public static bool HasNonConsumableItemPurchased(List<string> itemNames, out string itemName)
		{
			itemName = null;
			return false;
		}

		public static VoodooLiveBuilder Builder()
		{
			return null;
		}

		public static DiagnosticReport GetDiagnostics()
		{
			return null;
		}

		public static void ReportDiagnostic(DiagnosticCode code, string message, string context = null)
		{
		}

		public static void ClearDiagnostics()
		{
		}
	}
}
