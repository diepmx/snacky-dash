using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace JuicedUp.Features.WeeklyMissions.Public
{
	public interface IWeeklyMissionFtueBadgeController
	{
		UniTask ActivateControllerLoop(Transform badgeTransform, CancellationToken token);

		UniTask Initialize(CancellationToken token);

		UniTask Execute(CancellationToken token);

		UniTask Deactivate(CancellationToken token);
	}
}
