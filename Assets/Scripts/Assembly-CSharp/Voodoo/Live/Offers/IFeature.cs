using System;

namespace Voodoo.Live.Offers
{
	public interface IFeature : IConditionnal, IDisposable, IResultProvider, IPurchasable
	{
		string id { get; set; }

		string name { get; set; }

		string[] triggers { get; set; }

		string campaign { get; set; }

		string campaignId { get; set; }

		FeatureVisual visual { get; set; }

		string type { get; set; }

		bool ShouldDisplayBadges { get; }

		string Status { get; }

		event Action<string, IFeature> statusChanged;

		void InvalidateFeature();

		void SetStatus(string status);

		bool HasTrigger(string trigger);

		bool TryTrigger(string trigger, bool forceTrigger = false, string sourceType = null, string sourceValue = null);
	}
}
