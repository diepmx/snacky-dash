using System;
using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using JuicedUp.Common.Economy.Public.Data;
using JuicedUp.Common.Economy.Public.Storages;
using JuicedUp.Common.SaveAndLoad;
using JuicedUp.Common.Time;
using JuicedUp.Core.Bootstrap;
using Voodoo.Live;
using Voodoo.Sauce.Core;

namespace JuicedUp.Features.Core.Analytics
{
	public class AnalyticsService : IAsyncInitializable, IDisposable, ICoreGameAnalyticsService, IShopAnalyticsService, IOffersAnalyticsService, IGraphicsQualityAnalyticsService
	{
		private const int BoosterActivationUnits = 1;

		private readonly AnalyticsDataProvider _dataProvider;

		private bool _isVoodooSauceReady;

		private readonly Queue<Action> _pendingVoodooSauceCalls;

		public AnalyticsService(IWallet wallet, IBoosterStorage boosterStorage, IDataRepository<AnalyticsSaveData> analyticsRepository, IServerTimeProvider serverTimeProvider, GameAttemptTracker attemptTracker, ILevelProvider levelProvider)
		{
		}

		public UniTask InitAsync(CancellationToken cancellationToken)
		{
			return default(UniTask);
		}

		private void OnVoodooSauceInitFinished(VoodooSauceInitCallbackResult _)
		{
		}

		private void InvokeWhenReady(Action action)
		{
		}

		public void Dispose()
		{
		}

		private void OnBoosterTriggeredForAnalytics(BoosterId boosterId)
		{
		}

		private void OnEgpFiredForAnalytics(EgpTriggeredData payload)
		{
		}

		private void OnBridgeCollisionEvaluatedForAnalytics(TailBridgeCollisionData payload)
		{
		}

		private void Log(string message)
		{
		}

		public void TrackGameStart()
		{
		}

		public void TrackGameFinished(bool isWin, DefeatType? defeatTypeOverride = null)
		{
		}

		public void TrackGameClick(PlacementId placement)
		{
		}

		public void TrackItemTransaction(ItemTransactionData payload)
		{
		}

		private static bool IsBoosterInTransaction(ItemTransactionData payload)
		{
			return false;
		}

		private void EnrichBoosterInContext(AnalyticsEntry context, bool levelDifficultyAlreadyAppended)
		{
		}

		public void TrackItemTransactions(IEnumerable<ItemTransactionData> payloads)
		{
		}

		public void TrackLoseFlowImpression(LoseFlowImpressionData payload)
		{
		}

		public void TrackLoseFlowAction(LoseFlowActionData payload)
		{
		}

		public void TrackOutOfCoins(PlacementId placement)
		{
		}

		public void TrackOutOfLives(PlacementId placement)
		{
		}

		public void TrackOutOfBoosters(PlacementId placement)
		{
		}

		public void TrackBoosterActivation(BoosterId boosterId)
		{
		}

		public void TrackTutorialStepCompleted(string stepName, int stepIndex, float durationSeconds, int swipeCount)
		{
		}

		public void TrackPlayerStuckDetected(PlayerStuckData payload)
		{
		}

		public void TrackEgpTriggered(EgpTriggeredData payload)
		{
		}

		public void TrackTailBridgeCollision(TailBridgeCollisionData payload)
		{
		}

		private AnalyticsEntry BuildOutOfResourceContext(PlacementId placement)
		{
			return null;
		}

		public void TrackShopClick(ShopPayload payload)
		{
		}

		public void TrackShopOpened(ShopPayload payload)
		{
		}

		public void TrackShopClosed(ShopPayload payload)
		{
		}

		public void TrackShopInitFailed(ShopPayload payload)
		{
		}

		public void TrackShopOpenFailed(ShopPayload payload)
		{
		}

		public void TrackShopLoseConnection(ShopPayload payload)
		{
		}

		private AnalyticsEntry BuildShopContext(ShopPayload payload)
		{
			return null;
		}

		public void TrackOfferClick(OfferPayload payload)
		{
		}

		public void TrackOfferShown(OfferPayload payload)
		{
		}

		private string GetProductItems(ProductDTO product)
		{
			return null;
		}

		private string GetCurrency(ProductDTO product)
		{
			return null;
		}

		private string GetPrice(ProductDTO product)
		{
			return null;
		}

		public void TrackGraphicsQualityApplied(int tier, int targetFrameRate, float renderScale, bool wasRenderScaleOverridden, bool hapticThrottleEnabled)
		{
		}

		public void TrackGraphicsQualityApplyFailed(string reason)
		{
		}
	}
}
