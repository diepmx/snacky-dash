using System.Collections.Generic;

namespace JuicedUp.Features.Core
{
	public class WinConditionChecker
	{
		private readonly List<CrateColumn> _columns;

		public WinConditionChecker(List<CrateColumn> columns)
		{
		}

		public bool IsLevelComplete()
		{
			return false;
		}
	}
}
