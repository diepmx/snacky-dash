using System.Collections.Generic;

namespace JuicesUp.Features.SeasonPass.Internal.Core
{
	public static class GenericLiveopsEventSender
	{
		public enum LiveOpsEventType
		{
			battle_pass = 0
		}

		public static void VS_LiveOpsEventClosed(object battlePass, Dictionary<string, object> specificData)
		{
		}

		public static void VS_LiveOpsMilestoneCompleted(LiveOpsEventType battlePass, int stepIndex, Dictionary<string, object> specificData)
		{
		}

		public static void VS_LiveOpsEventJoined(LiveOpsEventType battlePass, Dictionary<string, object> specificData)
		{
		}
	}
}
