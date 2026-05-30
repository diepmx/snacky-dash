using UnityEngine;

namespace JuicedUp.Features.Core.Debugger
{
	public static class EgpDebugOverrides
	{
		public static bool? UseDeliveryPercentage;

		public static float? DeliveryPercentage;

		public static bool HasAnyOverride => false;

		public static void SetDeliveryPercentage(float? value)
		{
		}

		public static void Clear()
		{
		}

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
		private static void Reset()
		{
		}
	}
}
