using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using Voodoo.Live.Offers;

namespace JuicesUp.Features.SeasonPass.Internal.Core
{
	internal class BattlePassSeasonService : IDisposable, IBattlePassSeasonService
	{
		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CSeasonStatusPollingLoop_003Ed__21 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskVoidMethodBuilder _003C_003Et__builder;

			public CancellationToken ctoken;

			public BattlePassSeasonService _003C_003E4__this;

			private UniTask<bool>.Awaiter _003C_003Eu__1;

			private void MoveNext()
			{
			}

			void IAsyncStateMachine.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				this.MoveNext();
			}

			[DebuggerHidden]
			private void SetStateMachine(IAsyncStateMachine stateMachine)
			{
			}

			void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
			{
				//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
				this.SetStateMachine(stateMachine);
			}
		}

		private readonly IBattlePassManager _manager;

		private readonly IBattlePassAppBridge _appBridge;

		private readonly IBattlePassAnalytics _analytics;

		private CancellationTokenSource _scheduledCheckCts;

		public IFeature MainOffer { get; private set; }

		public BattlePassSeasonService(IBattlePassManager manager, IBattlePassAppBridge appBridge, IBattlePassAnalytics analytics)
		{
		}

		public bool RefreshSeasonDetection()
		{
			return false;
		}

		private bool DetectBattlePassOffers()
		{
			return false;
		}

		private void TryCleanupCompletedSeason()
		{
		}

		private bool InitNewSeason(IFeature offer, string seasonKey)
		{
			return false;
		}

		private IFeature FindMainOffer()
		{
			return null;
		}

		private bool IsOfferCurrentlyActive(IFeature offer)
		{
			return false;
		}

		private bool RewardsBattlePassItem(IFeature offer)
		{
			return false;
		}

		private string ParseSeasonKey(IFeature offer)
		{
			return null;
		}

		public TimeSpan GetTimeRemaining()
		{
			return default(TimeSpan);
		}

		public void CheckSeasonStatus()
		{
		}

		private void TransitionToGracePeriod()
		{
		}

		public void StartSeasonStatusPolling()
		{
		}

		[AsyncStateMachine(typeof(_003CSeasonStatusPollingLoop_003Ed__21))]
		private UniTaskVoid SeasonStatusPollingLoop(CancellationToken ctoken)
		{
			return default(UniTaskVoid);
		}

		public void Dispose()
		{
		}
	}
}
