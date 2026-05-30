using System;
using System.Collections.Generic;
using Voodoo.Live.Offers;

namespace Voodoo.Live.Analytics
{
	public class FeatureTrackingRegistry : IDisposable
	{
		private readonly IFeatureEventsClient _commonClient;

		private readonly DecoratorFactory _featureDecoratorFactory;

		private readonly Dictionary<string, IFeatureEventsClient> _featureClients;

		public void Initialize(List<IFeature> features)
		{
		}

		private IFeatureEventsClient GetClient(string featureType = "")
		{
			return null;
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

		public void Clear()
		{
		}

		public void Dispose()
		{
		}
	}
}
