using System;

namespace Voodoo.Live.Offers.Utility
{
	public class CooldownTracker
	{
		private int _cooldownDurationInHours;

		private DateTime _cooldownStartDate;

		public CooldownTracker(int cooldownDurationInHours)
		{
		}

		public bool IsInCooldown(DateTime currentTime, out string errorMessage)
		{
			errorMessage = null;
			return false;
		}

		public void SetCooldownStartDate(DateTime actionTime)
		{
		}

		public void SetCooldownDurationInHours(int duration)
		{
		}
	}
}
