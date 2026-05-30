using System;

namespace JuicedUp.Common.Save
{
	[Serializable]
	public class LivesData
	{
		public int MaxLives;

		public int RegenSeconds;

		public long NextLifeAtUtc;

		public long TrustedBaseUtc;

		public long TrustedBaseDeviceUtc;

		public long LastTrustedNowUtc;

		public bool TamperFlag;

		public int SafeModeSecondsRemaining;

		public bool IsLevelSessionActive;

		public bool HasCompletedFirstRegen;

		public bool HasUsedFreeRefill;
	}
}
