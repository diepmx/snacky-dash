namespace JuicedUp.Features.Core
{
	public sealed class LevelMapCache
	{
		private LevelDataSO _currentSo;

		public string CurrentJson { get; private set; }

		public void LoadForLevel(LevelDataSO levelSo, IAssetLoader assetLoader)
		{
		}

		public void Release()
		{
		}
	}
}
