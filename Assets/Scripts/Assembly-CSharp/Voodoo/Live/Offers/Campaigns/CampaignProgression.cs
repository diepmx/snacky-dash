using System;
using System.Collections.Generic;
using Voodoo.Live.Utils;

namespace Voodoo.Live.Offers.Campaigns
{
	public class CampaignProgression : IDisposable
	{
		private const string CampaignDataFileName = "voodoolive_campaigns_cache_";

		private const string CampaignDataFileExtension = ".json";

		private readonly string _cacheFilePath;

		private CacheSystem _cache;

		private CampaignCache _data;

		private bool _disposed;

		private readonly List<IFeature> _subscribedFeatures;

		public Dictionary<string, IServerFeature> dtos;

		public CampaignCache GetCachedData()
		{
			return null;
		}

		public CampaignProgression(string campaignName)
		{
		}

		private static string BuildCampaignDataPath(string campaignName)
		{
			return null;
		}

		public void LoadCache()
		{
		}

		public void ResetCache()
		{
		}

		public void RemoveInvalidServerFeature(string campaignName, List<IServerFeature> features)
		{
		}

		public void AddDefaultServerFeatures(List<IServerFeature> features)
		{
		}

		public void ListenFeature(IFeature feature)
		{
		}

		private void OnStatusChanged(string status, IFeature feature)
		{
		}

		public int GetCachedCooldownDuration()
		{
			return 0;
		}

		public DateTime GetCachedCooldownStartDate()
		{
			return default(DateTime);
		}

		public void SetCooldown(int duration, DateTime startDate)
		{
		}

		public void Dispose()
		{
		}
	}
}
