using System;
using System.Collections.Generic;
using JuicedUp.Common.Economy.Public.Data;

namespace JuicedUp.Common.Economy.Public.Storages
{
	public interface IWallet
	{
		event Action<CurrencyId, int> CurrencyChanged;

		int Get(CurrencyId currencyId);

		void Add(CurrencyId currencyId, int amount);

		void Set(CurrencyId currencyId, int balance);

		void Spend(CurrencyId currencyId, int amount);

		IReadOnlyDictionary<CurrencyId, int> GetAll();

		void LoadFrom(IReadOnlyDictionary<CurrencyId, int> balances);
	}
}
