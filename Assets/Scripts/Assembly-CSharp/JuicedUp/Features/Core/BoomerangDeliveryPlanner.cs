using System.Collections.Generic;

namespace JuicedUp.Features.Core
{
	internal static class BoomerangDeliveryPlanner
	{
		public static List<BoomerangPlanEntry> Plan(IReadOnlyList<CrateColumn> columns, int colIndex, IReadOnlyDictionary<PillKind, int> tailColorCount)
		{
			return null;
		}

		private static int SumAvailableTailFor(CrateColumn column, IReadOnlyDictionary<PillKind, int> tailCount)
		{
			return 0;
		}

		private static void Accumulate(CrateColumn column, int colIndex, Dictionary<PillKind, int> virtualTailCount, List<BoomerangPlanEntry> plan)
		{
		}

		private static CrateData ResolveNextVirtualCrate(CrateColumn column, List<BoomerangPlanEntry> plan)
		{
			return null;
		}

		private static CrateData PeekNextQueuedCrate(CrateColumn column, CrateData after)
		{
			return null;
		}

		private static int CountPlannedFor(List<BoomerangPlanEntry> plan, CrateData crate)
		{
			return 0;
		}
	}
}
