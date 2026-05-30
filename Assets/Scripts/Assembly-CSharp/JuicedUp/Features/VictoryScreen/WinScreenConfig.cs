using UnityEngine;

namespace JuicedUp.Features.VictoryScreen
{
	[CreateAssetMenu(menuName = "JuicedUp/Victory/Win Screen Config", fileName = "WinScreenConfig")]
	public class WinScreenConfig : ScriptableObject
	{
		[Tooltip("When true, base coin reward follows RewardManager (Remote Config).")]
		public bool useRemoteConfigReward;

		[Tooltip("Used when useRemoteConfigReward is false or RewardManager is unavailable.")]
		public int baseRewardFallback;

		[Tooltip("Fallback RV multiplier when Ads config is unavailable.")]
		public int rewardMultiplierFallback;

		[Tooltip("Minimum player level (1-based) before the RV button can appear.")]
		public int minLevelForRewardedVideo;

		[Tooltip("Pre-popup delay simulating victory animation (seconds).")]
		[Min(0f)]
		public float victoryAnimationDelaySeconds;
	}
}
