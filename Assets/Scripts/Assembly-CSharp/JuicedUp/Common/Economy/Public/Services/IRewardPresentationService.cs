using System.Threading;
using Cysharp.Threading.Tasks;
using JuicedUp.Common.Economy.Public.Data;

namespace JuicedUp.Common.Economy.Public.Services
{
	public interface IRewardPresentationService
	{
		UniTask Play(RewardPresentationContext context, CancellationToken cancellationToken = default(CancellationToken));
	}
}
