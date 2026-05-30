using UnityEngine.Scripting;
using Voodoo.Sauce.Firebase.Interfaces;
using Voodoo.Sauce.Internal.SDKs;

[Preserve]
public class FirebaseCrashlyticsProviderSDK : ICrashlyticsProviderSDK, ISDK
{
	private const string UnityVersion = "12.10.0";

	public SDK GetSDKInformations()
	{
		return null;
	}
}
