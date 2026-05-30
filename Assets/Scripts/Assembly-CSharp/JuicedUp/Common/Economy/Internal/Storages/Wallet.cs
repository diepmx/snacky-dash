using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using JuicedUp.Common.Economy.Public.Data;
using JuicedUp.Common.Economy.Public.Storages;

namespace JuicedUp.Common.Economy.Internal.Storages
{
	internal class Wallet : IWallet
	{
		private readonly Dictionary<CurrencyId, int> _balances;

		public event Action<CurrencyId, int> CurrencyChanged
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

		public int Get(CurrencyId currencyId)
		{
			return 0;
		}

		public void Add(CurrencyId currencyId, int amount)
		{
		}

		public void Set(CurrencyId currencyId, int balance)
		{
		}

		public void Spend(CurrencyId currencyId, int amount)
		{
		}

		public IReadOnlyDictionary<CurrencyId, int> GetAll()
		{
			return null;
		}

		public void LoadFrom(IReadOnlyDictionary<CurrencyId, int> balances)
		{
		}
	}
}
