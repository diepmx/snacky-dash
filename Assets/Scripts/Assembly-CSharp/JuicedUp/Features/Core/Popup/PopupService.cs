using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnityEngine;
using VContainer;

namespace JuicedUp.Features.Core.Popup
{
	public class PopupService : IPopupService, IDisposable
	{
		private class ActivePopupEntry
		{
			public BasePopupView View;

			public PopupRequest Request;

			public CancellationTokenSource Cts;

			public UniTaskCompletionSource<PopupButtonResult> Tcs;

			public float ShownAtTime;
		}

		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CHandleResultAsync_003Ed__34 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskMethodBuilder _003C_003Et__builder;

			public PopupService _003C_003E4__this;

			public ActivePopupEntry entry;

			public PopupButtonResult result;

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
		private struct _003CHideAsync_003Ed__21 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskMethodBuilder<PopupButtonResult> _003C_003Et__builder;

			public PopupId id;

			public PopupService _003C_003E4__this;

			private PopupButtonResult _003Cresult_003E5__2;

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
		private struct _003CPushAndShowAsync_003Ed__32 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskMethodBuilder<PopupButtonResult> _003C_003Et__builder;

			public PopupService _003C_003E4__this;

			public PopupRequest request;

			private UniTaskCompletionSource<PopupButtonResult> _003Ctcs_003E5__2;

			private ActivePopupEntry _003Centry_003E5__3;

			private object _003C_003E7__wrap3;

			private int _003C_003E7__wrap4;

			private UniTask.Awaiter _003C_003Eu__1;

			private UniTask<PopupButtonResult>.Awaiter _003C_003Eu__2;

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

		private readonly PopupRegistry _registry;

		private readonly PopupScheduler _scheduler;

		private readonly Transform _popupRoot;

		private readonly IObjectResolver _resolver;

		private readonly PopupPriorityQueue _queue;

		private readonly PopupHistory _history;

		private readonly List<ActivePopupEntry> _stack;

		private bool _disposed;

		public int ActivePopupCount => 0;

		public bool HasAnyActivePopup => false;

		public event Action<PopupId> OnPopupShown
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event Action<PopupId> OnPopupHidden
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public PopupService(IAssetLoader assetLoader, Transform popupRoot, IObjectResolver resolver)
		{
		}

		public UniTask<PopupButtonResult> ShowAsync(PopupId id, bool fadeIn = false, PopupPriority priority = PopupPriority.Normal, IPopupPayload payload = null)
		{
			return default(UniTask<PopupButtonResult>);
		}

		private UniTask<PopupButtonResult> ShowAsync(PopupRequest request)
		{
			return default(UniTask<PopupButtonResult>);
		}

		[AsyncStateMachine(typeof(_003CHideAsync_003Ed__21))]
		public UniTask<PopupButtonResult> HideAsync(PopupId id)
		{
			return default(UniTask<PopupButtonResult>);
		}

		public void Enqueue(PopupRequest request)
		{
		}

		public bool IsShowing(PopupId id)
		{
			return false;
		}

		public bool IsQueued(PopupId id)
		{
			return false;
		}

		public bool WasShownRecently(PopupId id, float withinSeconds)
		{
			return false;
		}

		public IReadOnlyList<PopupHistoryEntry> GetHistory()
		{
			return null;
		}

		public void RegisterScheduled(ScheduledPopupEntry entry)
		{
		}

		public void UnregisterScheduled(PopupId id)
		{
		}

		public void EvaluateScheduled(PopupContext ctx)
		{
		}

		public void EvaluateBestScheduled(PopupContext ctx)
		{
		}

		public void Dispose()
		{
		}

		[AsyncStateMachine(typeof(_003CPushAndShowAsync_003Ed__32))]
		private UniTask<PopupButtonResult> PushAndShowAsync(PopupRequest request)
		{
			return default(UniTask<PopupButtonResult>);
		}

		private void OnPopupResult(PopupButtonResult result)
		{
		}

		[AsyncStateMachine(typeof(_003CHandleResultAsync_003Ed__34))]
		private UniTask HandleResultAsync(ActivePopupEntry entry, PopupButtonResult result)
		{
			return default(UniTask);
		}

		public void DestroyPopup(PopupId id, float destroyDelay = 0f)
		{
		}

		private void ProcessNext()
		{
		}
	}
}
