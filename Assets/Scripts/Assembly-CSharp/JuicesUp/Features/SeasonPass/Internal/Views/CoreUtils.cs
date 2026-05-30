using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using DG.Tweening;
using UnityEngine;

namespace JuicesUp.Features.SeasonPass.Internal.Views
{
	public static class CoreUtils
	{
		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CPlayAndWaitForCompletion_003Ed__1 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskMethodBuilder _003C_003Et__builder;

			public Animator animator;

			public int hash;

			public CancellationToken ctoken;

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
		private struct _003CWaitForTapAsync_003Ed__0 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskMethodBuilder<Vector2> _003C_003Et__builder;

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

		[AsyncStateMachine(typeof(_003CWaitForTapAsync_003Ed__0))]
		public static UniTask<Vector2> WaitForTapAsync(CancellationToken token = default(CancellationToken))
		{
			return default(UniTask<Vector2>);
		}

		[AsyncStateMachine(typeof(_003CPlayAndWaitForCompletion_003Ed__1))]
		public static UniTask PlayAndWaitForCompletion(this Animator animator, int hash, CancellationToken ctoken)
		{
			return default(UniTask);
		}

		public static Tween WithCancellation(this Tween tween, CancellationToken token)
		{
			return null;
		}

		public static bool AreRotationsClose(this float yA, float yB, float tolerance = 5f)
		{
			return false;
		}

		public static void CanvasGroupActivate(this CanvasGroup canvasGroup, bool active)
		{
		}

		public static void DestroyEditorFriendly(this GameObject go)
		{
		}
	}
}
