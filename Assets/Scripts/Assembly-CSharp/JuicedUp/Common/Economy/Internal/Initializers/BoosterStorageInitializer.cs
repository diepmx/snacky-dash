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
	internal class BoosterStorageInitializer : IAsyncInitializable, IDisposable
	{
		private readonly IDataRepository<BoosterSaveData> _repository;

		private readonly IBoosterStorage _boosterStorage;

		public BoosterStorageInitializer(IBoosterStorage boosterStorage, IDataRepository<BoosterSaveData> repository)
		{
		}

		public UniTask InitAsync(CancellationToken cancellationToken)
		{
			return default(UniTask);
		}

		public void Dispose()
		{
		}

		private void OnQuantityChanged(BoosterId _, int __)
		{
		}

		private void PersistQuantities()
		{
		}
	}
}
