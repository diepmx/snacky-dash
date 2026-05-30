using Voodoo.Live.Diagnostics;

namespace Voodoo.Live.Offers
{
	public sealed class InvalidFeature : Feature
	{
		public InvalidFeature(DiagnosticEntry diagnostic, string featureId = null)
		{
		}

		public override void Validate()
		{
		}

		public override void Purchase()
		{
		}

		public override bool TryTrigger(string trigger, bool forceTrigger = false, string sourceType = null, string sourceValue = null)
		{
			return false;
		}
	}
}
