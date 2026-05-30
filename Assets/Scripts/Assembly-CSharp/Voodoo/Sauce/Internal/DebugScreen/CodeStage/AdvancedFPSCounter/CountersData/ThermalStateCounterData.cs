using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using Voodoo.Sauce.ThermalState;

namespace Voodoo.Sauce.Internal.DebugScreen.CodeStage.AdvancedFPSCounter.CountersData
{
	[Serializable]
	public class ThermalStateCounterData : UpdatableCounterData
	{
		[CompilerGenerated]
		private sealed class _003CUpdateCounter_003Ed__7 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public ThermalStateCounterData _003C_003E4__this;

			private float _003CpreviousUpdateTime_003E5__2;

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
			public _003CUpdateCounter_003Ed__7(int _003C_003E1__state)
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

		private const string TextStart = "<color=#{0}>";

		private const string TextEnd = "</color>";

		[CanBeNull]
		internal static ThermalStateService ThermalStateService => null;

		internal ThermalStateCounterData()
		{
		}

		protected override bool HasData()
		{
			return false;
		}

		protected override void CacheCurrentColor()
		{
		}

		[IteratorStateMachine(typeof(_003CUpdateCounter_003Ed__7))]
		protected override IEnumerator UpdateCounter()
		{
			return null;
		}

		internal override void UpdateValue(bool force)
		{
		}
	}
}
