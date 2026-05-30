using UnityEngine.Scripting;
using Voodoo.Sauce.Internal.SDKs;

namespace Voodoo.Sauce.Internal.Analytics
{
	[Preserve]
	public class FirebaseAnalyticsProviderSDK : IAnalyticsProviderSDK, ISDK
	{
		private const string UnityVersion = "12.10.0";

		public SDK GetSDKInformations()
		{
			return null;
		}
	}
}
