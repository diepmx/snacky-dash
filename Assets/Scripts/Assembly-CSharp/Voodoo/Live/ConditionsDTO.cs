using System;
using System.Collections.Generic;
using Voodoo.Live.Offers;

namespace Voodoo.Live
{
	public class ConditionsDTO
	{
		public int capping;

		public int frequency;

		public int cooldownAfterPurchaseInHours;

		public DateTime startDate;

		public DateTime endDate;

		public ActiveTimeConfig activeTime;

		public List<DayOfWeek> day;

		public string[] tags;

		public int purchaseLimit;
	}
}
