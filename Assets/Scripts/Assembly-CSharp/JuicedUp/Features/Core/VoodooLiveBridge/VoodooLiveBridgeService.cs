using System.Threading;
using Cysharp.Threading.Tasks;
using JuicedUp.Common.Time;
using JuicedUp.Core.Bootstrap;
using Voodoo.Live;
using Voodoo.Live.Offers;

namespace JuicedUp.Features.Core.VoodooLiveBridge
{
	public class VoodooLiveBridgeService : VoodooLiveBridgeBase, IAsyncInitializable
	{
		private readonly IServerTimeProvider _serverTimeProvider;

		public VoodooLiveBridgeService(IServerTimeProvider serverTimeProvider)
		{
		}

		public UniTask InitAsync(CancellationToken cancellationToken)
		{
			return default(UniTask);
		}

		private void VoodooLiveInitialized()
		{
		}

		protected override bool HasItemQuantity(string itemId, int amount)
		{
			return false;
		}

		protected override bool ApplyItemDelta(string itemId, int delta)
		{
			return false;
		}

		public override bool RewardingMethod(Transaction transaction)
		{
			return false;
		}

		public override bool ValidateFeature(IFeature feature)
		{
			return false;
		}

		private new bool GrantReward(ItemQuantity reward)
		{
			return false;
		}
	}
}
