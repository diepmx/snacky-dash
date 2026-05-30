using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using JuicedUp.Common.FeatureOriented;
using JuicedUp.Core.Bootstrap;
using JuicedUp.Features.WeeklyMissions.Public;
using VContainer;
using Voodoo.Sauce.Core;

namespace JuicedUp.Features.WeeklyMissions.Internal
{
	internal class WeeklyMissionsFeatureController : IAsyncInitializable, IDisposable
	{
		private readonly IWeeklyMissionsDataProvider _weeklyMissionsDataProvider;

		private readonly IFeatureAvailabilityProvider _featureStatusProvider;

		private readonly ILoginMissionHandler _loginMissionHandler;

		private readonly ILevelsStreakHandler _levelsStreakHandler;

		private readonly IMissionsHandler _missionsHandler;

		private Action _onDispose;

		public WeeklyMissionsFeatureController(IWeeklyMissionsDataProvider weeklyMissionsDataProvider, [Key(FeatureIds.WeeklyMissions)] IFeatureAvailabilityProvider featureStatusProvider, ILoginMissionHandler loginMissionHandler, ILevelsStreakHandler levelsStreakHandler, IMissionsHandler missionsHandler)
		{
		}

		public UniTask InitAsync(CancellationToken cancellationToken)
		{
			return default(UniTask);
		}

		public void Dispose()
		{
		}

		private void GetVTValuesAfterVSInit(VoodooSauceInitCallbackResult result)
		{
		}

		private void Clear()
		{
		}
	}
}
