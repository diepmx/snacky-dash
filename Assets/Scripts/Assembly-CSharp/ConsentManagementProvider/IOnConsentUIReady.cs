using ConsentManagementProvider.EventHandlerInterface;
using UnityEngine.EventSystems;

namespace ConsentManagementProvider
{
	public interface IOnConsentUIReady : IConsentEventHandler, IEventSystemHandler
	{
		void OnConsentUIReady();
	}
}
