using System;

namespace JuicedUp.Common.Time
{
	public interface IServerTimeProvider
	{
		DateTime UtcTime();

		DateTime LocalTime();

		void DebugAddDay(int days);

		void ResetDebugOffset();
	}
}
