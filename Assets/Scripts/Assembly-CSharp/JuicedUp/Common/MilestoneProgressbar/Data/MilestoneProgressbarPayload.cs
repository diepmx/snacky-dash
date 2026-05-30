using JuicedUp.Common.Economy.Public.Data;
using JuicedUp.Common.FeatureOriented;
using JuicedUp.Common.MilestoneProgressbar.Handlers;
using JuicedUp.Common.MilestoneProgressbar.Views;
using JuicedUp.Common.Tooltips.Data;

namespace JuicedUp.Common.MilestoneProgressbar.Data
{
	public class MilestoneProgressbarPayload
	{
		public readonly IFeatureOrientedMilestoneMarkersHandler MilestoneMarkersHandler;

		public readonly IMilestoneProgressBarView MilestoneProgressbarView;

		public readonly IProgressbarValueHandler ProgressbarValueHandler;

		public readonly IMilestonesHandler MilestonesHandler;

		public readonly IMilestoneFacade MilestoneFacade;

		public readonly TooltipDirection MilestoneMarkersDirection;

		public readonly CurrencyId EnergyCurrency;

		public readonly TooltipDirection GrandMilestoneMarkerDirection;

		public readonly string SingleRewardMilestoneMarkerKey;

		public readonly string ChestMilestoneMarkerKey;

		public MilestoneProgressbarPayload(IFeatureOrientedMilestoneMarkersHandler milestoneMarkersHandler, IMilestoneProgressBarView milestoneProgressbarView, IProgressbarValueHandler progressbarValueHandler, IMilestonesHandler milestonesHandler, IMilestoneFacade milestoneFacade, TooltipDirection milestoneMarkersDirection, CurrencyId energyCurrency, string singleRewardMilestoneMarkerKey, string chestMilestoneMarkerKey, TooltipDirection grandMilestoneMarkerDirection = TooltipDirection.Right)
		{
		}
	}
}
