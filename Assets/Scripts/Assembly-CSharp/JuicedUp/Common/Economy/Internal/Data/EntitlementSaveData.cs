using System;
using System.Collections.Generic;
using JuicedUp.Common.Economy.Public.Data;

namespace JuicedUp.Common.Economy.Internal.Data
{
	[Serializable]
	public class EntitlementSaveData
	{
		public Dictionary<EntitlementId, long> UntilUtcSeconds;

		public bool IsDefault;
	}
}
