using System.Collections.Generic;
using JuicedUp.Common.Economy.Public.Data;
using JuicedUp.Common.MilestoneProgressbar.Views;

namespace JuicedUp.Common.MilestoneProgressbar.Handlers
{
	public interface IFeatureOrientedMilestoneMarkersHandler
	{
		void Activate(IReadOnlyDictionary<IMilestoneMarker, IMilestone> milestoneDataByMarkers);

		void Deactivate();
	}
}
