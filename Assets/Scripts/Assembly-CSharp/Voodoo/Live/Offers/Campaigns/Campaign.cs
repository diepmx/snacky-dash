using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Voodoo.Live.Offers.Utility;

namespace Voodoo.Live.Offers.Campaigns
{
	public class Campaign : Conditionnal, IDisposable, IResettable
	{
		private List<IFeature> _activeFeatures;

		private readonly CampaignProgression _campaignProgression;

		private readonly CooldownTracker _cooldownTracker;

		private Type _featureType;

		private new bool _disposed;

		public const string CampaignsFolderName = "Campaigns/";

		public const string CampaignsFolderPath = "VoodooLive/Campaigns/";

		public string id { get; set; }

		public string name { get; set; }

		public List<string> offersId { get; set; }

		public override IBlackboard Blackboard => null;

		public event Action<string, IFeature> activeFeatureStatusChanged
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

		public Campaign(string campaignId, string campaignName)
		{
		}

		public override bool CanUse(List<string> ignoreKeys = null)
		{
			return false;
		}

		public void SyncServerFeaturesWithProgression(List<IServerFeature> serverFeatures)
		{
		}

		private bool IsFeatureCompatibleWithCampaign(IFeature feature)
		{
			return false;
		}

		public bool SetupFeature(IFeature feature)
		{
			return false;
		}

		public void TriggerCooldown(int cooldownInHours)
		{
		}

		private void OnFeatureStatusChanged(string status, IFeature feature)
		{
		}

		public void Reset()
		{
		}

		public void ClearCooldown()
		{
		}

		public CampaignCache GetCachedData()
		{
			return null;
		}

		public override void Dispose()
		{
		}
	}
}
