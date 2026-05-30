using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using JuicedUp.Common.Economy.Public.Data;
using JuicedUp.Common.Economy.Public.Storages;

namespace JuicedUp.Common.Economy.Internal.Storages
{
	internal class BoosterStorage : IBoosterStorage
	{
		private readonly Dictionary<BoosterId, int> _quantities;

		public event Action<BoosterId, int> BoosterAdded
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

		public event Action<BoosterId, int> BoosterSpent
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

		public event Action<BoosterId, int> BoosterChanged
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

		public int Get(BoosterId boosterId)
		{
			return 0;
		}

		public void Add(BoosterId boosterId, int amount)
		{
		}

		public void Spend(BoosterId boosterId, int amount)
		{
		}

		public IReadOnlyDictionary<BoosterId, int> GetAll()
		{
			return null;
		}

		public void LoadFrom(IReadOnlyDictionary<BoosterId, int> quantities)
		{
		}
	}
}
