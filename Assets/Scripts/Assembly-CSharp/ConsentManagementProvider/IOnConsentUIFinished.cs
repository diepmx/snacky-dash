using ConsentManagementProvider.EventHandlerInterface;
using UnityEngine.EventSystems;

namespace ConsentManagementProvider
{
	public interface IOnConsentUIFinished : IConsentEventHandler, IEventSystemHandler
	{
		void OnConsentUIFinished();
	}
}
