using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using JuicedUp.Common.Economy.Public.Data;
using JuicedUp.Common.Economy.Public.Storages;
using JuicedUp.Common.Time;

namespace JuicedUp.Common.Economy.Internal.Storages
{
	internal sealed class EntitlementStorage : IEntitlementStorage
	{
		public const long PermanentUntilUtcSeconds = 9223372036854775807L;

		private readonly Dictionary<EntitlementId, long> _untilUtcSeconds;

		private readonly IServerTimeProvider _serverTimeProvider;

		public event Action<EntitlementId, int> EntitlementChanged
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public EntitlementStorage(IServerTimeProvider serverTimeProvider)
		{
		}

		public int GetRemainingSeconds(EntitlementId entitlementId)
		{
			return 0;
		}

		public bool IsActive(EntitlementId entitlementId)
		{
			return false;
		}

		public bool IsPermanent(EntitlementId entitlementId)
		{
			return false;
		}

		public void SetPermanent(EntitlementId entitlementId)
		{
		}

		public void AddDuration(EntitlementId entitlementId, int durationSeconds, bool stack = true)
		{
		}

		public long GetUntilUtcSeconds(EntitlementId entitlementId)
		{
			return 0L;
		}

		public IReadOnlyDictionary<EntitlementId, long> GetAllUntilUtcSeconds()
		{
			return null;
		}

		public void LoadFrom(IReadOnlyDictionary<EntitlementId, long> untilUtcSecondsByEntitlement)
		{
		}

		private static long ToUnixSeconds(DateTime utc)
		{
			return 0L;
		}
	}
}
