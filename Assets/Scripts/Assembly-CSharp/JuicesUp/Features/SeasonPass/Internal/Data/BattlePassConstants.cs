namespace JuicesUp.Features.SeasonPass.Internal.Data
{
	internal static class BattlePassConstants
	{
		public static class LocalizationKeys
		{
			public const string PassLockedReward = "pass_locked_reward";
		}

		public static class AnalyticsKeys
		{
			public const string EventImpression = "live_ops_impressions";

			public const string EventItemTransaction = "live_ops_itemtransaction";

			public const string EventIAPRewarded = "live_ops_iaprewarded";

			public const string Name = "name";

			public const string RunId = "run_id";

			public const string GameLevel = "game_level";

			public const string GameCoinBalance = "game_coin_balance";

			public const string DaysSinceInstall = "days_since_install";

			public const string LiveopsParticipationCount = "liveops_participation_count";

			public const string LiveopsLevelJoined = "liveops_level_joined";

			public const string MilestoneLevel = "milestone_level";

			public const string SecondsRemaining = "seconds_remaining";

			public const string LiveopsCurrencyBalance = "liveops_currency_balance";

			public const string BoosterHammerBalance = "booster_hammer_balance";

			public const string BoosterSlotBalance = "booster_slot_balance";

			public const string BoosterShuffleBalance = "booster_shuffle_balance";

			public const string BoosterSelectBalance = "booster_select_balance";

			public const string ImpressionTrigger = "impression_trigger";

			public const string BarProgression = "bar_progression";

			public const string RewardsDisplayed = "rewards_displayed";

			public const string PassStatus = "pass_status";

			public const string RewardTrackType = "reward_track_type";

			public const string ItemName = "item_name";

			public const string NbUnits = "nb_units";

			public const string LifeBalance = "life_balance";

			public const string Placement = "placement";

			public const string MaxMilestoneLevel = "max_milestone_level";

			public const string FinalPassStatus = "final_pass_status";

			public const string NameValue = "battle_pass";

			public const string PassStatusFree = "Free";

			public const string PassStatusPremium = "Premium";

			public const string ImpressionTriggerManual = "Manual";

			public const string ImpressionTriggerAutomatic = "Automatic";

			public const string ImpressionTriggerFtue = "FTUE";
		}

		public const string DebugName = "[SeasonPass]";

		public const string VTRewardName = "SeasonPass";

		public const string VTRewardId = "battle_pass";

		public const string MainOfferTag = "sp_main";

		public const string SeasonTagPrefix = "sp_season:";

		public const string FreeTag = "sp_free";

		public const string PremiumTag = "sp_premium";

		public const string DefaultTag = "sp_default";

		public const string BattleTokensPrefix = "tokens:";

		public const string SpecialMilestoneTag = "special";

		public const string DefaultSeasonKey = "default";

		public const string PlacementBattlePass = "battle_pass";

		public const string FeatureSaveKey = "SeasonPassSaveKey";

		public const string StartViewPrefabAddressable = "BattlePassStartView";

		public const string MainViewPrefabAddressable = "BattlePassMainView";

		public const string RewardIconsAddressable = "BattlePassRewardIcons";

		public const string OfferViewPrefabAddressable = "BattlePassOfferView";

		public const string PurchaseSuccessViewPrefabAddressable = "BattlePassPurchaseSuccessView";

		public const string PurchaseOverlayAddressable = "BattlePassPurchaseOverlay";

		public const string PassEndedViewPrefabAddressable = "BattlePassPassEndedView";

		public const string EndRewardsChestViewAddressable = "BattlePassClaimAllChestOpening";

		public const string MilestoneRewardChestViewAddressable = "BattlePassMilestoneRewardChestOpening";

		public const string ChestTooltipAssetKey = "VerticalCommonTooltip";

		public const float PurchaseOverlayReopenMainViewDelaySeconds = 0.5f;

		public const float SpecialPremiumRewardIconScale = 1.2f;
	}
}
