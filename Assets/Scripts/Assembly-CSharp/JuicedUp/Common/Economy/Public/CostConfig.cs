using System;
using JuicedUp.Common.Economy.Public.Data;

namespace JuicedUp.Common.Economy.Public
{
	[Serializable]
	public class CostConfig : ICost
	{
		public CurrencyId Id { get; set; }

		public int Amount { get; set; }
	}
}
