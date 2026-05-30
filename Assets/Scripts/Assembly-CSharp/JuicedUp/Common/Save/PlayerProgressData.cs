using System;
using System.Collections.Generic;

namespace JuicedUp.Common.Save
{
	[Serializable]
	public class PlayerProgressData
	{
		public int CurrentLevel;

		public bool ShouldGoDirectlyToLevel;

		public HashSet<int> ShownIngredientPopups;
	}
}
