using JuicedUp.Common.Economy.Internal.Views;
using JuicedUp.Common.Economy.Public.Views;
using UnityEngine;
using UnityEngine.UI;

namespace JuicedUp.Common.MilestoneProgressbar.Views
{
	public class GrandMilestoneView : BaseMilestoneMarker, IMilestoneMarkerWithTooltip
	{
		[SerializeField]
		private Image _chestImage;

		[SerializeField]
		private RewardView _rewardView;

		[SerializeField]
		private RewardView[] _tooltipRewardViews;

		public IRewardView RewardView => null;

		public IRewardView[] TooltipRewardViews => null;

		public void SetChestImages(Sprite chestSprite)
		{
		}

		public void ToggleMilestoneView(bool isSingleItemMilestone)
		{
		}
	}
}
