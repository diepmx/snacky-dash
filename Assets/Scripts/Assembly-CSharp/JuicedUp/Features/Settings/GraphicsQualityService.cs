using System;
using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using JuicedUp.Common.Config;
using JuicedUp.Core.Bootstrap;
using JuicedUp.Features.Core.Analytics;

namespace JuicedUp.Features.Settings
{
	public class GraphicsQualityService : IAsyncInitializable, IDisposable
	{
		private const GraphicsQualityTier FallbackTier = GraphicsQualityTier.High;

		private const float MinimumRenderScaleOverride = 0.1f;

		private static readonly IReadOnlyDictionary<int, GraphicsQualityTier> TierByValue;

		private readonly IGraphicsQualityAnalyticsService _analytics;

		private readonly RemoteConfigService _remoteConfigService;

		private bool _hasAppliedThisSession;

		private bool _lastAppliedIsHapticThrottlingEnabled;

		private float _lastAppliedRenderScale;

		private int _lastAppliedTargetFrameRate;

		private int _lastAppliedTier;

		private bool _lastAppliedWasRenderScaleOverridden;

		public GraphicsQualityService(RemoteConfigService remoteConfigService, IGraphicsQualityAnalyticsService analytics)
		{
		}

		public UniTask InitAsync(CancellationToken cancellationToken)
		{
			return default(UniTask);
		}

		public void Dispose()
		{
		}

		private static GraphicsQualityTier ResolveTier(int tierValue)
		{
			return default(GraphicsQualityTier);
		}

		private void OnRemoteConfigInitialized()
		{
		}

		private void ApplyConfig()
		{
		}
	}
}
