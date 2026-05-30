using System;
using System.Runtime.CompilerServices;
using KiraganGames.Ui;
using UnityEngine;
using UnityEngine.UI;

namespace JuicesUp.Features.SeasonPass.Internal.Views
{
	internal class BattlePassMilestoneUnlockedStateView : BattlePassMilestoneStateView
	{
		[Header("Free")]
		[SerializeField]
		private KiraganGames.Ui.Button _freeClaimButton;

		[SerializeField]
		private GameObject _freeClaimedFeedback;

		[Header("Paid")]
		[SerializeField]
		private KiraganGames.Ui.Button _paidClaimButton;

		[SerializeField]
		private GameObject _paidClaimFeedback;

		[SerializeField]
		private KiraganGames.Ui.Button _paidLockButton;

		[SerializeField]
		private UnityEngine.UI.Button _paidLockBackground;

		private MilestoneViewArgs _milestoneViewArgs;

		public event Action onFreeClaimButtonPressed
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event Action onPaidClaimButtonPressed
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event Action onPaidLockButtonPressed
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public override void Initialise(MilestoneViewArgs payload, Action onFreeRewardClicked, Action onPaidRewardClicked)
		{
		}

		private void OnDestroy()
		{
		}

		private void Clear()
		{
		}

		private void OnPremiumPurchased()
		{
		}

		public void UpdateView(bool isPremiumActivated)
		{
		}

		private void OnFreeClaimButtonPressedUp()
		{
		}

		private void OnPaidClaimButtonPressedUp()
		{
		}

		private void OnPaidLockButtonPressed()
		{
		}

		public void GrantReward(BattlePassType type)
		{
		}

		private void OnPaidClaimed()
		{
		}

		private void OnFreeClaimed()
		{
		}
	}
}
