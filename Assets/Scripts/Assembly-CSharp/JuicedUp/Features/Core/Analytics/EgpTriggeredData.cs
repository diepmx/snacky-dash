namespace JuicedUp.Features.Core.Analytics
{
	public struct EgpTriggeredData
	{
		public bool UsedDeliveryPercentage { get; private set; }

		public float DeliveryPercentage { get; private set; }

		public int TotalLength { get; private set; }

		public int DeliveredCount { get; private set; }

		public EgpTriggeredData(bool usedDeliveryPercentage, float deliveryPercentage, int totalLength, int deliveredCount)
		{
			UsedDeliveryPercentage = false;
			DeliveryPercentage = 0f;
			TotalLength = 0;
			DeliveredCount = 0;
		}
	}
}
