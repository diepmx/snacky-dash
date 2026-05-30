using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using JuicedUp.Common.Economy.Public.Views;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace JuicedUp.Common.Economy.Internal.Views
{
	internal class RewardPopupView : MonoBehaviour, IRewardPopupView
	{
		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CHide_003Ed__22 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskMethodBuilder _003C_003Et__builder;

			public RewardPopupView _003C_003E4__this;

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

		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CShow_003Ed__21 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskMethodBuilder _003C_003Et__builder;

			public RewardPopupView _003C_003E4__this;

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
		private Button _tapToClaimButton;

		[SerializeField]
		private TextMeshProUGUI[] _popupTitles;

		[SerializeField]
		private RewardsContainer[] _rewardContainers;

		[Space]
		[SerializeField]
		private Animation _animation;

		[SerializeField]
		private AnimationClip _showAnimation;

		[SerializeField]
		private AnimationClip _hideAnimation;

		[field: Space]
		[field: SerializeField]
		public Transform NoAdsRewardFlyTarget { get; private set; }

		[field: SerializeField]
		public GameObject RewardParent { get; private set; }

		public Transform FreeRewardsContainer => null;

		public event Action TapToClaimButtonClicked
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

		[AsyncStateMachine(typeof(_003CShow_003Ed__21))]
		public UniTask Show(CancellationToken token)
		{
			return default(UniTask);
		}

		[AsyncStateMachine(typeof(_003CHide_003Ed__22))]
		public UniTask Hide(CancellationToken token)
		{
			return default(UniTask);
		}

		public void SetPopupTitle(string title)
		{
		}

		private Transform SelectFreeRewardsContainer()
		{
			return null;
		}

		private void DeactivateAllRewardContainers()
		{
		}

		private void OnTapToClaimButtonClicked()
		{
		}
	}
}
