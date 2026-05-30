using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using JuicedUp.Common.Config;
using JuicedUp.Features.Core;
using JuicedUp.Features.Core.Home;
using JuicedUp.Features.Core.Lives;
using UnityEngine.SceneManagement;
using VContainer.Unity;

namespace JuicedUp.Core.Bootstrap
{
	public sealed class MainEntryPoint : IAsyncStartable, IDisposable
	{
		[CompilerGenerated]
		private sealed class _003C_003Ec__DisplayClass13_0
		{
			public UniTaskCompletionSource hidden;
		}

		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CHideLoaderAndReportAsync_003Ed__13 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskMethodBuilder _003C_003Et__builder;

			public MainEntryPoint _003C_003E4__this;

			private _003C_003Ec__DisplayClass13_0 _003C_003E8__1;

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
		private struct _003CStartAsync_003Ed__12 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskMethodBuilder _003C_003Et__builder;

			public MainEntryPoint _003C_003E4__this;

			public CancellationToken cancellationToken;

			private CancellationToken _003ChomeToken_003E5__2;

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

		private const string FirstLaunchKey = "FirstLaunchDone";

		private readonly ILifetimeBootstrapOrchestrator _orchestrator;

		private readonly RemoteConfigService _remoteConfig;

		private readonly Loading _loading;

		private readonly IHomePanel _homePanel;

		private readonly TopHUDPanel _topHUDPanel;

		private readonly IGameStateWriter _gameStateWriter;

		private readonly LoadingScreenController _loadingScreenController;

		private readonly GameInteractableReporter _reporter;

		private readonly LivesService _livesService;

		private CancellationTokenSource _homeCts;

		public MainEntryPoint(ILifetimeBootstrapOrchestrator orchestrator, RemoteConfigService remoteConfig, Loading loading, IHomePanel homePanel, TopHUDPanel topHUDPanel, IGameStateWriter gameStateWriter, LoadingScreenController loadingScreenController, GameInteractableReporter reporter, LivesService livesService)
		{
		}

		[AsyncStateMachine(typeof(_003CStartAsync_003Ed__12))]
		public UniTask StartAsync(CancellationToken cancellationToken)
		{
			return default(UniTask);
		}

		[AsyncStateMachine(typeof(_003CHideLoaderAndReportAsync_003Ed__13))]
		private UniTask HideLoaderAndReportAsync()
		{
			return default(UniTask);
		}

		private void OnSceneLoaded(Scene scene, LoadSceneMode loadSceneMode)
		{
		}

		public void Dispose()
		{
		}
	}
}
