using ConsentManagementProvider.EventHandlerInterface;
using UnityEngine;

namespace ConsentManagementProvider
{
	public static class ConsentMessenger
	{
		public static void AddListener<T>(GameObject go) where T : IConsentEventHandler
		{
		}

		public static void RemoveListener<T>(GameObject go) where T : IConsentEventHandler
		{
		}

		public static void Broadcast<T>(params object[] list) where T : IConsentEventHandler
		{
		}
	}
}
