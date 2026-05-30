using System;
using System.Collections.Generic;
using JuicedUp.Common.Economy.Public.Data;

namespace JuicedUp.Common.Economy.Public.Storages
{
	public interface IBoosterStorage
	{
		event Action<BoosterId, int> BoosterAdded;

		event Action<BoosterId, int> BoosterSpent;

		event Action<BoosterId, int> BoosterChanged;

		int Get(BoosterId boosterId);

		void Add(BoosterId boosterId, int amount);

		void Spend(BoosterId boosterId, int amount);

		IReadOnlyDictionary<BoosterId, int> GetAll();

		void LoadFrom(IReadOnlyDictionary<BoosterId, int> quantities);
	}
}
