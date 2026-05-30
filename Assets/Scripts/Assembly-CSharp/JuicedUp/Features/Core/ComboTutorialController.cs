using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using JuicedUp.Common.Config;
using JuicedUp.Core.Bootstrap;
using UnityEngine;

namespace JuicedUp.Features.Core
{
	public sealed class ComboTutorialController : IAsyncInitializable, IDisposable
	{
		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CShowAndResumeAsync_003Ed__13 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskVoidMethodBuilder _003C_003Et__builder;

			public ComboTutorialController _003C_003E4__this;

			public CancellationToken cancellationToken;

			private GameObject _003CtapToContinueLabel_003E5__2;

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

		private readonly IComboTutorialRepository _repository;

		private readonly RemoteConfigService _remoteConfig;

		private readonly SwipeController _swipeController;

		private readonly TutorialFocusService _focusService;

		private readonly CrateManager _crateManager;

		private readonly ComboTutorialView _popupPrefab;

		private readonly CancellationTokenSource _lifetimeCts;

		private ComboTutorialView _spawnedPopup;

		public ComboTutorialController(IComboTutorialRepository repository, RemoteConfigService remoteConfig, SwipeController swipeController, TutorialFocusService focusService, CrateManager crateManager, ComboTutorialView popupPrefab)
		{
		}

		public UniTask InitAsync(CancellationToken cancellationToken)
		{
			return default(UniTask);
		}

		internal static bool IsEligible(bool hasShown, int currentDisplayLevel, ComboTutorialConfig config)
		{
			return false;
		}

		private void HandleCrateCompleted(PillKind _)
		{
		}

		[AsyncStateMachine(typeof(_003CShowAndResumeAsync_003Ed__13))]
		private UniTaskVoid ShowAndResumeAsync(CancellationToken cancellationToken)
		{
			return default(UniTaskVoid);
		}

		private void DismissPopup()
		{
		}

		private static GameObject ResolveTapToContinueLabel(ComboTutorialView popupView)
		{
			return null;
		}

		public void Dispose()
		{
		}
	}
}
