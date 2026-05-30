using System.Diagnostics;
using System.Threading;
using JuicedUp.Core.Bootstrap.Analytics;

namespace JuicedUp.Core.Bootstrap
{
	public sealed class GameInteractableReporter
	{
		private readonly IBootstrapAnalytics _analytics;

		private readonly Stopwatch _stopwatch;

		private bool _reported;

		private bool _vsReady;

		private bool _hiddenSet;

		private long _hiddenAtMs;

		public GameInteractableReporter(IBootstrapAnalytics analytics)
		{
		}

		public void MarkBootShown()
		{
		}

		public void MarkVsReady(bool isLate)
		{
		}

		public void MarkVsTimeout(CancellationToken cancellationToken)
		{
		}

		public void MarkLoadingHidden()
		{
		}

		public void TrackErrorPhase()
		{
		}

		private void ReportOnGameInteractableOnce()
		{
		}

		private void SubscribeLateVsListener(CancellationToken cancellationToken)
		{
		}
	}
}
