using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace Voodoo.Sauce.Internal.Ads
{
	internal class AudioAdsGracePeriodRunner : MonoBehaviour
	{
		[CompilerGenerated]
		private sealed class _003CRefreshPeriodically_003Ed__4 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public AudioAdsGracePeriodRunner _003C_003E4__this;

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
			public _003CRefreshPeriodically_003Ed__4(int _003C_003E1__state)
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

		private AudioAdsGracePeriod _gracePeriod;

		private Coroutine _refreshCoroutine;

		private void OnEnable()
		{
		}

		private void OnDisable()
		{
		}

		[IteratorStateMachine(typeof(_003CRefreshPeriodically_003Ed__4))]
		private IEnumerator RefreshPeriodically()
		{
			return null;
		}

		internal void Set(AudioAdsGracePeriod gracePeriod)
		{
		}
	}
}
