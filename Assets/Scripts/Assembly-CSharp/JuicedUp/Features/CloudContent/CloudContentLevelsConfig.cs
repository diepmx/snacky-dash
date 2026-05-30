using System;

namespace JuicedUp.Features.CloudContent
{
	[Serializable]
	public class CloudContentLevelsConfig
	{
		public bool Enabled;

		public int Version;

		public bool UseWip;

		public int DownloadTimeoutSeconds;

		public int MaxRetryAttempts;

		public int BatchDownloadSize;

		public int PreloadThreshold;

		public int LocalLevelThreshold;

		public string CohortName;

		public int PrewarmTimeoutSeconds;
	}
}
