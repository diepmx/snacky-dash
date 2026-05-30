using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace JuicedUp.Features.Core
{
	public class CrateProgressTracker
	{
		[CompilerGenerated]
		private sealed class _003CEnumerateCratesInPriorityOrder_003Ed__20 : IEnumerable<(CrateColumn, CrateData)>, IEnumerable, IEnumerator<(CrateColumn, CrateData)>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private (CrateColumn column, CrateData crate) _003C_003E2__current;

			private int _003C_003El__initialThreadId;

			public CrateProgressTracker _003C_003E4__this;

			private List<CrateColumn>.Enumerator _003C_003E7__wrap1;

			private CrateColumn _003Ccolumn_003E5__3;

			private List<CrateData>.Enumerator _003C_003E7__wrap3;

			(CrateColumn, CrateData) IEnumerator<(CrateColumn, CrateData)>.Current
			{
				[DebuggerHidden]
				get
				{
					return default((CrateColumn, CrateData));
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
			public _003CEnumerateCratesInPriorityOrder_003Ed__20(int _003C_003E1__state)
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

			private void _003C_003Em__Finally1()
			{
			}

			private void _003C_003Em__Finally2()
			{
			}

			private void _003C_003Em__Finally3()
			{
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}

			[DebuggerHidden]
			IEnumerator<(CrateColumn, CrateData)> IEnumerable<(CrateColumn, CrateData)>.GetEnumerator()
			{
				return null;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return null;
			}
		}

		private readonly List<CrateColumn> _columns;

		private bool _canUseCannonCached;

		private List<CrateDeliverPoint> _deliveryPoints;

		public Dictionary<PillKind, int> TailColorCount { get; private set; }

		public CrateProgressTracker(List<CrateColumn> columns)
		{
		}

		public void SetDeliveryPoints(List<CrateDeliverPoint> deliveryPoints)
		{
		}

		public void UpdateTailColors(Dictionary<PillKind, int> colors)
		{
		}

		public void Refresh()
		{
		}

		public int GetTotalCrateCount()
		{
			return 0;
		}

		public int GetTotalRequiredAllCrates()
		{
			return 0;
		}

		public int GetTotalRemainingToDeliverRaw()
		{
			return 0;
		}

		public bool CanStillDeliverInThisColumn(CrateColumn column)
		{
			return false;
		}

		public bool WillChainContinue(CrateColumn column)
		{
			return false;
		}

		public bool IsLastColumnFinishableFromPoint(int pointIndex)
		{
			return false;
		}

		public List<CrateDeliverPoint> GetPotentialDeliveryPoints(bool requireEnoughToFill = false)
		{
			return null;
		}

		public bool CanUseCannon(bool requireEnoughToFill = false)
		{
			return false;
		}

		public bool RefreshCannonAvailability(bool highlightOnlyIfEnoughToFill)
		{
			return false;
		}

		[IteratorStateMachine(typeof(_003CEnumerateCratesInPriorityOrder_003Ed__20))]
		public IEnumerable<(CrateColumn, CrateData)> EnumerateCratesInPriorityOrder()
		{
			return null;
		}

		private bool ColumnHasRemainingWork(int colIndex)
		{
			return false;
		}

		private bool CanFinishWholeColumnWithCurrentTail(int colIndex)
		{
			return false;
		}
	}
}
