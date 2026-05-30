using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Voodoo.Live.Analytics;
using Voodoo.Live.Offers.Campaigns;

namespace Voodoo.Live.Offers
{
	public class FeatureClient : ReloadableClient, IFeatureClient, IReloadableClient, IClient, IDisposable
	{
		private const string FeaturesDataFileName = "voodoolive_local_offers_cache.json";

		public const string FeaturesDataPath = "VoodooLive/voodoolive_local_offers_cache.json";

		private FeaturesConfig _featuresConfig;

		private Inventory _inventory;

		private FeatureFactory _featureFactory;

		private bool _isCacheBuildData;

		protected readonly List<IFeature> _activeFeatures;

		protected readonly List<IFeature> _invalidFeatures;

		private Dictionary<string, Campaign> _campaignByName;

		private FeatureEventsTracker _featureEventsTracker;

		protected IFeatureQueue _featureQueue;

		protected override string ClientName => null;

		protected override string ConfigStatusEventName => null;

		public IFeatureQueue FeatureQueue => null;

		public event Func<IFeature, bool> customFeatureValidation
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

		public event Action<string> triggerRaised
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

		public virtual void Initialize(IFeatureQueue featureQueue, Inventory inventory)
		{
		}

		private void SubscribeToQueueEvents()
		{
		}

		private void OnQueueBecameActive()
		{
		}

		private void OnQueueBecameIdle()
		{
		}

		protected override void ProcessPayload()
		{
		}

		protected void InitializeNonConsumableMapping()
		{
		}

		protected void InitializeCampaign(Campaign campaign, List<IServerFeature> serverFeatures)
		{
		}

		private void AddHeaders()
		{
		}

		public void Trigger(string trigger)
		{
		}

		public void ValidateFeatures()
		{
		}

		public void ValidateFeature(IFeature feature)
		{
		}

		private void InvalidateFeature(IFeature feature)
		{
		}

		private void SubscribeToFeatureInvalidation(IFeature feature)
		{
		}

		protected void OnFeatureStatusChanged(string status, IFeature feature)
		{
		}

		public List<IFeature> GetActiveFeatures()
		{
			return null;
		}

		public IFeature GetFeatureById(string id)
		{
			return null;
		}

		public List<IFeature> GetInvalidFeatures()
		{
			return null;
		}

		public List<Campaign> GetCampaigns()
		{
			return null;
		}

		public bool ShouldDisplayBadge(IFeature feature)
		{
			return false;
		}

		public bool IsItemNonConsumable(string itemName)
		{
			return false;
		}

		public string[] GetNonConsumableSkusByItemName(string itemName)
		{
			return null;
		}

		public string[] GetNonConsumableItemNamesBySku(string sku)
		{
			return null;
		}

		public Item GetItemById(string id)
		{
			return null;
		}

		public Item GetItemByName(string name)
		{
			return null;
		}

		public Inventory GetInventory()
		{
			return null;
		}

		public FeatureFactory GetFeatureFactory()
		{
			return null;
		}

		private bool IsFeatureInCampaign(IFeature feature)
		{
			return false;
		}

		private bool CanUseCampaign(string campaignName)
		{
			return false;
		}

		public bool IsItemNonConsumable(Item item)
		{
			return false;
		}

		public bool IsNonConsumable(IPrice price)
		{
			return false;
		}

		public void AddEventsToTrack(List<BaseEvent> events, string featureType = "")
		{
		}

		public void SetEventsToTrack(List<BaseEvent> events, string featureType = "")
		{
		}

		public List<string> GetTrackedEventsNames()
		{
			return null;
		}

		public void CleanTrackedEvents(string featureType = "")
		{
		}

		public void RemoveTrackedEvents(List<BaseEvent> events, string featureType = "")
		{
		}

		public void ResetCampaigns()
		{
		}

		public void ResetFeatures()
		{
		}

		private void Clear()
		{
		}

		protected override void DisposeSubclass()
		{
		}
	}
}
