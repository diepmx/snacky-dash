using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

namespace Voodoo.Sauce.Common.Utils
{
	public class LandscapePadding : MonoBehaviour
	{
		[CompilerGenerated]
		private sealed class _003CCheckOrientation_003Ed__9 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public LandscapePadding _003C_003E4__this;

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
			public _003CCheckOrientation_003Ed__9(int _003C_003E1__state)
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

		public LandscapePaddingData preset;

		[Tooltip("If preset is filled, this value will not be used.")]
		public RectOffset landscapePadding;

		private RectOffset _defaultPadding;

		private bool _isLandscape;

		private LayoutGroup _layoutGroup;

		private Coroutine _refreshCoroutine;

		private void Awake()
		{
		}

		private void OnEnable()
		{
		}

		private void OnDisable()
		{
		}

		[IteratorStateMachine(typeof(_003CCheckOrientation_003Ed__9))]
		private IEnumerator CheckOrientation()
		{
			return null;
		}

		private bool IsLandscape()
		{
			return false;
		}

		private void AddPadding()
		{
		}

		private void RemovePadding()
		{
		}
	}
}
