using System.Threading;
using Cysharp.Threading.Tasks;

namespace JuicedUp.Features.WeeklyMissions.Public
{
	public interface IDailyMissionsController
	{
		UniTask Initialize(DailyMissionsPayload payload, CancellationToken token);

		UniTask Execute(CancellationToken token);

		void Deactivate();
	}
}
