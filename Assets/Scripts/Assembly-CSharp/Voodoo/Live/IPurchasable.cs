using System;

namespace Voodoo.Live
{
	public interface IPurchasable : IDisposable
	{
		IPrice Price { get; }

		IReward Reward { get; }

		void RecoverTransaction(Transaction transaction);

		void Purchase();
	}
}
