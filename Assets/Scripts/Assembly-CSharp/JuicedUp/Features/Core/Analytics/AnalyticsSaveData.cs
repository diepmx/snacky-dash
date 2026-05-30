using System;

namespace JuicedUp.Features.Core.Analytics
{
	[Serializable]
	public class AnalyticsSaveData
	{
		public int WinStreak;

		public int MaxWinStreak;

		public long InstallDateTicks;

		public int NumberOfShopOpen;

		public bool IsPayerUser;
	}
}
