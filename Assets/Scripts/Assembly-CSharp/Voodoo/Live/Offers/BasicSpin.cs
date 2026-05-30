using System.Collections.Generic;

namespace Voodoo.Live.Offers
{
	public class BasicSpin : Feature
	{
		private RandomReward _randomReward;

		public override bool ShouldDisplayBadges => false;

		public BasicSpin(string id, Product product)
		{
		}

		public override void Validate()
		{
		}

		public override void Purchase()
		{
		}

		private void ResolveReward()
		{
		}

		public override Dictionary<string, object> GetContextParameters()
		{
			return null;
		}

		public override void Reset()
		{
		}
	}
}
