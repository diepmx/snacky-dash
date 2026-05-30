using System.Collections.Generic;

namespace Voodoo.Live.Offers
{
	public class EndlessOffer : FeatureGroup
	{
		private int _currentStep;

		private int _currentCycle;

		public int CurrentStep
		{
			get
			{
				return 0;
			}
			private set
			{
			}
		}

		public int CurrentCycle
		{
			get
			{
				return 0;
			}
			private set
			{
			}
		}

		public int ChainStepNumber => 0;

		public int TotalChainSteps => 0;

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
