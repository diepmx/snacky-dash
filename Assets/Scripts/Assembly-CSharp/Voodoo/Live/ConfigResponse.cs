using System;

namespace Voodoo.Live
{
	public class ConfigResponse
	{
		public TimeSpan requestDuration;

		public bool hasTimeout;

		public ulong payloadSize;

		public long responseCode;

		public int currentTimeoutInMilliseconds;

		public int currentSecondTimeoutInMilliseconds;

		public string url;

		public string errorMessage;

		public string json;

		public ConfigResponse(int timeoutInMilliseconds = -1, int secondTimeoutInMilliseconds = -1)
		{
		}

		public void Save(IBlackboard blackboard)
		{
		}
	}
}
