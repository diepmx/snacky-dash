using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace Voodoo.Sauce.Internal.Analytics.PerformanceTracking
{
	internal class FrameCounterService
	{
		[CompilerGenerated]
		private sealed class _003CUpdateLoop_003Ed__9 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public FrameCounterService _003C_003E4__this;

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
			public _003CUpdateLoop_003Ed__9(int _003C_003E1__state)
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

		private readonly HashSet<FrameCounter> _counters;

		private Coroutine _updateCoroutine;

		private bool _skipNextFrame;

		private const float BadFrameThreshold = 0.050000004f;

		private const float TerribleFrameThreshold = 1f / 6f;

		internal FrameCounterService()
		{
		}

		private void OnApplicationPause(bool pauseStatus)
		{
		}

		internal void Register(FrameCounter counter)
		{
		}

		internal void Unregister(FrameCounter counter)
		{
		}

		[IteratorStateMachine(typeof(_003CUpdateLoop_003Ed__9))]
		private IEnumerator UpdateLoop()
		{
			return null;
		}

		internal void Dispose()
		{
		}
	}
}
