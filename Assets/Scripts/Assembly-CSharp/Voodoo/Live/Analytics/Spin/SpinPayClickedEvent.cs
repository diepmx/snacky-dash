using System.Collections.Generic;

namespace Voodoo.Live.Analytics.Spin
{
	public class SpinPayClickedEvent : SpinEvent
	{
		public override string EventName => null;

		public override string ExpectedStatus => null;

		protected override List<string> Parameters => null;

		public override bool CanTrack(IBlackboard blackboard)
		{
			return false;
		}
	}
}
