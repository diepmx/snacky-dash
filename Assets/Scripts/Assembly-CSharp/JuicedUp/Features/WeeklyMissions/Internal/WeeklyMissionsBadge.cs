using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using JuicedUp.Common.FeatureOriented;
using JuicedUp.Common.Network;
using JuicedUp.Common.QueueManagement;
using JuicedUp.Common.Time;
using JuicedUp.Features.WeeklyMissions.Public;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using VContainer;

namespace JuicedUp.Features.WeeklyMissions.Internal
{
	internal class WeeklyMissionsBadge : MonoBehaviour
	{
		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CInitializeBadge_003Ed__36 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskMethodBuilder _003C_003Et__builder;

			public WeeklyMissionsBadge _003C_003E4__this;

			private void MoveNext()
			{
			}

			void IAsyncStateMachine.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				this.MoveNext();
			}

			[DebuggerHidden]
			private void SetStateMachine(IAsyncStateMachine stateMachine)
			{
			}

			void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
			{
				//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
				this.SetStateMachine(stateMachine);
			}
		}

		private const string LockedClickAnimation = "Widget_GenericLock";

		[SerializeField]
		private Button _button;

		[Space]
		[SerializeField]
		private GameObject _lockedWidgetState;

		[SerializeField]
		private GameObject _unlockedWidgetState;

		[SerializeField]
		private GameObject _stateHolder;

		[Space]
		[SerializeField]
		private TextMeshProUGUI _unlockLevelTitle;

		[SerializeField]
		private TextMeshProUGUI _timerTitle;

		[SerializeField]
		private TextMeshProUGUI _notificationCounter;

		[SerializeField]
		private GameObject _notificationDot;

		[SerializeField]
		private Animator _lockedAnimator;

		private IWeeklyMissionFtueBadgeController _weeklyMissionFtueBadgeController;

		private IWeeklyMissionsPopupController _weeklyMissionsController;

		private IWeeklyMissionsDataProvider _weeklyMissionsDataProvider;

		private INetworkConnectionProvider _networkConnectionProvider;

		private IFeatureAvailabilityProvider _featureStatusProvider;

		private IWeeklyMissionsFacade _weeklyMissionsFacade;

		private IServerTimeProvider _serverTimeProvider;

		private TimerHandler _timerHandler;

		private IActionQueue _queue;

		private Loading _loading;

		private CancellationTokenSource _badgeTokenSource;

		private IDisposable _featureStatusSubscription;

		private IDisposable _networkStatusSubscription;

		private string _currentLockKey;

		private int _currentUnlockLevel;

		private string _currentTimerKey;

		[Inject]
		private void Construct(IWeeklyMissionFtueBadgeController weeklyMissionFtueBadgeController, IWeeklyMissionsPopupController weeklyMissionsController, IWeeklyMissionsDataProvider weeklyMissionsDataProvider, INetworkConnectionProvider networkConnectionProvider, [Key(FeatureIds.WeeklyMissions)] IFeatureAvailabilityProvider featureStatusProvider, IWeeklyMissionsFacade weeklyMissionsFacade, IServerTimeProvider serverTimeProvider, IActionQueue queue, Loading loading)
		{
		}

		private void Awake()
		{
		}

		private void OnDestroy()
		{
		}

		private void OnFeatureInitialized(bool isInitialized)
		{
		}

		private void OnButtonPressedUp()
		{
		}

		private void OnNetworkStatusChanged(bool isOnline)
		{
		}

		private void OnCurrentWeeklyMissionCompleted()
		{
		}

		private void OnLanguageChanged()
		{
		}

		private void OnMissionCompleted(MissionData missionData)
		{
		}

		private void OnMissionClaimed(MissionData missionData)
		{
		}

		[AsyncStateMachine(typeof(_003CInitializeBadge_003Ed__36))]
		private UniTask InitializeBadge()
		{
			return default(UniTask);
		}

		private void SelectWidgetState()
		{
		}

		private void SelectStatusForNotificationDot()
		{
		}

		private void ActivateLockBehaviour(string lockText)
		{
		}

		private void ActivateUnlockBehaviour()
		{
		}

		private bool IsUnlocked()
		{
			return false;
		}

		private void ActivateTimer()
		{
		}

		private void OnTimerTicked(TimeSpan time)
		{
		}

		private void SetEndedStatusForTimer()
		{
		}

		private void SetClaimStatusForTimer()
		{
		}
	}
}
