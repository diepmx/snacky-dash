using Voodoo.ADN.Internal;

namespace Voodoo.ADN
{
	internal class AdnPublisherSignals
	{
		private static AdnPublisherSignals _instance;

		private readonly AdnSignalsCollector signalsCollector;

		private static AdnPublisherSignals Instance => null;

		private AdnPublisherSignals()
		{
		}

		public static void Initialize(bool consent, bool isCcpaApplicable)
		{
		}

		public static string GetLastCollectedSignals()
		{
			return null;
		}
	}
}
