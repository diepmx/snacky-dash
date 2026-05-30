using System;
using System.Collections.Generic;
using Voodoo.Live.Offers;

namespace Voodoo.Live.Analytics
{
	public class FeatureEventsClient : IFeatureEventsClient, IDisposable
	{
		private Dictionary<string, BaseEvent> _eventsByName;

		private readonly List<IFeature> _attachedFeatures;

		private bool _disposed;

		public FeatureEventsClient(List<BaseEvent> events)
		{
		}

		public void Attach(IFeature feature)
		{
		}

		private void OnStatusChanged(string status, IFeature feature)
		{
		}

		public void AddEventsToTrack(List<BaseEvent> events)
		{
		}

		public void SetEventsToTrack(List<BaseEvent> events)
		{
		}

		public List<string> GetTrackedEventsNames()
		{
			return null;
		}

		public void CleanEventsToTrack()
		{
		}

		public void CleanEventsToTrack(List<BaseEvent> events)
		{
		}

		private void Track(IFeature feature)
		{
		}

		public void Detach(IFeature feature)
		{
		}

		public void Dispose()
		{
		}

		public void ClearAttachedFeatures()
		{
		}
	}
}
