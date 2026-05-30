using ConsentManagementProvider.EventHandlerInterface;
using UnityEngine.EventSystems;

namespace ConsentManagementProvider
{
	public interface IOnConsentAction : IConsentEventHandler, IEventSystemHandler
	{
		void OnConsentAction(SpAction action);
	}
}
