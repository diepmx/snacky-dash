using System.Threading;
using Cysharp.Threading.Tasks;

namespace JuicedUp.Features.WeeklyMissions.Public
{
	public interface IBottomDailyItemController
	{
		UniTask Initialize(BottomDailyItemsPayload payload, CancellationToken token);

		UniTask Execute(CancellationToken token);

		void Deactivate();
	}
}
