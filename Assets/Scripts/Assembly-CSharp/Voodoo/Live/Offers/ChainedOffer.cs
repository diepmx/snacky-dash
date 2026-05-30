using System.Collections.Generic;

namespace Voodoo.Live.Offers
{
	public class ChainedOffer : BuyAllFeatureGroup
	{
		private const string CurrentStepKey = "CurrentStep";

		public int CurrentStep { get; private set; }

		public int ChainStepNumber => 0;

		public int TotalChainSteps => 0;

		public bool AllStepsPurchased => false;

		public override void Initialize()
		{
		}

		public string GetCurrentStepPriceAtShown()
		{
			return null;
		}

		protected override void OnStatusChanged(string status, IFeature feature)
		{
		}

		private void AdvanceStep()
		{
		}

		public override void Reset()
		{
		}

		public override Dictionary<string, object> GetContextParameters()
		{
			return null;
		}
	}
}
