using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using JuicedUp.Common.Economy.Internal.Data;
using JuicedUp.Common.Economy.Public.Data;
using JuicedUp.Common.Economy.Public.Storages;
using JuicedUp.Common.SaveAndLoad;
using JuicedUp.Core.Bootstrap;

namespace JuicedUp.Common.Economy.Internal.Initializers
{
	internal sealed class EntitlementStorageInitializer : IAsyncInitializable, IDisposable
	{
		private readonly IDataRepository<EntitlementSaveData> _repository;

		private readonly IEntitlementStorage _entitlementStorage;

		public EntitlementStorageInitializer(IEntitlementStorage entitlementStorage, IDataRepository<EntitlementSaveData> repository)
		{
		}

		public UniTask InitAsync(CancellationToken cancellationToken)
		{
			return default(UniTask);
		}

		public void Dispose()
		{
		}

		private void OnEntitlementChanged(EntitlementId _, int __)
		{
		}
	}
}
