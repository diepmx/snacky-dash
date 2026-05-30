using System;
using System.Collections.Generic;
using UnityEngine;

namespace JuicesUp.Features.SeasonPass.Internal.Views
{
	internal class MainViewArgs
	{
		public string SeasonTitle;

		public DateTime EndTime;

		public bool IsFree;

		public bool IsActive;

		public bool HasSeenTutorials;

		public bool HasSeenPassPurchased;

		public List<MilestoneViewArgs> Milestones;

		public Action<BattlePassType, int, Transform> OnMilestonePressed;

		public Action<BattlePassType, int> OnMilestoneClaimPressed;

		public Action<BattlePassType, int, bool> OnGrantMilestoneRewardResult;

		public Action OnTutorialsSeen;

		public Action OnPurchasedSeen;

		public Action OnPurchaseButtonClicked;

		public Action<int> OnTokensProcessed;

		public Action OnPanelClosing;

		public bool IsValid()
		{
			return false;
		}

		public bool IsClaimableState(MilestoneViewArgs milestone, BattlePassType type, MilestoneViewState state)
		{
			return false;
		}

		public bool HasFinished(MilestoneViewArgs milestone, MilestoneViewState state)
		{
			return false;
		}

		public bool HasFinishedProcessed(MilestoneViewArgs milestone)
		{
			return false;
		}

		public bool HasFinishedCurrent(MilestoneViewArgs milestone)
		{
			return false;
		}
	}
}
