using System;
using System.Threading.Tasks;

namespace Voodoo.Sauce.Privacy
{
	public interface IConsentManagementProvider
	{
		string GetName();

		string GetConfiguration();

		Task<CmpConsent> GetConsent(PrivacyEnvironment environment, Action<bool> onPrivacyShown);

		Task<CmpConsent> OpenPrivacySettings();

		void ClearCache();
	}
}
