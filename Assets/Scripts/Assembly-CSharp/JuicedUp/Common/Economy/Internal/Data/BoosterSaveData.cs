using System;
using System.Collections.Generic;
using JuicedUp.Common.Economy.Public.Data;

namespace JuicedUp.Common.Economy.Internal.Data
{
	[Serializable]
	public class BoosterSaveData
	{
		public Dictionary<BoosterId, int> Quantities;

		public bool IsDefault;
	}
}
