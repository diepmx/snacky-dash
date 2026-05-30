using JuicedUp.Features.Boosters.Config;
using JuicedUp.Features.Boosters.PreUseAnimation;
using JuicedUp.Features.Core.Hud;
using JuicedUp.Features.Core.Ingredients;
using JuicedUp.Features.Core.Layout;
using JuicedUp.Features.LoseTutorial;
using JuicedUp.Features.LoseTutorial.Config;
using JuicedUp.Features.VictoryScreen;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace JuicedUp.Features.Core
{
	public class LevelLifetimeScope : LifetimeScope
	{
		[SerializeField]
		private InGameHudView _inGameHudView;

		[SerializeField]
		private LevelController _levelController;

		[SerializeField]
		private SnakeOccupancyManager _snakeOccupancyManager;

		[SerializeField]
		private Player _player;

		[SerializeField]
		private PillManager _pillManager;

		[SerializeField]
		private TailManager _tailManager;

		[SerializeField]
		private LevelBuilder _levelBuilder;

		[SerializeField]
		private BoosterManager _boosterManager;

		[SerializeField]
		private CrateManager _crateManager;

		[SerializeField]
		private SwipeController _swipeController;

		[SerializeField]
		private LevelCameraFitter _levelCameraFitter;

		[SerializeField]
		private DarkOverlayController _tutorialDarkOverlayController;

		[SerializeField]
		private Camera _tutorialFocusCamera;

		[SerializeField]
		private TutorialView _tutorialViewPrefab;

		[Header("Meta")]
		[SerializeField]
		private ParticleSystem _roadExplosionVfx;

		[SerializeField]
		private BoosterButtonUI[] _boosterButtonUIs;

		[SerializeField]
		private BoosterBuyUI _boosterBuyUI;

		[Header("Guidance")]
		[SerializeField]
		private GuidanceConfig _guidanceConfig;

		[SerializeField]
		private GuidanceArrowView _guidanceArrowPrefab;

		[SerializeField]
		private GuidanceArrowView _guidanceArrowBridgePrefab;

		[Header("Booster Config")]
		[SerializeField]
		private BoosterConfigSO _boosterConfig;

		[Header("Booster Pre-Use Animation")]
		[Tooltip("Coordinator MonoBehaviour that drives the fly-icon-to-snake-head + eat sequence. Drag the scene instance here.")]
		[SerializeField]
		private BoosterPreUseAnimationCoordinator _boosterPreUseAnimationCoordinator;

		[Header("Boomerang (Cannon) Booster Flight VFX")]
		[Tooltip("Optional parent transform for the boomerang flight VFX pool. Defaults to the CrateView GameObject if unset. The VFX prefab itself is configured on BoosterConfigSO.")]
		[SerializeField]
		private Transform _boomerangFlightVfxParent;

		[Header("Victory Screen")]
		[SerializeField]
		private WinScreenConfig _winScreenConfig;

		[SerializeField]
		private IngredientUnlockConfig _ingredientUnlockConfig;

		[Header("Lose Tutorial")]
		[SerializeField]
		private LoseTutorialConfigSO _loseTutorialConfig;

		[SerializeField]
		private LoseTutorialView _loseTutorialPopupPrefab;

		[Header("Combo Tutorial")]
		[SerializeField]
		private ComboTutorialView _comboTutorialPopupPrefab;

		protected override void Configure(IContainerBuilder builder)
		{
		}

		private void RegisterServices(IContainerBuilder builder)
		{
		}

		private void RegisterBoosterShuffleVortexVfx(IContainerBuilder builder)
		{
		}

		private void RegisterBoosterPreUseAnimation(IContainerBuilder builder)
		{
		}

		private void RegisterMetaStage(IContainerBuilder builder)
		{
		}

		private void RegisterCoreStage(IContainerBuilder builder)
		{
		}
	}
}
