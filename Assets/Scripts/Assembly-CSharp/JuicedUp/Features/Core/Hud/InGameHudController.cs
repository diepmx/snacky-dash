using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using JuicedUp.Core.Bootstrap;
using JuicedUp.Features.Core.Popup;

namespace JuicedUp.Features.Core.Hud
{
	public class InGameHudController : IAsyncInitializable, IDisposable
	{
		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CShowSettingsPopupAsync_003Ed__12 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskMethodBuilder _003C_003Et__builder;

			public InGameHudController _003C_003E4__this;

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

		private readonly InGameHudView _view;

		private readonly Loading _loading;

		private readonly IPopupService _popupService;

		private readonly CrateManager _crateManager;

		private readonly PillManager _pillManager;

		private readonly SwipeController _swipeController;

		private readonly IGameStateReader _gameStateReader;

		private bool _settingsShowing;

		public InGameHudController(InGameHudView view, Loading loading, IPopupService popupService, CrateManager crateManager, PillManager pillManager, SwipeController swipeController, IGameStateReader gameStateReader)
		{
		}

		public UniTask InitAsync(CancellationToken cancellationToken)
		{
			return default(UniTask);
		}

		public void Dispose()
		{
		}

		private void ShowSettingsPopup()
		{
		}

		[AsyncStateMachine(typeof(_003CShowSettingsPopupAsync_003Ed__12))]
		private UniTask ShowSettingsPopupAsync()
		{
			return default(UniTask);
		}

		private void ExceptionHandler(Exception exception)
		{
		}
	}
}
