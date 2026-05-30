using System;
using System.Collections.Generic;
using JuicesUp.Features.SeasonPass.Internal.Data;
using UnityEngine;

namespace JuicesUp.Features.SeasonPass.Internal.Core
{
	internal static class BattlePassEvents
	{
		public static Func<Transform> GetBadgeTarget;

		public static Func<string, Transform> GetRewardFlyTarget;

		public static Action OnDebugRefreshViews;

		public static Action OnNewSeasonStarted;

		public static Action OnGracePeriodStarted;

		public static Action OnSeasonEnded;

		public static Action<int, int> OnTokensEarned;

		public static Action OnMilestoneClaimed;

		public static Action<int> OnFreeMilestoneClaimed;

		public static Action<int> OnPremiumMilestoneClaimed;

		public static Action OnPremiumPurchased;

		public static Action<List<BattlePassReward>> OnRewardsAutoClaimed;

		public static Action OnMainPanelClosed;

		public static Action<string> OnShowPurchasePopup;

		public static Action<bool> OnPassPurchaseResult;

		public static Action OnShowPurchasedPerks;

		public static Action OnPassPurchasedPerksDone;

		public static Func<bool> IsPerksUIOngoing;

		public static Func<bool> IsResultUIOpen;
	}
}
