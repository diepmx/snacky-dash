using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using JuicedUp.Core.Bootstrap;
using JuicedUp.Features.Core.Popup;

namespace JuicedUp.Features.Core.Ingredients
{
	public class IngredientUnlockPopupService : IAsyncInitializable, IDisposable
	{
		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CShowPopupIfNeededAsync_003Ed__12 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskVoidMethodBuilder _003C_003Et__builder;

			public IngredientUnlockPopupService _003C_003E4__this;

			private IngredientDefinition _003Cdefinition_003E5__2;

			private UniTask<PopupButtonResult>.Awaiter _003C_003Eu__1;

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

		private readonly IPopupService _popupService;

		private readonly IngredientUnlockResolver _resolver;

		private readonly IIngredientUnlockPopupStateRepository _stateRepository;

		private readonly Loading _loading;

		private readonly IGameStateReader _gameStateReader;

		private readonly IGameStateEvents _gameStateEvents;

		private bool _flowInProgress;

		private CancellationTokenSource _lifetimeCts;

		public IngredientUnlockPopupService(IPopupService popupService, IngredientUnlockResolver resolver, IIngredientUnlockPopupStateRepository stateRepository, Loading loading, IGameStateReader gameStateReader, IGameStateEvents gameStateEvents)
		{
		}

		public UniTask InitAsync(CancellationToken cancellationToken)
		{
			return default(UniTask);
		}

		public void Dispose()
		{
		}

		private void OnStartingGame()
		{
		}

		[AsyncStateMachine(typeof(_003CShowPopupIfNeededAsync_003Ed__12))]
		private UniTaskVoid ShowPopupIfNeededAsync(CancellationToken ct)
		{
			return default(UniTaskVoid);
		}
	}
}
