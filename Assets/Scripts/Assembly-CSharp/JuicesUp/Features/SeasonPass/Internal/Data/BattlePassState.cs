using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace JuicesUp.Features.SeasonPass.Internal.Data
{
	[Serializable]
	internal class BattlePassState
	{
		public string SeasonOfferId;

		public string SeasonKey;

		public string SeasonTitle;

		public string SeasonStartDateStr;

		public string SeasonEndDateStr;

		public string PremiumPurchaseDateStr;

		public BattlePassStatus Status;

		public bool IsFree;

		public List<string> ProcessedTransactionIds;

		public int ParticipationCount;

		public int CurrentTokens;

		public int ProcessedTokens;

		public int WidgetProcessedTokens;

		public int LuckyLoopClaimedCount;

		public int AnalyticsLastCompletedMilestoneIndex;

		public int AnalyticsLastCompletedLuckyLoopCount;

		public int LevelJoined;

		[JsonIgnore]
		public int LastGameTokensEarned;

		public List<int> ClaimedFreeMilestoneIndices;

		public List<int> ClaimedPremiumMilestoneIndices;

		public bool WerePerksApplied;

		public bool HasSeenIntro;

		public bool HasSeenTutorials;

		public bool HasSeenPassPurchased;

		public bool HasSeenConveyorGoldening;

		public int LastSeenMilestone;

		[JsonIgnore]
		public DateTime? SeasonStartDate
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		[JsonIgnore]
		public DateTime? SeasonEndDate
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		[JsonIgnore]
		public DateTime? PremiumPurchaseDate
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		internal void ResetProgress()
		{
		}

		internal void Clear()
		{
		}

		private static DateTime? ParseIso(string isoDateTime)
		{
			return null;
		}

		private static string ToIsoString(DateTime? value)
		{
			return null;
		}
	}
}
