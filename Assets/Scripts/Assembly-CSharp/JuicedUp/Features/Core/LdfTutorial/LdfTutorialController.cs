using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using JuicedUp.Core.Bootstrap;
using JuicedUp.Features.Core.Ingredients;
using JuicedUp.Features.Core.Popup;
using UnityEngine;

namespace JuicedUp.Features.Core.LdfTutorial
{
	public sealed class LdfTutorialController : IAsyncInitializable, IDisposable
	{
		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CInitAsync_003Ed__17 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskMethodBuilder _003C_003Et__builder;

			public CancellationToken cancellationToken;

			public LdfTutorialController _003C_003E4__this;

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
		private struct _003CShowPendingTutorialsAsync_003Ed__23 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskVoidMethodBuilder _003C_003Et__builder;

			public LdfTutorialController _003C_003E4__this;

			public CancellationToken cancellationToken;

			private int _003Ci_003E5__2;

			private IngredientType _003Ctype_003E5__3;

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

		private static readonly IngredientType[] TutorialDisplayOrder;

		private static readonly (IngredientType Type, string Title, string Description)[] DefaultCopy;

		private readonly IPopupService _popupService;

		private readonly ILdfTutorialRepository _repository;

		private readonly IEnumerable<ILdfTutorialCondition> _conditions;

		private readonly LevelController _levelController;

		private readonly IngredientUnlockConfig _config;

		private readonly LoadingScreenController _loadingScreenController;

		private readonly SwipeController _swipeController;

		private readonly IGameStateReader _gameStateReader;

		private readonly IGameStateEvents _gameStateEvents;

		private readonly CancellationTokenSource _lifetimeCts;

		private List<IngredientType> _pendingTypesToShow;

		private bool _isLoadingHidden;

		private bool _isLevelPlayable;

		private bool _isShowingPendingTutorials;

		public LdfTutorialController(IPopupService popupService, ILdfTutorialRepository repository, IEnumerable<ILdfTutorialCondition> conditions, LevelController levelController, IngredientUnlockConfig config, LoadingScreenController loadingScreenController, SwipeController swipeController, IGameStateReader gameStateReader, IGameStateEvents gameStateEvents)
		{
		}

		[AsyncStateMachine(typeof(_003CInitAsync_003Ed__17))]
		public UniTask InitAsync(CancellationToken cancellationToken)
		{
			return default(UniTask);
		}

		public void Dispose()
		{
		}

		private void UnregisterGatingListeners()
		{
		}

		private void OnLoadingScreenHidden()
		{
		}

		private void OnGameStateChanged(GameState state, DefeatType _)
		{
		}

		private void TryShowPendingTutorials()
		{
		}

		[AsyncStateMachine(typeof(_003CShowPendingTutorialsAsync_003Ed__23))]
		private UniTaskVoid ShowPendingTutorialsAsync(CancellationToken cancellationToken)
		{
			return default(UniTaskVoid);
		}

		private void ResolveStrings(IngredientType type, out string title, out string description)
		{
			title = null;
			description = null;
		}

		private void ResolveIcon(IngredientType type, out Sprite icon)
		{
			icon = null;
		}

		private static int GetTutorialSortIndex(IngredientType type)
		{
			return 0;
		}

		private static HashSet<IngredientType> BuildAdmissionFromLevel(LevelDataSO level)
		{
			return null;
		}
	}
}
