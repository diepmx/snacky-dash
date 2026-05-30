using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Voodoo.Sauce.Tools.AccessButton
{
	public class BubbleButton : MonoBehaviour, IPointerDownHandler, IEventSystemHandler, IPointerUpHandler, IBeginDragHandler, IDragHandler, IEndDragHandler
	{
		[CompilerGenerated]
		private sealed class _003CCheckOrientation_003Ed__27 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public BubbleButton _003C_003E4__this;

			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			[DebuggerHidden]
			public _003CCheckOrientation_003Ed__27(int _003C_003E1__state)
			{
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}
		}

		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CEndOfDragBehavior_003Ed__31 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public BubbleButton _003C_003E4__this;

			private float _003Ctime_003E5__2;

			private TaskAwaiter _003C_003Eu__1;

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
		private struct _003CHideButtonUI_003Ed__29 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public BubbleButton _003C_003E4__this;

			private TaskAwaiter _003C_003Eu__1;

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
		private struct _003CShowButtonUI_003Ed__30 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public BubbleButton _003C_003E4__this;

			private TaskAwaiter _003C_003Eu__1;

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

		public bool forceUpsideDown;

		public CanvasGroup canvasGroup;

		public RectTransform parentRT;

		public RectTransform myRect;

		public RectTransform hideArea;

		private bool _isUsable;

		private const float MAXSize = 1.5f;

		private const float DistanceHide = -1200f;

		private bool _isDragged;

		private Vector3 _startMousePos;

		private Vector3 _startPos;

		private bool _isXRestrict;

		private bool _isYRestrict;

		private float _fakeX;

		private float _fakeY;

		private float _halfWidth;

		private float _halfHeight;

		private Vector3 _endLerpPosition;

		private Vector3 _startLerpPosition;

		private const float DurationLerp = 0.1f;

		private EventSystem _eventSystem;

		private static CancellationTokenSource _mouseDownCts;

		private Coroutine _refreshCoroutine;

		private const string TAG = "AccessButton";

		private void Start()
		{
		}

		private void OnEnable()
		{
		}

		private void OnDisable()
		{
		}

		[IteratorStateMachine(typeof(_003CCheckOrientation_003Ed__27))]
		private IEnumerator CheckOrientation()
		{
			return null;
		}

		private void SetUpLerp()
		{
		}

		[AsyncStateMachine(typeof(_003CHideButtonUI_003Ed__29))]
		private void HideButtonUI()
		{
		}

		[AsyncStateMachine(typeof(_003CShowButtonUI_003Ed__30))]
		private void ShowButtonUI()
		{
		}

		[AsyncStateMachine(typeof(_003CEndOfDragBehavior_003Ed__31))]
		private void EndOfDragBehavior()
		{
		}

		private void Resize()
		{
		}

		private void KeepInsideScreen()
		{
		}

		private void GroupVisibility(bool show)
		{
		}

		private void OnClick()
		{
		}

		public void OnPointerDown(PointerEventData ped)
		{
		}

		public void OnPointerUp(PointerEventData ped)
		{
		}

		public void OnBeginDrag(PointerEventData eventData)
		{
		}

		public void OnDrag(PointerEventData eventData)
		{
		}

		public void OnEndDrag(PointerEventData eventData)
		{
		}
	}
}
