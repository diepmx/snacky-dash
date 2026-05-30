using System.Collections.Generic;

namespace Voodoo.Live.Offers
{
	public class SpinWithReroll : Feature
	{
		private IPrice _rerollPrice;

		private int _rerollCount;

		private bool _spinUsed;

		private int _spinCountSinceOpened;

		private RandomReward _randomReward;

		public readonly int rerollLimit;

		public new RandomReward Reward => null;

		public int SpinCountSinceOpened
		{
			get
			{
				return 0;
			}
			private set
			{
			}
		}

		public int RerollCount
		{
			get
			{
				return 0;
			}
			private set
			{
			}
		}

		public bool SpinUsed
		{
			get
			{
				return false;
			}
			private set
			{
			}
		}

		public bool CanFreeSpin => false;

		public bool IsRerollLimitReached => false;

		public int RemainingRerolls => 0;

		public IPrice RerollPrice => null;

		public override bool ShouldDisplayBadges => false;

		public SpinWithReroll(string id, Product product, IPrice rerollPrice, int rerollLimit)
		{
		}

		public override void Validate()
		{
		}

		public void UseFirstFreeSpin()
		{
		}

		private void ResolveReward()
		{
		}

		public void Reroll()
		{
		}

		private void OnRerollCompleted(Transaction transaction, bool succeed)
		{
		}

		private void IncreaseRerollCount()
		{
		}

		public override void RecoverTransaction(Transaction transaction)
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
