using System;
using UnityEngine;

namespace JuicesUp.Features.SeasonPass.Internal.Views
{
	internal class BattlePassMilestoneStateView : MonoBehaviour
	{
		[SerializeField]
		protected BattlePassMilestoneRewardView _freeRewardView;

		[SerializeField]
		protected BattlePassMilestoneRewardView _paidRewardView;

		public Transform FreeRewardTooltipParent => null;

		public Transform PaidRewardTooltipParent => null;

		public virtual void Initialise(MilestoneViewArgs payload, Action onFreeRewardClicked, Action onPaidRewardClicked)
		{
		}
	}
}
