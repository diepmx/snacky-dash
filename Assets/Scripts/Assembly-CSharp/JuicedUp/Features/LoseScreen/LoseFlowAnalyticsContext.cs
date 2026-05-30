using JuicedUp.Features.Core.Analytics;

namespace JuicedUp.Features.LoseScreen
{
	public class LoseFlowAnalyticsContext
	{
		private readonly string _flowId;

		private readonly int _stepIndex;

		private readonly string _screenName;

		public ICoreGameAnalyticsService Analytics { get; }

		public LoseFlowAnalyticsContext(string flowId, int stepIndex, string screenName, ICoreGameAnalyticsService analytics)
		{
		}

		public LoseFlowActionData BuildActionData(LoseFlowActionType actionType)
		{
			return default(LoseFlowActionData);
		}
	}
}
