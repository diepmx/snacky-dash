using System;
using ConsentManagementProvider.EventHandlerInterface;
using UnityEngine.EventSystems;

namespace ConsentManagementProvider
{
	public interface IOnConsentError : IConsentEventHandler, IEventSystemHandler
	{
		void OnConsentError(Exception exception);
	}
}
