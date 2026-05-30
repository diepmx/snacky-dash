using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using JuicedUp.Features.Core.Layout;
using UnityEngine;

namespace JuicedUp.Features.Boosters.Shuffle
{
	public sealed class ShuffleVortexVfxController : IShuffleVortexVfxController, IDisposable
	{
		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CPlayAsync_003Ed__7 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskMethodBuilder _003C_003Et__builder;

			public ShuffleVortexVfxController _003C_003E4__this;

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

		private readonly ParticleSystem _vfxPrefab;

		private readonly LevelCameraFitter _levelCameraFitter;

		private readonly float _preShuffleDelaySeconds;

		private ParticleSystem _spawnedInstance;

		private CancellationTokenSource _activePlayCts;

		private bool _disposed;

		public ShuffleVortexVfxController(ParticleSystem vfxPrefab, LevelCameraFitter levelCameraFitter, float preShuffleDelaySeconds)
		{
		}

		[AsyncStateMachine(typeof(_003CPlayAsync_003Ed__7))]
		public UniTask PlayAsync(CancellationToken cancellationToken)
		{
			return default(UniTask);
		}

		public void Dispose()
		{
		}

		private void EnsureSpawned()
		{
		}

		private void DestroySpawned()
		{
		}

		private void CancelActivePlay()
		{
		}

		private void StopIfAlive()
		{
		}

		private void SnapToLevelBoundsCenter()
		{
		}
	}
}
