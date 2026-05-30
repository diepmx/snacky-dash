using System;
using System.Collections.Generic;
using JuicedUp.Common.Economy.Public.Data;

namespace JuicedUp.Common.Economy.Public.Storages
{
	public interface IEntitlementStorage
	{
		event Action<EntitlementId, int> EntitlementChanged;

		int GetRemainingSeconds(EntitlementId entitlementId);

		bool IsActive(EntitlementId entitlementId);

		bool IsPermanent(EntitlementId entitlementId);

		void SetPermanent(EntitlementId entitlementId);

		void AddDuration(EntitlementId entitlementId, int durationSeconds, bool stack = true);

		long GetUntilUtcSeconds(EntitlementId entitlementId);

		IReadOnlyDictionary<EntitlementId, long> GetAllUntilUtcSeconds();

		void LoadFrom(IReadOnlyDictionary<EntitlementId, long> untilUtcSecondsByEntitlement);
	}
}
