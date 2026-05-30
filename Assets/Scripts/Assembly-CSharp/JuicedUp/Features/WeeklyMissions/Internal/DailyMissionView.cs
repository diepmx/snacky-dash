using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using DG.Tweening;
using JuicedUp.Common.Economy.Internal.Views;
using JuicedUp.Common.Economy.Public.Views;
using JuicedUp.Features.WeeklyMissions.Public;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace JuicedUp.Features.WeeklyMissions.Internal
{
	internal class DailyMissionView : MonoBehaviour, IDailyMissionView
	{
		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CActivateSetupDataState_003Ed__44 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskMethodBuilder _003C_003Et__builder;

			public DailyMissionView _003C_003E4__this;

			public CancellationToken token;

			private UniTask.Awaiter _003C_003Eu__1;

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

		[SerializeField]
		private Image _missionIconImage;

		[SerializeField]
		private TextMeshProUGUI[] _missionTitles;

		[SerializeField]
		private Image _missionProgressbar;

		[SerializeField]
		private TextMeshProUGUI _progressText;

		[SerializeField]
		private Button _claimButton;

		[SerializeField]
		private GameObject _locker;

		[Space]
		[SerializeField]
		private RewardView _energyReward;

		[SerializeField]
		private RewardView _missionReward;

		[Header("Locker Animation States")]
		[SerializeField]
		private Animation _lockerAnimation;

		[SerializeField]
		private AnimationClip _openLockerAnimationClip;

		[SerializeField]
		private AnimationClip _shakeLockerAnimationClip;

		[Header("Mission Animation States")]
		[SerializeField]
		private Animation _missionAnimation;

		[SerializeField]
		private AnimationClip _missionDefaultAnimationClip;

		[SerializeField]
		private AnimationClip _missionDefaultLockedAnimationClip;

		[SerializeField]
		private AnimationClip _missionReadyToClaimAnimationClip;

		[SerializeField]
		private AnimationClip _missionClaimedAnimationClip;

		[Header("SetupAnimation Settings:")]
		[SerializeField]
		private Ease _ease;

		[SerializeField]
		private int _vibrato;

		[SerializeField]
		private int _elasticity;

		[SerializeField]
		private float _duration;

		[SerializeField]
		private Vector3 _punchEndValue;

		private Tween _setupTween;

		public IRewardView EnergyReward => null;

		public IRewardView MissionReward => null;

		public event Action<IDailyMissionView> ClaimButtonClicked
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

		private void Awake()
		{
		}

		private void OnDestroy()
		{
		}

		public void SetLockerValue(bool value)
		{
		}

		public void SetNewParent(Transform parent)
		{
		}

		public void SetMissionImage(Sprite missionSprite)
		{
		}

		public void SetMissionName(string missionName)
		{
		}

		public void SetProgressText(string progressText)
		{
		}

		public void SetMissionProgress(float currentProgressValue, float maxProgressValue)
		{
		}

		public void SetMissionRewardActiveValue(bool value)
		{
		}

		public void ActivateLockerShake()
		{
		}

		public void ActivateLockerOpening()
		{
		}

		public void ActivateReadyToClaimState()
		{
		}

		public void ActivateClaimedState()
		{
		}

		public void ActivateDefaultState()
		{
		}

		public void ActivateDefaultLockedState()
		{
		}

		[AsyncStateMachine(typeof(_003CActivateSetupDataState_003Ed__44))]
		public UniTask ActivateSetupDataState(CancellationToken token)
		{
			return default(UniTask);
		}

		private void OnClaimButtonClicked()
		{
		}
	}
}
