using System.Collections.Generic;

namespace Voodoo.ADN.Internal
{
	internal class AdnAttributionData
	{
		public string Network;

		public string Campaign;

		public string CostType;

		public double? CostAmount;

		public string CostCurrency;

		public Dictionary<string, object> ToDictionary()
		{
			return null;
		}
	}
}
