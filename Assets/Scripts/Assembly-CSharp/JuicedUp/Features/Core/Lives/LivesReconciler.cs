using System;

namespace JuicedUp.Features.Core.Lives
{
	public static class LivesReconciler
	{
		public static void Reconcile(LivesState state, ref int currentLives, DateTime utcNow, Action<int, int> raiseLivesChanged, Action<long> raiseNextLifeChanged)
		{
		}

		public static int SecondsToNextLifeAt(LivesState state, int currentLives, DateTime utcNow)
		{
			return 0;
		}

		public static void ScheduleNextRegen(LivesState state, long nowSeconds)
		{
		}

		public static long ToUnixSeconds(DateTime utc)
		{
			return 0L;
		}
	}
}
