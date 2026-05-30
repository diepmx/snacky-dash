using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Voodoo.Live.Offers.Campaigns
{
	public class CampaignCache
	{
		[JsonProperty("featuresId")]
		private List<string> _featuresId;

		[JsonProperty("cooldownDuration")]
		private int _cooldownDuration;

		[JsonProperty("cooldownStartDate")]
		private DateTime _cooldownStartDate;

		[JsonProperty("features")]
		private List<IServerFeature> _features;

		public List<IServerFeature> GetFeatures()
		{
			return null;
		}

		public void Add(IServerFeature feature)
		{
		}

		public void Remove(IServerFeature feature)
		{
		}

		public bool IsValid(IServerFeature feature)
		{
			return false;
		}

		public void SetCooldown(int duration, DateTime startDate)
		{
		}

		public int GetCooldownDuration()
		{
			return 0;
		}

		public DateTime GetCooldownStartDate()
		{
			return default(DateTime);
		}
	}
}
