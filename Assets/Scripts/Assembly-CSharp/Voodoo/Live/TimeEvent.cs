using System;

namespace Voodoo.Live
{
	public class TimeEvent : ICountdownProvider
	{
		private TimeEventStatus _status;

		private TimeSpan _span;

		public DateTime start;

		public DateTime stop;

		public TimeEventRecurrence recurrence;

		public TimeEventStatus Status => null;

		public TimeEvent(DateTime start, DateTime stop, TimeEventRecurrence recurrence)
		{
		}

		private void CheckStatus()
		{
		}

		public bool IsActive(DateTime now, out string error)
		{
			error = null;
			return false;
		}

		private bool IsInEventBoundaries(DateTime now)
		{
			return false;
		}

		public TimeSpan TimeLeft()
		{
			return default(TimeSpan);
		}
	}
}
