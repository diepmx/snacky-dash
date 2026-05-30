using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using JuicedUp.Common.Config;
using UnityEngine;

namespace JuicedUp.Features.CloudContent
{
	public sealed class LevelPreloader : IDisposable
	{
		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CEnsureLevelReadyAsync_003Ed__12 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskMethodBuilder<LevelDataSO> _003C_003Et__builder;

			public LevelPreloader _003C_003E4__this;

			public int contentIndex;

			public CancellationToken ct;

			private UniTaskCompletionSource<LevelDataSO> _003Ctcs_003E5__2;

			private UniTask<LevelDataSO>.Awaiter _003C_003Eu__1;

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
		private struct _003CPreloadBatchAsync_003Ed__14 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskMethodBuilder _003C_003Et__builder;

			public LevelPreloader _003C_003E4__this;

			public CancellationToken ct;

			public int fromPlayerLevelIndex;

			public int batchSize;

			private CloudFunnelData _003Cfunnel_003E5__2;

			private int _003Ci_003E5__3;

			private UniTask<LevelDataSO>.Awaiter _003C_003Eu__1;

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
		private struct _003CRunBatchAsync_003Ed__15 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskVoidMethodBuilder _003C_003Et__builder;

			public LevelPreloader _003C_003E4__this;

			public int fromPlayerLevelIndex;

			public int batchSize;

			public CancellationToken ct;

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

		private readonly IFunnelLevelSource _funnelSource;

		private readonly RemoteConfigService _remoteConfigService;

		private readonly Dictionary<int, LevelDataSO> _buffer;

		private readonly Dictionary<int, UniTaskCompletionSource<LevelDataSO>> _inFlight;

		private readonly HashSet<int> _pinnedContentIndices;

		private CancellationTokenSource _backgroundCts;

		private bool _batchRunning;

		private readonly HashSet<int> _keepSet;

		private readonly List<int> _evictList;

		public LevelPreloader(IFunnelLevelSource funnelSource, RemoteConfigService remoteConfigService)
		{
		}

		public int ResolveContentIndex(int playerLevelIndex)
		{
			return 0;
		}

		public LevelDataSO TryGetBuffered(int contentIndex)
		{
			return null;
		}

		[AsyncStateMachine(typeof(_003CEnsureLevelReadyAsync_003Ed__12))]
		public UniTask<LevelDataSO> EnsureLevelReadyAsync(int contentIndex, CancellationToken ct)
		{
			return default(UniTask<LevelDataSO>);
		}

		public void CheckAndTriggerPreload(int currentPlayerLevelIndex)
		{
		}

		[AsyncStateMachine(typeof(_003CPreloadBatchAsync_003Ed__14))]
		public UniTask PreloadBatchAsync(int fromPlayerLevelIndex, int batchSize, CancellationToken ct)
		{
			return default(UniTask);
		}

		[AsyncStateMachine(typeof(_003CRunBatchAsync_003Ed__15))]
		private UniTaskVoid RunBatchAsync(int fromPlayerLevelIndex, int batchSize, CancellationToken ct)
		{
			return default(UniTaskVoid);
		}

		public void Pin(int contentIndex)
		{
		}

		public void Unpin(int contentIndex)
		{
		}

		public void Reset()
		{
		}

		public void Dispose()
		{
		}

		private void EvictOutsideWindow(int currentPlayerLevelIndex, CloudFunnelData funnel, int batchSize)
		{
		}

		private static void SafeDestroy(UnityEngine.Object obj)
		{
		}
	}
}
