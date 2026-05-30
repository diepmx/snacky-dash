using System;
using System.Collections.Generic;

namespace Voodoo.Sauce.Internal.Ads
{
	public class AdTimers
	{
		private Dictionary<string, DateTime> _startLoadingTimes;

		private Dictionary<string, TimeSpan> _loadingTimes;

		public void SetStartLoadingTime(AdUnits.AdUnit adUnit, bool isPrimary = true)
		{
		}

		public void SetEndLoadingTime(AdUnits.AdUnit adUnit, bool isPrimary = true)
		{
		}

		public void SetRestartLoadingTime(AdUnits.AdUnit adUnit, bool isPrimary = true)
		{
		}

		public TimeSpan GetLoadingTime(AdUnits.AdUnit adUnit, bool isPrimary = true)
		{
			return default(TimeSpan);
		}
	}
}
