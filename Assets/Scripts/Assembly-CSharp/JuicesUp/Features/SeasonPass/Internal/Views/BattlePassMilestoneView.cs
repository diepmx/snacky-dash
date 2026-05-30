using System;
using TMPro;
using UnityEngine;

namespace JuicesUp.Features.SeasonPass.Internal.Views
{
	internal class BattlePassMilestoneView : MonoBehaviour
	{
		[SerializeField]
		private TMP_Text _indexText;

		[SerializeField]
		private BattlePassMilestoneLockedStateView _lockedRewardView;

		[SerializeField]
		private BattlePassMilestoneInProgressStateView _inProgressRewardView;

		[SerializeField]
		private BattlePassMilestoneUnlockedStateView _unlockedRewardView;

		private MilestoneViewArgs _milestoneViewArgs;

		private MainViewArgs _mainViewArgs;

		public Action OnRewardGranted { get; set; }

		public void Initialise(MilestoneViewArgs milestoneViewArgs, MainViewArgs mainViewArgs, Action onRewardClicked, bool isCurrent)
		{
		}

		private void Clear()
		{
		}

		private void OnDestroy()
		{
		}

		private void OnPaidLockButtonPressed()
		{
		}

		public void Nullify()
		{
		}

		private void OnFreeClaimPressed()
		{
		}

		private void OnPaidClaimPressed()
		{
		}

		private void TryGrantRewardResult(BattlePassType type, int index, bool success)
		{
		}

		private void OnClaimResult(BattlePassType type, bool success)
		{
		}
	}
}
