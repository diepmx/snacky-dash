using UnityEngine.Scripting;
using Voodoo.Sauce.Internal.SDKs;

namespace Voodoo.Sauce.Internal.Analytics
{
	[Preserve]
	public class AdjustAnalyticsProviderSDK : IAnalyticsProviderSDK, ISDK
	{
		private const string DEPENDENCIES_PATH = "VoodooSauce/Analytics/Adjust/3rdParty/Adjust/Native/Editor/Dependencies.xml";

		public SDK GetSDKInformations()
		{
			return null;
		}
	}
}
