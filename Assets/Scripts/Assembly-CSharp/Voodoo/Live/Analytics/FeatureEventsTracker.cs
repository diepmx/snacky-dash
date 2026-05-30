using System;
using System.Collections.Generic;
using Voodoo.Live.Offers;

namespace Voodoo.Live.Analytics
{
	public class FeatureEventsTracker : IDisposable
	{
		private readonly FeatureTrackingRegistry _registry;

		private bool _disposed;

		public void Initialize(List<IFeature> features)
		{
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
