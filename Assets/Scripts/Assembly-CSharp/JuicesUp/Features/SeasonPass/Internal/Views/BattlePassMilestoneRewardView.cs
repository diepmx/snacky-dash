using System;
using MoreMountains.Feedbacks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace JuicesUp.Features.SeasonPass.Internal.Views
{
	internal class BattlePassMilestoneRewardView : MonoBehaviour
	{
		[SerializeField]
		private Image _iconImage;

		[SerializeField]
		private Image _fxRewardImage;

		[SerializeField]
		private TextMeshProUGUI _amountText;

		[SerializeField]
		private MMF_Player _rewardFeedbackPlayer;

		[SerializeField]
		private Button _button;

		[SerializeField]
		private Transform _tooltipParent;

		public Transform TooltipParent => null;

		public void Initialise(RewardVisualsArgs payload, Action onButtonClick)
		{
		}

		public void SetIconScale(float scale)
		{
		}

		public void SetButtonActivation(bool isActive)
		{
		}

		public void PlayRewardFeedback()
		{
		}
	}
}
