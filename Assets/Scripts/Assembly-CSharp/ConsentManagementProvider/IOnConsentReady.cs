using ConsentManagementProvider.EventHandlerInterface;
using UnityEngine.EventSystems;

namespace ConsentManagementProvider
{
	public interface IOnConsentReady : IConsentEventHandler, IEventSystemHandler
	{
		void OnConsentReady(SpConsents consents);
	}
}
