using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using JuicedUp.Core.Bootstrap;
using JuicedUp.Features.Core;
using JuicedUp.Features.LoseTutorial.Config;
using UnityEngine;

namespace JuicedUp.Features.LoseTutorial
{
	public sealed class LoseTutorialController : IAsyncInitializable, IDisposable
	{
		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CShowPopupAsync_003Ed__16 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskMethodBuilder _003C_003Et__builder;

			public LoseTutorialController _003C_003E4__this;

			public CancellationToken cancellationToken;

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
		private struct _003CTryShowAsync_003Ed__13 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskMethodBuilder<bool> _003C_003Et__builder;

			public LoseTutorialController _003C_003E4__this;

			public CancellationToken cancellationToken;

			private CancellationTokenSource _003ClinkedCts_003E5__2;

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

		private const float TapToContinueDelaySeconds = 2f;

		private readonly ILoseTutorialRepository _repository;

		private readonly LoseTutorialConfigSO _config;

		private readonly SwipeController _swipeController;

		private readonly TutorialFocusService _focusService;

		private readonly LoseTutorialView _popupPrefab;

		private readonly CancellationTokenSource _lifetimeCts;

		private LoseTutorialView _spawnedPopup;

		private GameObject _tapToContinueLabel;

		public bool ShouldGiveFreeEgp => false;

		public LoseTutorialController(ILoseTutorialRepository repository, LoseTutorialConfigSO config, SwipeController swipeController, TutorialFocusService focusService, LoseTutorialView popupPrefab)
		{
		}

		public UniTask InitAsync(CancellationToken cancellationToken)
		{
			return default(UniTask);
		}

		[AsyncStateMachine(typeof(_003CTryShowAsync_003Ed__13))]
		public UniTask<bool> TryShowAsync(CancellationToken cancellationToken)
		{
			return default(UniTask<bool>);
		}

		private bool IsPopupEligible()
		{
			return false;
		}

		private bool IsTargetLevel()
		{
			return false;
		}

		[AsyncStateMachine(typeof(_003CShowPopupAsync_003Ed__16))]
		private UniTask ShowPopupAsync(CancellationToken cancellationToken)
		{
			return default(UniTask);
		}

		private void DismissPopup()
		{
		}

		private static GameObject ResolveTapToContinueLabel(LoseTutorialView popupView)
		{
			return null;
		}

		public void Dispose()
		{
		}
	}
}
