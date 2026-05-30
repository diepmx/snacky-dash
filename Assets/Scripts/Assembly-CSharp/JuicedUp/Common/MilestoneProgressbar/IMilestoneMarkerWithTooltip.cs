using JuicedUp.Common.Economy.Public.Views;

namespace JuicedUp.Common.MilestoneProgressbar
{
	public interface IMilestoneMarkerWithTooltip
	{
		IRewardView[] TooltipRewardViews { get; }
	}
}
