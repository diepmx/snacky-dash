using JuicedUp.Features.WeeklyMissions.Public;
using UnityEngine;

namespace JuicedUp.Features.WeeklyMissions.Internal
{
	internal class DailyMissionContainer : MonoBehaviour, IDailyMissionContainer
	{
		[SerializeField]
		private DailyMissionView _startedDailyMissionView;

		private IDailyMissionView _dailyMissionView;

		public IDailyMissionView DailyMissionView => null;

		private void Awake()
		{
		}

		public void SetNewDailyMissionView(IDailyMissionView dailyMissionView)
		{
		}
	}
}
