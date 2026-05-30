using System.Collections.Generic;
using JuicesUp.Features.SeasonPass.Internal.Data;

namespace JuicesUp.Features.SeasonPass.Internal.Views
{
	internal class MilestoneViewArgs
	{
		public int Index;

		public bool IsFreeClaimed;

		public bool IsPaidClaimed;

		public int RequiredTokens;

		public bool IsSpecial;

		public MilestoneViewState ProcessedState;

		public MilestoneViewState CurrentState;

		public RewardVisualsArgs FreeRewardVisuals;

		public RewardVisualsArgs PaidRewardVisuals;

		public List<RewardVisualsArgs> FreeTooltipRewardVisuals;

		public List<RewardVisualsArgs> PaidTooltipRewardVisuals;

		public List<BattlePassReward> FreeRewards;

		public List<BattlePassReward> PaidRewards;

		public bool HasTooltip(BattlePassType type)
		{
			return false;
		}

		public List<BattlePassReward> GetRewards(BattlePassType type)
		{
			return null;
		}
	}
}
