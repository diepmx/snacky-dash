using System;
using System.Collections.Generic;
using JuicedUp.Common.Config;
using JuicedUp.Common.Economy.Public.Data;
using JuicedUp.Common.Economy.Public.Services;
using JuicedUp.Common.Economy.Public.Storages;
using JuicedUp.Common.Time;
using JuicedUp.Features.Core.Scene;
using JuicedUp.Features.Segmentation;
using UnityEngine;
using VContainer;
using Voodoo.Sauce.Debugger;

namespace JuicedUp.Features.Core.Debugger
{
	[Preserve]
	public class JuicedUpDebugger : CustomDebugger
	{
		private const string PremiumPrefsKey = "VoodooSauce.Premium";

		private const int DefaultCurrencyAmount = 1000;

		private bool _isUIHidden;

		private bool _isGreenLevelMode;

		private bool _showLayoutGuidelines;

		private readonly List<Color> _originalMaterialColors;

		private readonly Dictionary<CurrencyId, int> _lastAmounts;

		private PillManager _pillManager;

		private IServerTimeProvider _serverTimeProvider;

		private IEconomyService _economyService;

		private IWallet _wallet;

		private CampaignSegmentationPersistence _campaignSegmentationPersistence;

		private ICampaignAttributionService _campaignAttributionService;

		private RemoteConfigService _remoteConfigService;

		public override bool ReSetupScreenOnShown => false;

		private static void HandleDebuggerOpened()
		{
		}

		private static void HandleDebuggerClosed()
		{
		}

		public override string GetTitle()
		{
			return null;
		}

		public override int GetOrderIndex()
		{
			return 0;
		}

		public override void SetupScreen(Voodoo.Sauce.Debugger.Screen screen)
		{
		}

		private static void ReloadSameScene()
		{
		}

		private static ISceneService Resolve()
		{
			return null;
		}

		private void SetupTimeSection(Voodoo.Sauce.Debugger.Screen screen)
		{
		}

		private IServerTimeProvider GetServerTimeProvider()
		{
			return null;
		}

		private IEconomyService GetEconomyService()
		{
			return null;
		}

		private IWallet GetWalletStorage()
		{
			return null;
		}

		private PillManager GetPillManager()
		{
			return null;
		}

		private void AddServerTimeDays(string input)
		{
		}

		private static void SetupPremiumSection(Voodoo.Sauce.Debugger.Screen screen)
		{
		}

		private static void ToggleAllGameUI(bool visible)
		{
		}

		private void SetupLevelSection(Voodoo.Sauce.Debugger.Screen screen)
		{
		}

		private void RestartCurrentLevel(Voodoo.Sauce.Debugger.Screen screen)
		{
		}

		private void SetupGameplaySection(Voodoo.Sauce.Debugger.Screen screen)
		{
		}

		private void AddScaleFruitsButton(Voodoo.Sauce.Debugger.Screen screen)
		{
		}

		private void SetupEgpExperimentsSection(Voodoo.Sauce.Debugger.Screen screen)
		{
		}

		private bool GetEffectiveUseDeliveryPercentage()
		{
			return false;
		}

		private float GetEffectiveDeliveryPercentage()
		{
			return 0f;
		}

		private void SetupCurrencySection(Voodoo.Sauce.Debugger.Screen screen)
		{
		}

		private void SetupWeeklySection(Voodoo.Sauce.Debugger.Screen screen)
		{
		}

		private void AddCurrencyRow(Voodoo.Sauce.Debugger.Screen screen, string label, CurrencyId id, Func<string> refreshFunc)
		{
		}

		private void SetupDisplaySection(Voodoo.Sauce.Debugger.Screen screen)
		{
		}

		private void ApplyGreenLevelMode(bool enabled)
		{
		}

		private void DisplayLayoutGuidelines(bool show)
		{
		}

		private static void SetupCrashTestingSection(Voodoo.Sauce.Debugger.Screen screen)
		{
		}

		private CampaignSegmentationPersistence GetCampaignSegmentationPersistence()
		{
			return null;
		}

		private ICampaignAttributionService GetCampaignAttributionService()
		{
			return null;
		}

		private RemoteConfigService GetRemoteConfigService()
		{
			return null;
		}

		private void SetupCampaignSegmentationSection(Voodoo.Sauce.Debugger.Screen screen)
		{
		}

		private void SimulateCampaign(string campaignName, int installHoursAgo = 25)
		{
		}

		private void SetInstallHourAgo(int hoursAgo, string label)
		{
		}
	}
}
