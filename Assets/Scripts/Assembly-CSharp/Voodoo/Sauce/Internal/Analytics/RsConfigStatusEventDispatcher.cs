using System;
using System.Runtime.CompilerServices;

namespace Voodoo.Sauce.Internal.Analytics
{
	public class RsConfigStatusEventDispatcher
	{
		public event Action<RsConfigStatusEvent> OnCall
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event Action<RsConfigStatusEvent> OnInitialization
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event Action<RsConfigStatusEvent> OnStatusChange
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public void TriggerCall(RsConfigStatusOrigin origin, string url)
		{
		}

		public void TriggerApplyConfig(RsConfigStatusOrigin origin, bool hasTimeout)
		{
		}

		public void TriggerStatusChange(RsConfigStatusOrigin origin, VoodooTuneInitAnalyticsInfo info, string errorMessage = "")
		{
		}
	}
}
