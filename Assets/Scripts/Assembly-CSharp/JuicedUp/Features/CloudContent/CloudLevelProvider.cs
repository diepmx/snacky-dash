using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using JuicedUp.Common.Config;
using JuicedUp.Features.Core;

namespace JuicedUp.Features.CloudContent
{
	public sealed class CloudLevelProvider : ILevelProvider, IDisposable
	{
		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CGetLevelAsync_003Ed__11 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskMethodBuilder<LevelResolution> _003C_003Et__builder;

			public CloudLevelProvider _003C_003E4__this;

			public int playerLevelIndex;

			public CancellationToken ct;

			private UniTask<LevelResolution>.Awaiter _003C_003Eu__1;

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
		private struct _003CPrewarmAsync_003Ed__18 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskMethodBuilder _003C_003Et__builder;

			public CloudLevelProvider _003C_003E4__this;

			public int fromPlayerLevelIndex;

			public CancellationToken ct;

			private UniTask.Awaiter _003C_003Eu__1;

			private UniTask<LevelDataSO>.Awaiter _003C_003Eu__2;

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
		private struct _003CResolveFromCloudOrFallbackAsync_003Ed__21 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskMethodBuilder<LevelResolution> _003C_003Et__builder;

			public CloudLevelProvider _003C_003E4__this;

			public int playerLevelIndex;

			public CancellationToken ct;

			private UniTask<LevelResolution>.Awaiter _003C_003Eu__1;

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

		private readonly ICloudContentService _cloudContentService;

		private readonly LevelPreloader _preloader;

		private readonly BakedCohortLevelProvider _bakedProvider;

		private readonly RemoteConfigService _remoteConfigService;

		private readonly CloudContentAnalytics _analytics;

		private readonly CancellationTokenSource _lifetimeCts;

		private readonly Dictionary<int, LevelResolution> _sessionCommits;

		private readonly Dictionary<int, int> _commitContentIndices;

		public string CohortName => null;

		public CloudLevelProvider(ICloudContentService cloudContentService, LevelPreloader preloader, BakedCohortLevelProvider bakedProvider, RemoteConfigService remoteConfigService, CloudContentAnalytics analytics)
		{
		}

		[AsyncStateMachine(typeof(_003CGetLevelAsync_003Ed__11))]
		public UniTask<LevelResolution> GetLevelAsync(int playerLevelIndex, CancellationToken ct)
		{
			return default(UniTask<LevelResolution>);
		}

		public LevelDifficulty GetDifficulty(int playerLevelIndex)
		{
			return default(LevelDifficulty);
		}

		public bool IsInLoop(int playerLevelIndex)
		{
			return false;
		}

		public int GetTotalContentLevels()
		{
			return 0;
		}

		public int GetGameLoop(int playerLevelIndex)
		{
			return 0;
		}

		public int GetOriginalLevel(int playerLevelIndex)
		{
			return 0;
		}

		public void NotifyLevelCompleted(int playerLevelIndex)
		{
		}

		[AsyncStateMachine(typeof(_003CPrewarmAsync_003Ed__18))]
		public UniTask PrewarmAsync(int fromPlayerLevelIndex, CancellationToken ct)
		{
			return default(UniTask);
		}

		public void Dispose()
		{
		}

		private bool TryGetActiveFunnel(out CloudFunnelData funnel)
		{
			funnel = default(CloudFunnelData);
			return false;
		}

		[AsyncStateMachine(typeof(_003CResolveFromCloudOrFallbackAsync_003Ed__21))]
		private UniTask<LevelResolution> ResolveFromCloudOrFallbackAsync(int playerLevelIndex, CancellationToken ct)
		{
			return default(UniTask<LevelResolution>);
		}

		private void TrackInitIfTerminal(CloudContentState state, string cohortName = "", int levelCount = 0)
		{
		}
	}
}
