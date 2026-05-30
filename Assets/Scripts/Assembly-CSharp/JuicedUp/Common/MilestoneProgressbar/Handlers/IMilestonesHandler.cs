using System;
using JuicedUp.Common.Economy.Public.Data;

namespace JuicedUp.Common.MilestoneProgressbar.Handlers
{
	public interface IMilestonesHandler
	{
		event Action<IMilestone> MilestoneClaimed;
	}
}
