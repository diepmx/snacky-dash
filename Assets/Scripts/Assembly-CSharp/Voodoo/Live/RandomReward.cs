using System.Collections.Generic;

namespace Voodoo.Live
{
	public class RandomReward : IReward, IResultProvider
	{
		private int _totalWeight;

		private Reward _selectedReward;

		private readonly DrawMode _drawMode;

		private readonly HashSet<string> _drawnIndices;

		private string lastPick;

		public Dictionary<Reward, int> rewardToWeight;

		private int _selectedIndex;

		public Result Validation { get; private set; }

		public string Type => null;

		public Item[] Items => null;

		public int SelectedIndex => 0;

		public Reward SelectedReward => null;

		private bool AllRewardsDrawn => false;

		public void SetLastPick(string hashId)
		{
		}

		private Item[] GetItems()
		{
			return null;
		}

		public RandomReward(Dictionary<Reward, int> rewardToWeight, DrawMode drawMode = DrawMode.Replacement)
		{
		}

		public ItemQuantity[] Unresolved()
		{
			return null;
		}

		public ItemQuantity[] Resolve()
		{
			return null;
		}

		private int GetEffectiveWeight()
		{
			return 0;
		}

		public void Consume()
		{
		}

		public void ResetDrawnRewards()
		{
		}

		public Reward GetSelectedReward()
		{
			return null;
		}

		public RandomReward WithValidation(Result validation)
		{
			return null;
		}

		public void Validate()
		{
		}
	}
}
