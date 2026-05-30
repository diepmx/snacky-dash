using System;
using KiraganGames.Ui;
using MoreMountains.Feedbacks;
using TMPro;
using UnityEngine;

namespace JuicesUp.Features.SeasonPass.Internal.Views
{
	internal class BattlePassGenericPopupView : MonoBehaviour
	{
		[SerializeField]
		private CanvasGroup _canvasGroup;

		[SerializeField]
		private CountdownTimerText _countdownTimerText;

		[SerializeField]
		private TMP_Text _text;

		[SerializeField]
		private TMP_Text _actionButtonText;

		[SerializeField]
		private Button _actionButton;

		[SerializeField]
		private Button _closeButton;

		[Header("Feedback")]
		[SerializeField]
		private MMF_Player _openFeedeback;

		[SerializeField]
		private MMF_Player _closeFeedback;

		private Action _callback;

		private Action _closeCallback;

		private void Awake()
		{
		}

		public void Show(Action callback, Action closeCallback, DateTime? targetDate = null, IBattlePassAppBridge appBridge = null)
		{
		}

		public void Show(string text, string actionButtonText, Action callback, Action closeCallback, DateTime? targetDate = null, IBattlePassAppBridge appBridge = null)
		{
		}

		public void Hide()
		{
		}

		private void CloseButtonOnButtonPressedUp()
		{
		}

		private void ActionButtonOnButtonPressedUp()
		{
		}

		private void UpdateCanvasGroup(bool isEnabled)
		{
		}
	}
}
