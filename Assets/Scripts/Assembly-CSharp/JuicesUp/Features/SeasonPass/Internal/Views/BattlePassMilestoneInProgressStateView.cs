using System;
using UnityEngine;

namespace JuicesUp.Features.SeasonPass.Internal.Views
{
	internal class BattlePassMilestoneInProgressStateView : BattlePassMilestoneStateView
	{
		[SerializeField]
		private BattlePassMilestoneProgressBarView _progressBarView;

		public override void Initialise(MilestoneViewArgs payload, Action onFreeRewardClicked, Action onPaidRewardClicked)
		{
		}
	}
}
