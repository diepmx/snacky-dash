using JuicedUp.Common.Notifiers.AppLifeCycle;
using JuicedUp.Common.Time;
using JuicedUp.Features.WeeklyMissions.Public;

namespace JuicedUp.Features.WeeklyMissions.Internal
{
	internal class LoginMissionHandler : ILoginMissionHandler
	{
		private const string LastLoginSaveKey = "LastLogin";

		private readonly IWeeklyMissionsDataProvider _weeklyMissionsDataProvider;

		private readonly IAppLifeCycleNotifier _appLifeCycleNotifier;

		private readonly IServerTimeProvider _serverTimeProvider;

		private readonly IMissionExecutor _missionExecutor;

		public LoginMissionHandler(IWeeklyMissionsDataProvider weeklyMissionsDataProvider, IAppLifeCycleNotifier appLifeCycleNotifier, IServerTimeProvider serverTimeProvider, IMissionExecutor missionExecutor)
		{
		}

		public void Initialize()
		{
		}

		public void Clear()
		{
		}

		private void OnApplicationFocusChanged(bool hasFocus)
		{
		}

		private void TryToMarkAsNewLogin()
		{
		}

		private bool IsNewDay()
		{
			return false;
		}
	}
}
