using System;
using JuicedUp.Features.CloudContent;
using JuicedUp.Features.LevelCohort;
using Voodoo.Sauce.Core;

namespace JuicedUp.Common.Config
{
	public class RemoteConfigService
	{
		private readonly IRemoteConfigProvider _provider;

		private Action _onInitFinished;

		private bool _isInitialized;

		public bool IsInitialized => false;

		public AdsConfig Ads => null;

		public CrateConfig Crate => null;

		public BoosterConfig Booster => null;

		public SegmentationCampaignConfig SegmentationCampaign => null;

		public HomescreenTransitionConfig HomescreenTransitionConfig => null;

		public PillConfig Pill => null;

		public RewardConfig Reward => null;

		public ForceUpdateConfig ForceUpdate => null;

		public CloudContentLevelsConfig CloudContentLevels => null;

		public LevelCohortConfig LevelCohort => null;

		public ComboTutorialConfig ComboTutorial => null;

		public GraphicsQualityConfig GraphicsQuality => null;

		public EgpConfig Egp => null;

		public RemoteConfigService(IRemoteConfigProvider provider)
		{
		}

		public void RegisterOnInitFinished(Action onInitFinished)
		{
		}

		public void UnregisterOnInitFinished(Action onInitFinished)
		{
		}

		private void OnVoodooSauceInitialized(VoodooSauceInitCallbackResult result)
		{
		}
	}
}
