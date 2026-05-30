using ConsentManagementProvider.EventHandlerInterface;
using UnityEngine.EventSystems;

namespace ConsentManagementProvider
{
	public interface IOnConsentSpFinished : IConsentEventHandler, IEventSystemHandler
	{
		void OnConsentSpFinished();
	}
}
