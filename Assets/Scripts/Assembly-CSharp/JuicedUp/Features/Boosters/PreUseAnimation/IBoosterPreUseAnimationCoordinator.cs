using System.Threading;
using Cysharp.Threading.Tasks;
using JuicedUp.Common.Economy.Public.Data;

namespace JuicedUp.Features.Boosters.PreUseAnimation
{
	public interface IBoosterPreUseAnimationCoordinator
	{
		bool IsAnimating { get; }

		UniTask PlayAsync(BoosterId boosterId, CancellationToken cancellationToken);
	}
}
