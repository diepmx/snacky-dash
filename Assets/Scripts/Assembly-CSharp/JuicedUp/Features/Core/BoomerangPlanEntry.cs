namespace JuicedUp.Features.Core
{
	internal readonly struct BoomerangPlanEntry
	{
		public readonly int ColumnIndex;

		public readonly CrateData Crate;

		public readonly PillKind PillKind;

		public BoomerangPlanEntry(int columnIndex, CrateData crate, PillKind pillKind)
		{
			ColumnIndex = 0;
			Crate = null;
			PillKind = default(PillKind);
		}
	}
}
