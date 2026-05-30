using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

namespace Voodoo.Sauce.Internal.DebugScreen
{
	public abstract class DebugAdStateBadge : MonoBehaviour
	{
		[CompilerGenerated]
		private sealed class _003CRefreshPeriodically_003Ed__9 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public DebugAdStateBadge _003C_003E4__this;

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
			public _003CRefreshPeriodically_003Ed__9(int _003C_003E1__state)
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

		[SerializeField]
		private GameObject badgeObject;

		[SerializeField]
		private Image stateObject;

		private Coroutine _refreshCoroutine;

		protected abstract bool IsEnabled();

		protected abstract Color StateColor();

		protected virtual void Awake()
		{
		}

		protected void UpdateVisibility()
		{
		}

		private void OnEnable()
		{
		}

		private void OnDisable()
		{
		}

		[IteratorStateMachine(typeof(_003CRefreshPeriodically_003Ed__9))]
		private IEnumerator RefreshPeriodically()
		{
			return null;
		}
	}
}
