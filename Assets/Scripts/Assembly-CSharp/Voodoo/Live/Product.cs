using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Voodoo.Live
{
	public class Product : Conditionnal, IResultProvider
	{
		public static readonly Product Invalid;

		private IPrice _price;

		private IReward _reward;

		private string _name;

		public Result Validation { get; protected set; }

		public string Id { get; set; }

		public string Name => null;

		public IPrice Price => null;

		public IReward Reward => null;

		public override IBlackboard Blackboard => null;

		public event Action<string> statusChanged
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

		public Product(string id, string name, IPrice price, IReward reward, List<string> tags = null)
		{
		}

		public Transaction GetTransaction(string purchaseId = null, Action<Transaction, bool> onComplete = null, Dictionary<string, object> contextParameters = null)
		{
			return null;
		}

		public Transaction Purchase(string id = null, Action<Transaction, bool> onComplete = null, Dictionary<string, object> contextParameters = null)
		{
			return null;
		}

		public void Validate()
		{
		}

		public override void Dispose()
		{
		}
	}
}
