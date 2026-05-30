using System;
using System.Collections.Generic;
using Voodoo.Live.Offers;
using Voodoo.Live.Offers.Campaigns;

namespace Voodoo.Live
{
	public interface IFeatureClient : IReloadableClient, IClient, IDisposable
	{
		IFeatureQueue FeatureQueue { get; }

		event Action<string> triggerRaised;

		event Func<IFeature, bool> customFeatureValidation;

		void Trigger(string appEvent);

		void ValidateFeatures();

		List<IFeature> GetActiveFeatures();

		List<IFeature> GetInvalidFeatures();

		List<Campaign> GetCampaigns();
	}
}
