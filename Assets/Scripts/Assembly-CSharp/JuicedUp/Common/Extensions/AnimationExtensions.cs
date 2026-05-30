using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

namespace JuicedUp.Common.Extensions
{
	public static class AnimationExtensions
	{
		[CompilerGenerated]
		private sealed class _003C_003Ec__DisplayClass0_0
		{
			public Animation animation;

			internal bool _003CPlayAsync_003Eb__0()
			{
				return false;
			}
		}

		[CompilerGenerated]
		private sealed class _003C_003Ec__DisplayClass2_0
		{
			public UniTaskCompletionSource tcs;
		}

		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CPlayAsync_003Ed__0 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskMethodBuilder _003C_003Et__builder;

			public Animation animation;

			public string animationName;

			public bool sampleFirstFrame;

			public CancellationToken token;

			private _003C_003Ec__DisplayClass0_0 _003C_003E8__1;

			public bool disableOnStop;

			private UniTask<bool>.Awaiter _003C_003Eu__1;

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
		private struct _003CPlayAsync_003Ed__1 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskMethodBuilder _003C_003Et__builder;

			public PlayableDirector playableDirector;

			public TimelineAsset newTimelineAsset;

			public CancellationToken token;

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
		private struct _003CPlayAsync_003Ed__2 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskMethodBuilder _003C_003Et__builder;

			public PlayableDirector playableDirector;

			public CancellationToken token;

			private _003C_003Ec__DisplayClass2_0 _003C_003E8__1;

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
		private struct _003CPlayAsync_003Ed__3 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskMethodBuilder _003C_003Et__builder;

			public Animator animator;

			public int layerIndex;

			public int stateHash;

			public float normalizedTransitionDuration;

			public CancellationToken token;

			private UniTask<bool>.Awaiter _003C_003Eu__1;

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

		[AsyncStateMachine(typeof(_003CPlayAsync_003Ed__0))]
		public static UniTask PlayAsync(this Animation animation, string animationName, bool disableOnStop = true, bool sampleFirstFrame = true, CancellationToken token = default(CancellationToken))
		{
			return default(UniTask);
		}

		[AsyncStateMachine(typeof(_003CPlayAsync_003Ed__1))]
		public static UniTask PlayAsync(this PlayableDirector playableDirector, TimelineAsset newTimelineAsset, CancellationToken token)
		{
			return default(UniTask);
		}

		[AsyncStateMachine(typeof(_003CPlayAsync_003Ed__2))]
		public static UniTask PlayAsync(this PlayableDirector playableDirector, CancellationToken token)
		{
			return default(UniTask);
		}

		[AsyncStateMachine(typeof(_003CPlayAsync_003Ed__3))]
		public static UniTask PlayAsync(this Animator animator, int stateHash, int layerIndex = 0, float normalizedTransitionDuration = 0f, CancellationToken token = default(CancellationToken))
		{
			return default(UniTask);
		}
	}
}
