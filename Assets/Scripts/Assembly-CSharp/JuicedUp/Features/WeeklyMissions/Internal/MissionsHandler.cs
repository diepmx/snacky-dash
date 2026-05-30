using JuicedUp.Common.Economy.Public.Data;
using JuicedUp.Common.Economy.Public.Storages;
using JuicedUp.Common.Economy.Scripts.Public;
using JuicedUp.Features.Core;
using JuicedUp.Features.Shop.Scripts.Public;
using JuicedUp.Features.WeeklyMissions.Public;

namespace JuicedUp.Features.WeeklyMissions.Internal
{
	internal class MissionsHandler : IMissionsHandler
	{
		private readonly IProductPurchaseGlobalNotifier _productPurchaseGlobalNotifier;

		private readonly IWeeklyMissionsDataProvider _weeklyMissionsDataProvider;

		private readonly IEconomyOperationsNotifier _economyOperationsNotifier;

		private readonly IWeeklyMissionsFacade _weeklyMissionsFacade;

		private readonly IGameStateEvents _gameStateEvents;

		private readonly IMissionListener _missionListener;

		private readonly IBoosterStorage _boosterStorage;

		private readonly ILevelProvider _levelProvider;

		private readonly Loading _loading;

		public MissionsHandler(IProductPurchaseGlobalNotifier productPurchaseGlobalNotifier, IWeeklyMissionsDataProvider weeklyMissionsDataProvider, IEconomyOperationsNotifier economyOperationsNotifier, IWeeklyMissionsFacade weeklyMissionsFacade, IGameStateEvents gameStateEvents, IMissionListener missionListener, IBoosterStorage boosterStorage, ILevelProvider levelProvider, Loading loading)
		{
		}

		public void Activate()
		{
		}

		public void Deactivate()
		{
		}

		private void Subscribe()
		{
		}

		private void Unsubscribe()
		{
		}

		private void OnProductPurchased(IProduct product)
		{
		}

		private void OnGameStateChanged(GameState state, DefeatType defeatType)
		{
		}

		private void OnMissionExecuted(MissionGoalType type, int amount)
		{
		}

		private void OnMissionFailed(MissionGoalType type)
		{
		}

		private void OnRewardGranted(IReward reward)
		{
		}

		private void OnRewardSpent(ICost cost)
		{
		}

		private void CurrencyGranted(IReward reward)
		{
		}

		private void BoosterGranted(IReward reward)
		{
		}

		private void EntitlementGranted(IReward reward)
		{
		}

		private void CurrencySpent(CurrencyId currencyId, int amount)
		{
		}

		private void BoosterSpent(BoosterId boosterId, int spentValue)
		{
		}

		private void EntitlementSpent(IReward reward)
		{
		}

		private void ExecuteMission(MissionGoalType type, int amount)
		{
		}

		private void FailMission(MissionGoalType type)
		{
		}
	}
}
