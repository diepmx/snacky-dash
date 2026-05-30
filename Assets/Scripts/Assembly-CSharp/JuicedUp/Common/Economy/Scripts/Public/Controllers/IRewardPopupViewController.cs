using System.Threading;
using Cysharp.Threading.Tasks;
using JuicedUp.Common.Economy.Public;

namespace JuicedUp.Common.Economy.Scripts.Public.Controllers
{
	public interface IRewardPopupViewController
	{
		UniTask Activate(RewardPopupPayload payload, CancellationToken cancellationToken);

		void Deactivate();
	}
}
