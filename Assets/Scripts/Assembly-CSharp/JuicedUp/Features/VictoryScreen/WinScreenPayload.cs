using System;
using JuicedUp.Features.Core.Ingredients;
using JuicedUp.Features.Core.Popup;
using JuicedUp.Features.WeeklyMissions.Public;

namespace JuicedUp.Features.VictoryScreen
{
	public class WinScreenPayload : IPopupPayload
	{
		public readonly IMissionExecutor MissionExecutor;

		public int RewardCoins { get; internal set; }

		public int RewardMultiplier { get; }

		public bool ShowRvButton { get; }

		public int CurrentLevel { get; }

		public IngredientDefinition FeatureInProgress { get; }

		public float FeatureProgressFrom { get; }

		public float FeatureProgressTo { get; }

		public bool FeatureJustUnlocked { get; }

		public Func<int, int> OnRewardedVideoCompleted { get; }

		public WinScreenPayload(int rewardCoins, int rewardMultiplier, bool showRvButton, int currentLevel, IngredientDefinition featureInProgress, float featureProgressFrom, float featureProgressTo, bool featureJustUnlocked, IMissionExecutor missionExecutor, Func<int, int> onRewardedVideoCompleted)
		{
		}
	}
}
