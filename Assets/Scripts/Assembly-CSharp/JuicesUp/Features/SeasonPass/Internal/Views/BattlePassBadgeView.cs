using System;
using JuicesUp.Features.SeasonPass.Internal.Core;
using MoreMountains.Feedbacks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using VContainer;

namespace JuicesUp.Features.SeasonPass.Internal.Views
{
	internal class BattlePassBadgeView : MonoBehaviour
	{
		private enum State
		{
			Locked = 0,
			Unlocked = 1,
			Claim = 2
		}

		private const float FallbackDuration = 2f;

		[SerializeField]
		private Button _button;

		[Header("Locked State")]
		[SerializeField]
		private GameObject _lockedStateView;

		[SerializeField]
		private TMP_Text _levelToUnlockText;

		[Header("Claim State")]
		[SerializeField]
		private GameObject _unlockStateView;

		[SerializeField]
		private CountdownTimerText _timerText;

		[Header("Claim State")]
		[SerializeField]
		private GameObject _claimStateView;

		[SerializeField]
		private Image _progressBar;

		[SerializeField]
		private TMP_Text _notificationText;

		[Header("Feedbacks")]
		[SerializeField]
		private MMF_Player _flyTokensFeedback;

		private IBattlePassManager _manager;

		private IBattlePassUIController _uiController;

		private IBattlePassAppBridge _appBridge;

		private IDisposable _initSubscription;

		private bool _hasRewardsToClaim;

		private int _tokensToBeAdded;

		private State _state;

		private Func<Transform> _badgeTargetGetter;

		[Inject]
		private void Construct(IBattlePassManager manager, IBattlePassUIController uiController, IBattlePassAppBridge appBridge)
		{
		}

		private void Awake()
		{
		}

		private void OnTokensEarned(int arg1, int arg2)
		{
		}

		private void ChangeState(State state)
		{
		}

		private void OnDestroy()
		{
		}

		private void UpdateView()
		{
		}

		private void Initialise(bool isEnabled)
		{
		}

		private void CalculateTokenToBeAdded()
		{
		}

		private void ScheduleTokenAnimationIfNeeded()
		{
		}

		private bool CanShow()
		{
			return false;
		}

		private void OnScheduledPlayTokenAnimation(Action onComplete)
		{
		}

		private void AppendTokensTask()
		{
		}

		private void UpdateProgressBar()
		{
		}

		private void OpenMainUi()
		{
		}
	}
}
