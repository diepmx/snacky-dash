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
	internal class WalletInitializer : IAsyncInitializable, IDisposable
	{
		private readonly IDataRepository<WalletSaveData> _repository;

		private readonly IWallet _wallet;

		public WalletInitializer(IWallet wallet, IDataRepository<WalletSaveData> repository)
		{
		}

		public UniTask InitAsync(CancellationToken cancellationToken)
		{
			return default(UniTask);
		}

		public void Dispose()
		{
		}

		private void Subscribe()
		{
		}

		private void Unsubscribe()
		{
		}

		private void OnCurrencyChanged(CurrencyId _, int __)
		{
		}
	}
}
