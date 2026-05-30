using System;

namespace JuicedUp.Common.Config
{
	[Serializable]
	public class EgpConfig
	{
		public const float DefaultDeliveryPercentage = 0.6f;

		public bool ShouldUseDeliveryPercentage;

		public float DeliveryPercentage;

		public float SafetyBufferPercentage;
	}
}
