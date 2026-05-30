using JuicedUp.Common.ChestPopup.Data;
using JuicedUp.Common.Economy.Internal.Components;
using JuicedUp.Common.Economy.Internal.Data;
using JuicedUp.Common.Economy.Internal.Views;
using JuicedUp.Features.Core.Home;
using JuicedUp.Features.Shop.Internal.Views;
using JuicedUp.Features.WeeklyMissions.Internal;
using JuicedUp.Features.WeeklyMissions.Public;
using UI;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace JuicedUp.Features.Core
{
	public class GameLifetimeScope : LifetimeScope
	{
		[Header("Core")]
		[SerializeField]
		private Canvas _mainCanvas;

		[SerializeField]
		private HomePanel _homePanel;

		[SerializeField]
		private TopHUDPanel _topHUDPanel;

		[SerializeField]
		private BottomHudPanel _bottomHudPanel;

		[Header("Popup")]
		[SerializeField]
		private Transform _popupRoot;

		[Header("Weekly Missions")]
		[SerializeField]
		private WeeklyMissionsBadge _weeklyMissionsBadge;

		[SerializeField]
		private DailyMissionsDescription _dailyMissionsDescription;

		[Header("Economy")]
		[SerializeField]
		private ChestsDescription _weeklyMissionsChestsDescription;

		[SerializeField]
		private RewardFlyParticle _rewardFlyParticlePrefab;

		[SerializeField]
		private Transform _rewardFlyParticlesRoot;

		[SerializeField]
		private EconomySprites _economySprites;

		[SerializeField]
		private ShopView _shopView;

		[SerializeField]
		private RewardView _rewardViewPrefab;

		[SerializeField]
		private Transform _rewardViewsRoot;

		protected override void Configure(IContainerBuilder builder)
		{
		}

		private void RegisterServices(IContainerBuilder builder)
		{
		}

		private void RegisterMetaStage(IContainerBuilder builder)
		{
		}

		private void RegisterCoreStage(IContainerBuilder builder)
		{
		}

		private void RegisterBootStage(IContainerBuilder builder)
		{
		}

		private void RegisterInstances(IContainerBuilder builder)
		{
		}
	}
}
