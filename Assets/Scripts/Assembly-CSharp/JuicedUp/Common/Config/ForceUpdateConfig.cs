using System;

namespace JuicedUp.Common.Config
{
	[Serializable]
	public class ForceUpdateConfig
	{
		public bool IsActive;

		public string MinimumVersion;

		public string AppleStoreLink;

		public string GoogleStoreLink;
	}
}
