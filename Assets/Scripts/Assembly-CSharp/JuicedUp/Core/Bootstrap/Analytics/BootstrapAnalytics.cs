using System;
using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using JuicedUp.Core.Bootstrap.Builder;
using Voodoo.Sauce.Core;

namespace JuicedUp.Core.Bootstrap.Analytics
{
	public class BootstrapAnalytics : IAsyncInitializable, IBootstrapAnalytics, IDisposable
	{
		private readonly struct BufferedEvent
		{
			public readonly string Name;

			public readonly Dictionary<string, object> Context;

			public BufferedEvent(string name, Dictionary<string, object> context)
			{
				Name = null;
				Context = null;
			}
		}

		private const int InitialBufferCapacity = 64;

		private readonly Queue<BufferedEvent> _buffer;

		private readonly object _lock;

		private bool _ready;

		private bool _subscribed;

		private bool _disposed;

		internal int BufferedCount => 0;

		internal bool IsReady => false;

		public UniTask InitAsync(CancellationToken cancellationToken)
		{
			return default(UniTask);
		}

		public void Subscribe()
		{
		}

		public void Dispose()
		{
		}

		public void TrackStageStarted(BuildStage stage, int sequentialCount, int parallelCount)
		{
		}

		public void TrackStageCompleted(BuildStage stage, long durationMs)
		{
		}

		public void TrackStepStarted(BuildStage stage, string stepName, bool isParallel)
		{
		}

		public void TrackStepCompleted(BuildStage stage, string stepName, bool isParallel, long durationMs)
		{
		}

		public void TrackStepFailed(BuildStage stage, string stepName, bool isParallel, long durationMs, Exception ex)
		{
		}

		public void TrackLoadingScreenShown()
		{
		}

		public void TrackLoadingPhase(string phase, long elapsedMsSinceShown)
		{
		}

		public void TrackVsInitialized(long elapsedMs, bool isLate, string status, long? elapsedMsSinceHidden = null)
		{
		}

		public void TrackLoadingScreenHidden(long elapsedMs, bool wasVsReady)
		{
		}

		private void Send(string eventName, Dictionary<string, object> ctx)
		{
		}

		private void OnVoodooSauceInitFinished(VoodooSauceInitCallbackResult _)
		{
		}

		internal void Flush()
		{
		}

		protected virtual void Emit(string eventName, Dictionary<string, object> ctx)
		{
		}
	}
}
