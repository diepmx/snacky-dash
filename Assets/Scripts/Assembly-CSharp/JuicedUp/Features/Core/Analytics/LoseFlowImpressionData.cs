namespace JuicedUp.Features.Core.Analytics
{
	public struct LoseFlowImpressionData
	{
		public string FlowId { get; }

		public int StepIndex { get; }

		public string ScreenName { get; }

		public bool IsReturnView { get; }

		public LoseFlowImpressionData(string flowId, int stepIndex, string screenName, bool isReturnView)
		{
			FlowId = null;
			StepIndex = 0;
			ScreenName = null;
			IsReturnView = false;
		}
	}
}
