namespace JuicedUp.Features.Core
{
	public readonly struct LevelResolution
	{
		public readonly LevelDataSO LevelData;

		public readonly LevelSource Source;

		public readonly string CohortName;

		public LevelResolution(LevelDataSO levelData, LevelSource source, string cohortName)
		{
			LevelData = null;
			Source = default(LevelSource);
			CohortName = null;
		}
	}
}
