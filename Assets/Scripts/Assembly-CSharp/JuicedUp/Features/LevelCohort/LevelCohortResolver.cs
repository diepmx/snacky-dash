using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using JuicedUp.Common.Config;
using JuicedUp.Core.Bootstrap;
using JuicedUp.Features.Core;

namespace JuicedUp.Features.LevelCohort
{
	public class LevelCohortResolver : IAsyncInitializable
	{
		[CompilerGenerated]
		private sealed class _003C_003Ec__DisplayClass6_0
		{
			public LevelCohortResolver _003C_003E4__this;

			public Action handler;

			public UniTaskCompletionSource taskCompletionSource;

			public CancellationToken cancellationToken;

			internal void _003CInitAsync_003Eb__0()
			{
			}

			internal void _003CInitAsync_003Eb__1()
			{
			}
		}

		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CInitAsync_003Ed__6 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskMethodBuilder _003C_003Et__builder;

			public LevelCohortResolver _003C_003E4__this;

			public CancellationToken cancellationToken;

			private _003C_003Ec__DisplayClass6_0 _003C_003E8__1;

			private CancellationTokenRegistration _003Cregistration_003E5__2;

			private object _003C_003E7__wrap2;

			private int _003C_003E7__wrap3;

			private UniTask.Awaiter _003C_003Eu__1;

			private ValueTaskAwaiter _003C_003Eu__2;

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
		private struct _003CResolveAsync_003Ed__7 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskMethodBuilder _003C_003Et__builder;

			public LevelCohortResolver _003C_003E4__this;

			public CancellationToken cancellationToken;

			private string _003CdefaultName_003E5__2;

			private string _003CcohortName_003E5__3;

			private UniTask<LevelCohortSO>.Awaiter _003C_003Eu__1;

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

		public static string LevelCohortResourcesPath;

		public static string LevelCohortEditorPath;

		private readonly LevelCohortBindings _bindings;

		private readonly RemoteConfigService _remoteConfig;

		private readonly IAssetLoader _assetLoader;

		public LevelCohortResolver(LevelCohortBindings bindings, RemoteConfigService remoteConfig, IAssetLoader assetLoader)
		{
		}

		[AsyncStateMachine(typeof(_003CInitAsync_003Ed__6))]
		public UniTask InitAsync(CancellationToken cancellationToken)
		{
			return default(UniTask);
		}

		[AsyncStateMachine(typeof(_003CResolveAsync_003Ed__7))]
		private UniTask ResolveAsync(CancellationToken cancellationToken)
		{
			return default(UniTask);
		}

		private static string BuildKey(string name)
		{
			return null;
		}

		private static string BuildKeyEditor(string name)
		{
			return null;
		}
	}
}
