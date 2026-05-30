using System;

namespace Voodoo.Sauce.Core.Model
{
	[Serializable]
	public class SourcepointConfiguration
	{
		public int accountId;

		public int propertyId;

		public int privacyManagerId;

		public string propertyName;

		public long messageTimeoutInSeconds;
	}
}
