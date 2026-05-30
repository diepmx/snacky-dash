using JuicedUp.Common.Economy.Internal.Views;
using JuicedUp.Common.Economy.Public.Views;
using UnityEngine;
using UnityEngine.UI;

namespace JuicedUp.Common.MilestoneProgressbar.Views
{
	public class ChestMilestone : BaseMilestoneMarker, IMilestoneMarkerWithTooltip
	{
		[SerializeField]
		private Image _chestImage;

		[SerializeField]
		private RewardView[] _tooltipRewardViews;

		public IRewardView[] TooltipRewardViews => null;

		public void SetChestImages(Sprite chestSprite)
		{
		}
	}
}
