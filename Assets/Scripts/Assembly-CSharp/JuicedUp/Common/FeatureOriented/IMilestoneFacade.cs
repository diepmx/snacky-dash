using System.Collections.Generic;
using JuicedUp.Common.Economy.Public.Data;

namespace JuicedUp.Common.FeatureOriented
{
	public interface IMilestoneFacade
	{
		IReadOnlyList<IMilestone> GetAllMilestones();

		IMilestone GetCurrentActiveMilestone();

		bool IsClaimed(IMilestone milestone);

		void MarkClaimed(IMilestone milestone);
	}
}
