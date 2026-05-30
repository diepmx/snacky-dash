using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;

public class UIAnimation : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CiWaitAndTrigger_003Ed__10 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public UIAnimation _003C_003E4__this;

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
		public _003CiWaitAndTrigger_003Ed__10(int _003C_003E1__state)
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

	public float Delay;

	public float Duration;

	public bool IgnoreTimeScale;

	public List<AnimatedProperties> Animations;

	private RectTransform rect;

	public UnityEvent OnStart;

	public UnityEvent OnComplete;

	private Sequence sequence;

	private IEnumerator WaitAndTrigger;

	private void OnEnable()
	{
	}

	[IteratorStateMachine(typeof(_003CiWaitAndTrigger_003Ed__10))]
	private IEnumerator iWaitAndTrigger()
	{
		return null;
	}

	private void OnDisable()
	{
	}

	public void ForceDisable()
	{
	}
}
