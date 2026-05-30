using System;

namespace Voodoo.Live
{
	public class TimeEventRecurrence
	{
		public RecurrenceType type;

		public int repeatEvery;

		public DayOfWeek[] activeDays;

		public DateTime end;

		public bool CheckValidity(DateTime start, DateTime stop, out string error)
		{
			error = null;
			return false;
		}

		public bool IsInRecurrenceBoundaries(DateTime start, TimeSpan eventSpan, DateTime now, out string error)
		{
			error = null;
			return false;
		}

		public bool IsInActiveDay(DateTime now)
		{
			return false;
		}

		private bool IsDaySpecific(DateTime now)
		{
			return false;
		}

		public bool IsInActiveRecurrenceWeek(DateTime start, DateTime now)
		{
			return false;
		}

		private DateTime StartOfWeek(DateTime date)
		{
			return default(DateTime);
		}

		public int GetIntervals(DateTime start, DateTime stop)
		{
			return 0;
		}

		private TimeSpan GetSpan()
		{
			return default(TimeSpan);
		}

		public DateTime EndOfContiguousBlock(DateTime intervalStop, DateTime start, TimeSpan eventSpan)
		{
			return default(DateTime);
		}

		public DateTime GetCurrentIntervalStart(DateTime start, DateTime now)
		{
			return default(DateTime);
		}
	}
}
