using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class WinStreakMultiplierBar : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CAnimateLooseIndex_003Ed__26 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public WinStreakMultiplierBar _003C_003E4__this;

		public int fromIndex;

		private int _003Ci_003E5__2;

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
		public _003CAnimateLooseIndex_003Ed__26(int _003C_003E1__state)
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

	[CompilerGenerated]
	private sealed class _003CAnimateLooseIndexLoop_003Ed__27 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public WinStreakMultiplierBar _003C_003E4__this;

		public int fromIndex;

		private int _003CsaveIndex_003E5__2;

		private int _003Ci_003E5__3;

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
		public _003CAnimateLooseIndexLoop_003Ed__27(int _003C_003E1__state)
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

	[CompilerGenerated]
	private sealed class _003CAnimateWinIndex_003Ed__30 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public WinStreakMultiplierBar _003C_003E4__this;

		public int index;

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
		public _003CAnimateWinIndex_003Ed__30(int _003C_003E1__state)
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

	private static readonly int Loose;

	private static readonly int Win;

	private const string LooseAnimationTrigger = "loose";

	private const string WinAnimationTrigger = "win";

	[SerializeField]
	private Transform _parent;

	[SerializeField]
	private GameObject _enter;

	[SerializeField]
	private GameObject _selectedEnter;

	[SerializeField]
	private GameObject _failEnter;

	[SerializeField]
	private GameObject _middle;

	[SerializeField]
	private GameObject _selectedMiddle;

	[SerializeField]
	private GameObject _end;

	[SerializeField]
	private GameObject _selectedEnd;

	[SerializeField]
	private RectTransform _cupRT;

	[SerializeField]
	private RectTransform _cupIcon;

	[SerializeField]
	private List<Transform> _cupWayPoints;

	[SerializeField]
	private Animator _cupAnimator;

	[SerializeField]
	private bool _looseScreeView;

	[SerializeField]
	private Image _icon;

	[SerializeField]
	private Sprite _cupSprite;

	[SerializeField]
	private Sprite _starSprite;

	private IEnumerator looseLoopingCoroutine;

	private int[] _multiplierValues;

	public virtual void SetIndex(int index, bool setTokenPos = true)
	{
	}

	public void AnimateWin(int index)
	{
	}

	public void AnimateLoose(int fromIndex, bool loopAnimation = false)
	{
	}

	public void OnInfoButtonPressed()
	{
	}

	[IteratorStateMachine(typeof(_003CAnimateLooseIndex_003Ed__26))]
	private IEnumerator AnimateLooseIndex(int fromIndex)
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003CAnimateLooseIndexLoop_003Ed__27))]
	private IEnumerator AnimateLooseIndexLoop(int fromIndex)
	{
		return null;
	}

	public void SetCupPos(int index)
	{
	}

	public void ResetCup(int index)
	{
	}

	[IteratorStateMachine(typeof(_003CAnimateWinIndex_003Ed__30))]
	private IEnumerator AnimateWinIndex(int index, bool isWin)
	{
		return null;
	}
}
