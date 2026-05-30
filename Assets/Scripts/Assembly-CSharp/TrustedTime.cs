using System;
using JuicedUp.Common.Time;

public static class TrustedTime
{
	private const int MaxOfflineHours = 48;

	private const int RollbackToleranceSeconds = 60;

	private static void MarkTamper(LivesState s)
	{
	}

	public static DateTime GetTrustedUtcNow(LivesState livesState, IServerTimeProvider serverTime = null)
	{
		return default(DateTime);
	}

	public static void ResetTrusted(LivesState livesState)
	{
	}

	public static void CommitTrustedBase(LivesState livesState, DateTime trustedNowUtc, IServerTimeProvider serverTime = null)
	{
	}

	private static long ToUnixSeconds(DateTime utc)
	{
		return 0L;
	}
}
