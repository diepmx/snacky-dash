using JuicedUp.Common.Economy.Internal.Views;
using JuicedUp.Common.Economy.Public.Views;
using UnityEngine;

namespace JuicedUp.Common.MilestoneProgressbar.Views
{
	public class SingleRewardMilestone : BaseMilestoneMarker
	{
		[SerializeField]
		private RewardView _rewardView;

		public IRewardView RewardView => null;
	}
}
