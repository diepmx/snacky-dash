using System;
using JuicesUp.Features.SeasonPass.Internal.Core;
using JuicesUp.Features.SeasonPass.Internal.Views;

namespace JuicesUp.Features.SeasonPass.Internal.Debugging
{
	internal class BattlePassDebugger
	{
		private IBattlePassUIController _uiController;

		private IBattlePassManager _manager;

		private IDebugBattlePassTimeOverride _debugTimeOverride;

		private IServerTimeProvider _serverTimeProvider;

		public BattlePassDebugger(IBattlePassManager manager, IBattlePassUIController uiController, IDebugBattlePassTimeOverride debugTimeOverride, IServerTimeProvider serverTimeProvider)
		{
		}

		public void TestPurchaseSuccessDone()
		{
		}

		public void SetServerTime10SecBeforeEnd()
		{
		}

		public void SetServerTimeToEndDate()
		{
		}

		private bool TryGetSeasonEndDate(out DateTime endDate)
		{
			endDate = default(DateTime);
			return false;
		}
	}
}
