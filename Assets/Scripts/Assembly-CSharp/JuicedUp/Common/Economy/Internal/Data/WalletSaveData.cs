using System;
using System.Collections.Generic;
using JuicedUp.Common.Economy.Public.Data;

namespace JuicedUp.Common.Economy.Internal.Data
{
	[Serializable]
	public class WalletSaveData
	{
		public Dictionary<CurrencyId, int> Balances;

		public bool IsDefault;
	}
}
