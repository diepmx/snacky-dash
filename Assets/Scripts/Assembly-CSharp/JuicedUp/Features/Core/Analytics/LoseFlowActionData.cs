namespace JuicedUp.Features.Core.Analytics
{
	public struct LoseFlowActionData
	{
		public string FlowId { get; }

		public int StepIndex { get; }

		public string ScreenName { get; }

		public LoseFlowActionType ActionType { get; }

		public LoseFlowActionData(string flowId, int stepIndex, string screenName, LoseFlowActionType actionType)
		{
			FlowId = null;
			StepIndex = 0;
			ScreenName = null;
			ActionType = default(LoseFlowActionType);
		}
	}
}
