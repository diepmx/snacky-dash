using System.Threading;
using Cysharp.Threading.Tasks;

namespace JuicedUp.Features.WeeklyMissions.Public
{
	public interface IWeeklyMissionsPopupController
	{
		UniTask ActivateControllerLoop(CancellationToken token);

		UniTask Initialize(CancellationToken token);

		UniTask Execute(CancellationToken token);

		UniTask Deactivate(CancellationToken token);
	}
}
