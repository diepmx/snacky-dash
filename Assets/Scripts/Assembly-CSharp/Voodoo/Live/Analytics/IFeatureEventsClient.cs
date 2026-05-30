using System;
using System.Collections.Generic;
using Voodoo.Live.Offers;

namespace Voodoo.Live.Analytics
{
	public interface IFeatureEventsClient : IDisposable
	{
		void Attach(IFeature feature);

		void AddEventsToTrack(List<BaseEvent> events);

		void SetEventsToTrack(List<BaseEvent> events);

		List<string> GetTrackedEventsNames();

		void CleanEventsToTrack();

		void CleanEventsToTrack(List<BaseEvent> events);

		void ClearAttachedFeatures();
	}
}
